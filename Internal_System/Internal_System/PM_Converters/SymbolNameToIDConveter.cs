using Internal_System.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Internal_System.PM_Converters
{
    class SymbolNameToIDConveter : IValueConverter
    {
        EquityEntities db;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            db = new EquityEntities();
            if (value == null)
                return null;
            long y= (long)value;
            return db.Symbol_Properties.First(x => x.SymbolID == y).Symbol;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            db = new EquityEntities();
            if (value == null)
                return null;
            return db.Symbol_Properties.First(x => x.Symbol == value.ToString()).SymbolID;
        }
    }
}
