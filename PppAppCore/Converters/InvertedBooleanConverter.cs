using Cirrious.CrossCore.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PppApp.Core.Converters
{
    public class InvertedBooleanConverter : MvxValueConverter<bool, bool>
    {
        protected override bool Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !value;
        }

        protected override bool ConvertBack(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !value;
        }

        
    }
}
