using Cirrious.MvvmCross.Wpf.Views;
using PppApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PppApp.Ui.Wpf.Views
{
    /// <summary>
    /// Interaction logic for StateTimerView.xaml
    /// </summary>
    public partial class StateTimerView : MvxWpfView
    {
        Timer testTimer;
        public new StateTimerVM ViewModel
        {
            get { return (StateTimerVM)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public StateTimerView()
        {
            InitializeComponent();
        }


        private void MvxWpfView_Loaded(object sender, RoutedEventArgs e)
        {
            testTimer = new Timer(500);
            testTimer.Elapsed += testTimer_Elapsed;
            this.ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            testTimer.Start();
        }
        void testTimer_Elapsed(object sender, ElapsedEventArgs e)
        {          
                this.ViewModel.RaisePropertyChanged("TimeLeft");
                //System.Diagnostics.Debug.WriteLine(this.ViewModel.TimeLeft);
                if (this.ViewModel.SessionOngoing && this.ViewModel.TimePassed)
                {
                    ViewModel.StopTimerCommand.Execute();
                    MessageBox.Show(String.Format("The \"{0}\" phase is over!", this.ViewModel.CurrentTimertState), this.ViewModel.CurrentTimertState + " Complete!", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
                }           
        }

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
            if (e.PropertyName == "SessionOngoing")
            {
                if (this.ViewModel.SessionOngoing)
                {
                    //testTimer.Start();
                }
                else
                {
                    //testTimer.Stop();
                    
                }
            }

        }

    }
}
