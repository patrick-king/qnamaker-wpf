using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;

namespace QnAMakerRuntimeAPI.UICore.Converters
{
    public class NullStringToVisiblityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool paramAsBool = false;
            if(parameter != null)
            {
                paramAsBool = System.Convert.ToBoolean(parameter);
            }
            if (paramAsBool)
            {
                if (string.IsNullOrEmpty((string)value))
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            else
            {
                if (string.IsNullOrEmpty((string)value))
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
