using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HelloMauiApp.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public Color NullColor { get; set; }
        public Color TrueColor { get; set; }
        public Color FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool val)
            {
                return val ? TrueColor : FalseColor;
            }
            
            return NullColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
