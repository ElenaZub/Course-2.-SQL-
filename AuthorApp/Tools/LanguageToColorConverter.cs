using AuthorApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace AuthorApp.Tools
{
    public class LanguageToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            switch ((int)value)       
            {
                case 0:
                    return new SolidColorBrush(Colors.Blue);
                case 1:
                    return new SolidColorBrush(Colors.Red);
                case 2:
                    return new SolidColorBrush(Colors.Yellow);
                default:
                   return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
