using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PppApp.Core.Services.Delegates
{
    public delegate void CurrentStateTypeChangedDelegate(Object s, PropertyChangedEventArgs e);
    public delegate void CurrentTodoItemChangedDelegate(Object s, PropertyChangedEventArgs e);
    public delegate void TodoItemPropertyChangedDelegate(Object s, PropertyChangedEventArgs e);
}
