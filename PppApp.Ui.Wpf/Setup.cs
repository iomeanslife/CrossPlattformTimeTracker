using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Wpf.Platform;
using Cirrious.MvvmCross.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PppApp.Ui.Wpf
{
    public class Setup : MvxWpfSetup
    {
        public Setup(Dispatcher uiThreadDispatcher,
        IMvxWpfViewPresenter presenter)
            : base(uiThreadDispatcher, presenter)
        {
        }        

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}
