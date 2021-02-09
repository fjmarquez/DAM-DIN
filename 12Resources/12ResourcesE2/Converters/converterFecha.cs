using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _12ResourcesE2.Converters
{
    class converterFecha : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {

            DateTime now =  (DateTime)value;

            //String dateToString = now.Day.ToString() + " " + now.DayOfWeek + " de " + now.Month.ToString() + " del " + now.Year.ToString();

            String dateToString = now.ToString("dd'/'MM'/'yyyy");

            return dateToString;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            String dateString = (String)value;

            DateTime stringToDate = DateTime.Parse(dateString);

            return stringToDate;
        }
    }
}
