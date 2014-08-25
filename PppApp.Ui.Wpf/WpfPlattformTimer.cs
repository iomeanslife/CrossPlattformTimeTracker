using Cirrious.MvvmCross.ViewModels;
using PppApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PppApp.Ui.Wpf
{
    public class WpfPlattformTimer
    {
        Timer testTimer;
        StateTimerVM currentVM;

        public StateTimerVM CurrentVM
        {
            get { return currentVM; }
            set {
                if (value != null)
                {
                currentVM = value;
                }
                else
                {
                }
                
            }
        }
        public WpfPlattformTimer()
        {
            testTimer = new Timer(1000);
            testTimer.Elapsed += testTimer_Elapsed;
            testTimer.Start();
        }

        

        void testTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (currentVM != null &&
                currentVM.SessionOngoing)
            {
                currentVM.RaisePropertyChanged("TimeLeft");
            }
        }
    }
}