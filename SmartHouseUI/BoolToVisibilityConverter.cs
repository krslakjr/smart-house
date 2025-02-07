using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace SmartHouseUI
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? true : false;  // Koristimo true/false umjesto Visibility
            }
            return false;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is bool booleanValue && booleanValue;
        }
    }
}
