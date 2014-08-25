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

namespace PppApp.Ui.Droid.Views
{
    [Activity(MainLauncher = true)]
    class TodoListView : MvxActivity
    {
        public new TodoListVM ViewModel
        {
            get { return (TodoListVM)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.View_TodoList);
        }
    }
}