using PppApp.Core.Models;
using PppApp.Core.Services.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PppApp.Core.Services
{
    class TimerStateService : ITimerStateService
    {
        private DateTime startTime;
        private String currentStateType;
        private bool sessionOngoing;
        private int minutes;

        public event CurrentStateTypeChangedDelegate CurrentStateTypeChanged;
        public event CurrentTodoItemChangedDelegate CurrentTodoItemChanged;
        public event TodoItemPropertyChangedDelegate TodoItemPropertyChanged;

        public TimerStateService()
        {
            todoCollection = new System.Collections.ObjectModel.ObservableCollection<Todo>();
            //todoCollection.Add(new Todo() { Title = "Test1" });
            //todoCollection.Add(new Todo() { Title = "Test2" });
            //todoCollection.Add(new Todo() { Title = "Test3" });
            //todoCollection.Add(new Todo() { Title = "Test4" });
            //todoCollection.Add(new Todo() { Title = "Test5" });
            todoCollection.CollectionChanged += todoCollection_CollectionChanged;
        }

        void todoCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Todo item in e.NewItems)
                    item.PropertyChanged += TodoItem_PropertyChanged;

            if (e.OldItems != null)
                foreach (Todo item in e.OldItems)
                    item.PropertyChanged -= TodoItem_PropertyChanged;
        }

        private void TodoItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaiseTodoItemPropertyChanged(sender,e);
        }

        private void RaiseTodoItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (TodoItemPropertyChanged != null)
            {
                TodoItemPropertyChanged(sender, e);
            }
        }

        protected virtual void RaiseCurrentStateTypeChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (CurrentStateTypeChanged != null)
            {
                CurrentStateTypeChanged(sender, e);
            }
        }

        protected virtual void RaiseCurrentTodoItemChanged(object sender,  System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (CurrentTodoItemChanged != null)
            {
                CurrentTodoItemChanged(sender,e);
            }
        }        

        public bool SessionOngoing
        {
            get { return sessionOngoing; }
        }

        public int Minutes
        {
            get { return minutes; }
        }

        public DateTime StartTime
        {
            get { return startTime; }
        }

        public string CurrentStateType
        {
            get { return currentStateType; }
        }

        public void StartTimer(int argMinutes)
        {
            StartTimer(argMinutes, DateTime.Now, argMinutes.ToString() + " Minutes Session");
        }

        public void StartTimer(int argMinutes, DateTime argStartTime)
        {
            StartTimer(argMinutes, argStartTime, argMinutes.ToString() + " Minutes Session");
        }

        public void StartTimer(int argMinutes, string StateType)
        {
            StartTimer(argMinutes, DateTime.Now, StateType);
        }

        public void StartTimer(int argMinutes, DateTime argStartTime, string argStateType)
        {
            startTime = argStartTime;
            minutes = argMinutes;
            currentStateType = argStateType;
            sessionOngoing = true;
            RaiseCurrentStateTypeChanged(this, new System.ComponentModel.PropertyChangedEventArgs("CurrentStateType"));
        }

        public void StopTimer(string argReason)
        {
            startTime = DateTime.MinValue;
            minutes = 0;
            sessionOngoing = false;
            currentStateType = argReason ?? "Stopped";
            RaiseCurrentStateTypeChanged(this, new System.ComponentModel.PropertyChangedEventArgs("CurrentStateType"));
        }

       
        public TimeSpan TimeLeft
        {
            get
            {
                if (sessionOngoing)
                {
                    return (startTime.AddMinutes(minutes)) - DateTime.Now;
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
        }

        private Todo currentTodoItem;
        public Todo CurrentTodoItem
        {
            get
            {
                return currentTodoItem;
            }
            set
            {
                currentTodoItem = value;
                RaiseCurrentTodoItemChanged(this, new System.ComponentModel.PropertyChangedEventArgs("CurrentTodoItem"));
            }
        }

        private System.Collections.ObjectModel.ObservableCollection<Todo> todoCollection;

        public System.Collections.ObjectModel.ObservableCollection<Todo> TodoCollection
        {
            get { return todoCollection; }
            set { todoCollection = value; }
        }
    }
}