using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp_MVVM.ViewModel.Converter
{
    public class BoolToRainConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //model -> view
            bool isRaining = (bool)value;

            if(isRaining)
            {
                return "Raining";
            }
            return "Sunny";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //view -> model
            string isRaining = (string)value;
            if(isRaining == "Raining")
            {
                return true;
            }

            return false;
        }
    }
}
