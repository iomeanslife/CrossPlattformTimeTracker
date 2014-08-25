using Cirrious.MvvmCross.ViewModels;
using PppApp.Core.Models;
using PppApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PppApp.Core.ViewModels
{
    public class StateTimerVM : MvxViewModel
    {
        private readonly ITimerStateService timerStateService;
        //private string CurrentTimertState;

        public string CurrentTimertState
        {
            get { return timerStateService.CurrentStateType; }
        }

        public Todo CurrentTodoItem
        {
            get { return timerStateService.CurrentTodoItem; }
        }

        public string CurrentTodoItemTitle
        {
            get { return timerStateService.CurrentTodoItem.Title; }
        }

        public string TimeLeft
        {
            get
            {
                return timerStateService.TimeLeft.ToString(@"mm\:ss");
            }
        }

        public bool TimePassed
        {
            get
            {
                return timerStateService.TimeLeft <= TimeSpan.Zero;
            }
        }

      
        public bool SessionOngoing
        {
            get { return (timerStateService.SessionOngoing); }
        }


        public StateTimerVM(ITimerStateService argTimerStateService)
        {
            timerStateService = argTimerStateService;
            timerStateService.CurrentStateTypeChanged += timerStateService_CurrentStateTypeChanged;
            timerStateService.CurrentTodoItemChanged += timerStateService_CurrentTodoItemChanged;
        }

        void timerStateService_CurrentTodoItemChanged(object s, EventArgs e)
        {
            RaisePropertyChanged("CurrentTodoItem");
        }

        void timerStateService_CurrentStateTypeChanged(object s, EventArgs e)
        {
            RaisePropertyChanged("CurrentTimertState");
        }

        public override void Start()
        {
            base.Start();
        }

        private MvxCommand<String> startTimerCommand;
        public MvxCommand<String> StartTimerCommand
        {
            get
            {
                startTimerCommand = startTimerCommand ?? new MvxCommand<String>(
                    (argParams) =>
                    {
                        string[] finParams = argParams.Split(';');

                        timerStateService.StartTimer(int.Parse(finParams[0]), finParams[1]);
                        RaisePropertyChanged("TimeLeft");
                        RaisePropertyChanged("SessionOngoing");
                    }
                    );
                return startTimerCommand;
            }
        }

        private MvxCommand<String> stopTimerCommand;
        public MvxCommand<String> StopTimerCommand
        {
            get
            {
                stopTimerCommand = stopTimerCommand ?? new MvxCommand<String>(
                    (argParams) =>
                    {
                        timerStateService.StopTimer(argParams);
                        RaisePropertyChanged("TimeLeft");
                        RaisePropertyChanged("SessionOngoing");
                    }
                    );
                return stopTimerCommand;
            }
        }

        private MvxCommand startTimerCommandShortRest;
        public MvxCommand StartTimerCommandShortRest
        {
            get
            {
                startTimerCommandShortRest = startTimerCommandShortRest ?? new MvxCommand(
                    () =>
                    {
                        timerStateService.StartTimer(5, "Short Rest");
                        RaisePropertyChanged("TimeLeft");
                        RaisePropertyChanged("SessionOngoing");
                    }
                    );
                return startTimerCommandShortRest;
            }
        }

        private MvxCommand startTimerCommandLongRest;
        public MvxCommand StartTimerCommandLongRest
        {
            get
            {
                startTimerCommandLongRest = startTimerCommandLongRest ?? new MvxCommand(
                    () =>
                    {
                        timerStateService.StartTimer(15, "Long Rest");
                        RaisePropertyChanged("TimeLeft");
                        RaisePropertyChanged("SessionOngoing");
                    }
                    );
                return startTimerCommandLongRest;
            }
        }

        private MvxCommand startTimerCommandPomodoro;
        public MvxCommand StartTimerCommandPomodoro
        {
            get
            {
                startTimerCommandPomodoro = startTimerCommandPomodoro ?? new MvxCommand(
                    () =>
                    {
                        timerStateService.StartTimer(25, "Pomodoro");
                        RaisePropertyChanged("TimeLeft");
                        RaisePropertyChanged("SessionOngoing");
                    }
                    );
                return startTimerCommandPomodoro;
            }
        }

        private MvxCommand stopTimerCommandInterrupted;
        public MvxCommand StopTimerCommandInterrupted
        {
            get
            {
                stopTimerCommandInterrupted = stopTimerCommandInterrupted ?? new MvxCommand(
                    () =>
                    {
                        timerStateService.StopTimer("Interrupted");
                        RaisePropertyChanged("TimeLeft");
                        RaisePropertyChanged("SessionOngoing");
                    }
                    );
                return stopTimerCommandInterrupted;
            }
        }


        private MvxCommand<string> addInterruptionCommand;
        public MvxCommand<string> AddInterruptionCommand
        {
            get
            {
                addInterruptionCommand = addInterruptionCommand ?? new MvxCommand<string>(
                    (param) =>
                    {
                        CurrentTodoItem.Interuptions.Add(new Interruption() { Reason = int.Parse(param) });
                    }
                    );
                return addInterruptionCommand;
            }
        }

        private MvxCommand addInternalInterruptionCommand;
        public MvxCommand AddInternalInterruptionCommand
        {
            get
            {
                addInternalInterruptionCommand = addInternalInterruptionCommand ?? new MvxCommand(
                    () =>
                    {
                        CurrentTodoItem.Interuptions.Add(new Interruption() { Reason = 1 });
                    }
                    );
                return addInternalInterruptionCommand;
            }
        }

        private MvxCommand addExternalInterruptionCommand;
        public MvxCommand AddExternalInterruptionCommand
        {
            get
            {
                addExternalInterruptionCommand = addExternalInterruptionCommand ?? new MvxCommand(
                    () =>
                    {
                        CurrentTodoItem.Interuptions.Add(new Interruption() { Reason = 0 });
                    }
                    );
                return addExternalInterruptionCommand;
            }
        }

        private MvxCommand goToListCommand;
        public MvxCommand GoToListCommand
        {
            get
            {
                goToListCommand = goToListCommand ?? new MvxCommand(
                    () =>
                    {
                        ShowViewModel<TodoListVM>();
                    }
                    );
                return goToListCommand;
            }
        }
    }
}