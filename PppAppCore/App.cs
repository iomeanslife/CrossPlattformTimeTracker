
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using PppApp.Core.Services;
using PppApp.Core.ViewModels;
namespace PppApp.Core
{

    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterSingleton<ITimerStateService>(() => new TimerStateService());
            Mvx.RegisterSingleton<IMvxAppStart>(() => new MvxAppStart<TodoListVM>());
        }
    }
}