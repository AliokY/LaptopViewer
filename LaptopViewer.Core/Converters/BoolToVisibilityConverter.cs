using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LaptopViewer.Core.Converters;

public class BoolToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Converts a boolean value to a Visibility value
    /// </summary>
    /// <param name="value">The boolean value to convert</param>
    /// <param name="targetType">The type of the target property</param>
    /// <param name="parameter">An optional parameter used to reverse the conversion</param>
    /// <param name="culture">The culture to use in the conversion</param>
    /// <returns>Visibility.Visible if the boolean value is true (or false if reversed), otherwise Visibility.Collapsed</returns>
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