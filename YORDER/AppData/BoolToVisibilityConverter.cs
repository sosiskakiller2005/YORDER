using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace YORDER.AppData
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // value может быть bool или string (например, для IsNullOrEmpty)
            if (value == null)
                return Visibility.Visible;

            bool isEmpty = false;

            if (value is bool b)
                isEmpty = b;
            else if (value is string s)
                isEmpty = string.IsNullOrEmpty(s);

            return isEmpty ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
