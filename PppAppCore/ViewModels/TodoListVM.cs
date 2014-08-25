using Cirrious.MvvmCross.ViewModels;
using PppApp.Core.Models;
using PppApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PppApp.Core.ViewModels
{
    public class TodoListVM : MvxViewModel
    {
        private readonly ITimerStateService timerStateService;

        public Todo CurrentTodoItem
        {
            get { return timerStateService.CurrentTodoItem; }
            set
            {
                if (!timerStateService.SessionOngoing)
                {
                    timerStateService.CurrentTodoItem = value;    
                }                
            }
        }

        private String addTodoTitle;

        public String AddTodoTitle
        {
            get { return addTodoTitle; }
            set
            {
                addTodoTitle = value;
                RaisePropertyChanged("AddTodoTitle");
                addItemCommand.RaiseCanExecuteChanged();
            }
        }

        public bool SessionOngoing
        {
            get { return (timerStateService.SessionOngoing); }
        }

        public ObservableCollection<Todo> TodoItemCollection
        {
            get { return timerStateService.TodoCollection; }
            set { timerStateService.TodoCollection = value; }
        }


        public TodoListVM(ITimerStateService argTimerStateService)
        {
            timerStateService = argTimerStateService;
            LoadVM();
        }

        private void UnloadVM()
        {
            timerStateService.CurrentTodoItemChanged -= timerStateService_CurrentTodoItemChanged;
            timerStateService.TodoItemPropertyChanged -= timerStateService_TodoItemPropertyChanged;
        }

        private void LoadVM()
        {
            timerStateService.CurrentTodoItemChanged += timerStateService_CurrentTodoItemChanged;
            timerStateService.TodoItemPropertyChanged += timerStateService_TodoItemPropertyChanged;
        }

        void timerStateService_TodoItemPropertyChanged(object s, System.ComponentModel.PropertyChangedEventArgs e)
        {
           
            GoToTimerCommand.RaiseCanExecuteChanged();
            ClearDoneItemsCommand.RaiseCanExecuteChanged();
        }

        private void timerStateService_CurrentTodoItemChanged(object s, EventArgs e)
        {
            RaisePropertyChanged("CurrentTodoItem");
            GoToTimerCommand.RaiseCanExecuteChanged();
        }
        private MvxCommand goToTimerCommand;
        public MvxCommand GoToTimerCommand
        {
            get
            {
                goToTimerCommand = goToTimerCommand ?? new MvxCommand(
                    () =>
                    {
                        //if (goToTimerCommand.CanExecute())
                        {
                            UnloadVM();
                            ShowViewModel<StateTimerVM>();
                        }
                    },
                    () =>
                    {
                        
                        return CurrentTodoItem != null && CurrentTodoItem.Done == false;
                        
                    }
                    );
                return goToTimerCommand;
            }
        }
        public override void Start()
        {
            base.Start();
        }

        private MvxCommand addItemCommand;
        public MvxCommand AddItemCommand
        {
            get
            {
                addItemCommand = addItemCommand ?? new MvxCommand(
                    () =>
                    {
                        timerStateService.TodoCollection.Add(new Todo()
                        {
                            Title = addTodoTitle,
                            Done = false

                        });
                        AddTodoTitle = String.Empty;
                    },
                    () =>
                    {
                        return !String.IsNullOrEmpty(addTodoTitle);
                    }
                    );
                return addItemCommand;
            }
        }

        private MvxCommand clearDoneItemsCommand;
        public MvxCommand ClearDoneItemsCommand
        {
            get
            {
                clearDoneItemsCommand = clearDoneItemsCommand ?? new MvxCommand(
                    () =>
                    {
                        List<Todo> todoKillList = timerStateService.TodoCollection.Where<Todo>(
                            (t) =>
                                t.Done == true
                            ).ToList<Todo>();
                        foreach (Todo inDoneTodo in todoKillList)
                        {
                            timerStateService.TodoCollection.Remove(inDoneTodo);
                        }
                        clearDoneItemsCommand.RaiseCanExecuteChanged();
                    },
                    () =>
                    {
                        return timerStateService.TodoCollection.Where(
                            (t) =>
                                t.Done == true
                            ).Count() > 0;
                    }
                    );
                return clearDoneItemsCommand;
            }
        }
    }
}