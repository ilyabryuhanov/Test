using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;


namespace GoodsFromWebStore.Converters
{
    public class PriceConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || double.IsNaN((double)value))
                return "Не задано";
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
