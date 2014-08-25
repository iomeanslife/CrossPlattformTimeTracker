using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using PppApp.Core.ViewModels;
using System.Timers;

namespace PppApp.Ui.Droid.Views
{
    [Activity(MainLauncher = false)]
    //[Activity(MainLauncher = true)]
    class StateTimerView : MvxActivity
    {
        private Timer timer;
        public new StateTimerVM ViewModel
        {
            get { return (StateTimerVM)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.View_StateTimer);
        }
        public StateTimerView()
        {
            timer = new Timer(300);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ViewModel.RaisePropertyChanged("TimeLeft");
        }
    }
}