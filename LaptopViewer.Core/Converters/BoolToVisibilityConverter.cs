using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Data;

namespace LaptopViewer.Core.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isReversed = parameter != null && parameter.ToString().ToUpper().Equals("REVERSE");
            bool boolVal = (bool?)value ?? false;

            return boolVal ^ isReversed ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
