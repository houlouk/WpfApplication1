using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Music
{
    public class DoubleSpaceConverter : IValueConverter
    {
   
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int width=8;

            var doubleSpace = (bool)value;
            

            if (doubleSpace)
                return width*2;

            else
                return width;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
