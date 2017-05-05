using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExchangeSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UpdatePriceService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UpdatePriceService.svc or UpdatePriceService.svc.cs at the Solution Explorer and start debugging.
    public class UpdatePriceService : IUpdatePriceService
    {
        public void UpdatePrice()
        {
            Random rnd = new Random();
            External_DatabaseEntities db = new External_DatabaseEntities();

            foreach (var item in db.StockDatas) 
            {
                int sign=rnd.Next(1,3);
                switch (sign) 
                {
                    case 1:
                        item.MarketPrice += rnd.Next(1,20);
                        break;
                    case 2:
                        if (item.MarketPrice>20)
                        item.MarketPrice -= rnd.Next(1, 20);
                        break;
                    default:
                        item.MarketPrice += rnd.Next(1, 20);
                        break;
                }
            }
            db.SaveChanges();


        }
    }
}
