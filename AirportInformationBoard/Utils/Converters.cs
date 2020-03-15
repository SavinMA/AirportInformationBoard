using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AirportInformationBoard.Utils
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return value is null ? Visibility.Hidden : Visibility.Visible;
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
