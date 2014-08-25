using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PppApp.Core.Models
{
    public class Todo : INotifyPropertyChanged
    {
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        private bool done;

        public bool Done
        {
            get { return done; }
            set
            {
                done = value;
                RaisePropertyChanged("Done");
            }
        }

        private MvxViewModel parent;

        public MvxViewModel Parent
        {
            get { return parent; }
            set { parent = value;
            RaisePropertyChanged("Parent");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string argProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(argProperty));
            }
        }

        public override string ToString()
        {
            return title;
        }

        private List<Interruption> interuptions;

        public List<Interruption> Interuptions
        {
            get { return interuptions; }
            set { interuptions = value; }
        }
    }

      public class Interruption
        {
            private int reason;

            public int Reason
            {
                get { return reason; }
                set { reason = value; }
            }
        }
}