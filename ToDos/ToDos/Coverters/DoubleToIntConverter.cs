using System;
using System.Globalization;
using Xamarin.Forms;

namespace ToDos.Coverters
{
    public class DoubleToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double multiplier;
            if (parameter == null || !Double.TryParse(parameter.ToString(), out multiplier))
            {
                multiplier = 1;
            }


            return (int)Math.Round(multiplier * (double)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double devider;
            if (parameter == null || !Double.TryParse(parameter as string, out devider))
            {
                devider = 1;
            }

            return ((double)(int)value) / devider;
        }
    }
}
