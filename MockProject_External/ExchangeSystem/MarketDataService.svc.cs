using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExchangeSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MarketDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MarketDataService.svc or MarketDataService.svc.cs at the Solution Explorer and start debugging.
    public class MarketDataService : IMarketDataService
    {
        public List<ResponsePM> GetWholeData()
        {
            External_DatabaseEntities dbObj = new External_DatabaseEntities();
            var stockList = dbObj.StockDatas.ToList();
            List<ResponsePM> listObj = new List<ResponsePM>();

            foreach (var stock in stockList)
            {
                ResponsePM responseObj = new ResponsePM();
                responseObj.Symbol = stock.Symbol;
                responseObj.Name = stock.Name;
                responseObj.Price = stock.MarketPrice;
                listObj.Add(responseObj);
            }


            return listObj;

        }

        public ResponsePM GetSymbolData(string symbol)
        {

            External_DatabaseEntities db = new External_DatabaseEntities();
            var list = db.StockDatas.ToList();
            var price1 = list.Where(s => s.Symbol == symbol).Select(s => s.MarketPrice);
            int price = price1.First();
            var name1 = list.Where(s => s.Symbol == symbol).Select(s => s.Name);
            string name = name1.First();

            ResponsePM obj = new ResponsePM();
            obj.Name = name;
            obj.Price = price;
            obj.Symbol = symbol;

            return obj;
        }
    }
}
