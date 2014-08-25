using PppApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class TodoListView : PppApp.Ui.WinRT.Common.LayoutAwarePage
    {
        public TodoListView()
        {
            this.InitializeComponent();
        }

        public new TodoListVM ViewModel
        {
            get { return (TodoListVM)base.ViewModel; }
            set { base.ViewModel = value; }
        }

     
    }
}
