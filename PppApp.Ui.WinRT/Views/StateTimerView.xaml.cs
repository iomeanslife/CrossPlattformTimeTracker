using PppApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace PppApp.Ui.WinRT.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class StateTimerView : PppApp.Ui.WinRT.Common.LayoutAwarePage
    {
        DispatcherTimer testTimer;

        public StateTimerView()
        {
            this.InitializeComponent();
        }

        public new StateTimerVM ViewModel
        {
            get { return (StateTimerVM)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        private void pageRoot_Loaded(object sender, RoutedEventArgs e)
        {
            testTimer = new DispatcherTimer();
            testTimer.Interval = TimeSpan.FromMilliseconds(300.0);
            testTimer.Tick += testTimer_Tick;
            testTimer.Start();
        }

        void testTimer_Tick(object sender, object e)
        {
            this.ViewModel.RaisePropertyChanged("TimeLeft");
            //System.Diagnostics.Debug.WriteLine(this.ViewModel.TimeLeft);
            if (this.ViewModel.SessionOngoing && this.ViewModel.TimePassed)
            {
                ViewModel.StopTimerCommand.Execute();
                MessageDialog diag = new MessageDialog(String.Format("The \"{0}\" phase is over!", this.ViewModel.CurrentTimertState), this.ViewModel.CurrentTimertState + " Complete!");
                diag.ShowAsync();
                //MessageBox.Show(String.Format("The \"{0}\" phase is over!", this.ViewModel.CurrentTimertState), this.ViewModel.CurrentTimertState + " Complete!", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
            }
        }

       
    }
}
