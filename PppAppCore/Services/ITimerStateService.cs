using PppApp.Core.Models;
using PppApp.Core.Services.Delegates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PppApp.Core.Services
{
    public interface ITimerStateService
    {
        int Minutes { get; }
        DateTime StartTime { get; }
        Todo CurrentTodoItem { set; get; }
        ObservableCollection<Todo> TodoCollection { set; get; }
        String CurrentStateType { get; }
        bool SessionOngoing { get; }
        TimeSpan TimeLeft { get; }
        void StartTimer(int argMinutes);
        void StartTimer(int argMinutes, DateTime argStartTime);
        void StartTimer(int argMinutes, String StateType);
        void StartTimer(int argMinutes, DateTime argStartTime, String StateType);
        void StopTimer(string argReason);
        event  CurrentStateTypeChangedDelegate CurrentStateTypeChanged;
        event CurrentTodoItemChangedDelegate CurrentTodoItemChanged;
        event TodoItemPropertyChangedDelegate TodoItemPropertyChanged;
    }
}