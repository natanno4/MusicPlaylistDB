using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MusicPlayList.Entities
{
    class HotnessConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            float hot;
            float.TryParse(value.ToString(), out hot);
            if (hot == -1)
            {
                return "No Information";
            }
            else if (hot >= 0 && hot < 0.2)
            {
                return "*";
            }
            else if (hot > 0.2 && hot < 0.4)
            {
                return "**";
            }
            else if (hot > 0.4 && hot < 0.6)
            {
                return "***";
            }
            else if (hot > 0.6 && hot < 0.8)
            {
                return "****";
            }
            else
            {
                return "*****";
            }


        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
