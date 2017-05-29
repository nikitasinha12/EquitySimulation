using Internal_System.DataModel;
using Internal_System.MarketDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Internal_System.Services
{
    class SymbolDataRetriveService
    {
        /// <summary>
        /// void UpdateSymbols()
        /// Adds or Updates the Symbol_Properties
        /// </summary>
        public static void UpdateSymbols()
        {
            MarketDataServiceClient Client = new MarketDataServiceClient();
            EquityEntities db = new EquityEntities();
            try
            {
                var tempData = Client.GetWholeData().ToList();
                foreach (var item in tempData)
                {
                    db.UPSERT(item.Symbol, Convert.ToDecimal(item.Price), item.Name);
                }
                db.SaveChanges();
            }
            catch(Exception e)
            {
                if(e.Message.Contains("Endpoint"))
                    MessageBox.Show("Server Down\n Showing old data");
            }
        }

        /// <summary>
        /// decimal GetMarketPrice(string symbol)
        /// Input symbol in string format
        /// Returns Market Price
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static decimal GetMarketPrice(string symbol)
        {
            MarketDataServiceClient Client = new MarketDataServiceClient();
            var tempData = Client.GetSymbolData(symbol);
            return Convert.ToDecimal(tempData.Price);
        }
    }
}
