using Cirrious.MvvmCross.Wpf.Views;
using PppApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for TodoListView.xaml
    /// </summary>
    public partial class TodoListView : MvxWpfView
    {
        public TodoListView()
        {
            InitializeComponent();
        }
        
        public new TodoListVM ViewModel
        {
            get { return (TodoListVM)base.ViewModel; }
            set { base.ViewModel = value; }
        }

    }
}
