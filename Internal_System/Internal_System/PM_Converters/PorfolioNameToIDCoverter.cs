using Internal_System.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Internal_System.PM_Converters
{
    class PorfolioNameToIDCoverter : IValueConverter
    {
        EquityEntities db;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            db = new EquityEntities();
            if (value == null)
                return null;
            return db.Portfolios.First(x => x.PortfolioName == value.ToString()).PortfolioID;
        }
    }
}
