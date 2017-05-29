using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderClientTest.ServiceReference1;

namespace TraderClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Request req = new Request();
            req.RequestID = 1;
            req.BlockID = 5;
            req.TraderID = 8;
            req.Symbol = "INFY";
            req.QtyRequested = 1000;
            req.QtyAllocated = 0;
            req.Type = "GTC";
            req.Side = "Sell";
            req.StatusID = 1;
            ServiceReference1.TraderFillServiceClient a = new ServiceReference1.TraderFillServiceClient();
            Console.WriteLine(a.GetData(req).QtyAllocated);
            //Console.WriteLine(a.GetData(req).Symbol);
            Console.Read();


            //ServiceReference2.MarketDataServiceClient proxy = new ServiceReference2.MarketDataServiceClient();
            //ServiceReference2.ResponsePM response = new ServiceReference2.ResponsePM();

            //ServiceReference2.ResponsePM[] listObj;
            //response = proxy.GetSymbolData("RIL");
            //Console.WriteLine(response.Name + " " + response.Price);
            //listObj = proxy.GetWholeData();
            //foreach (var item in listObj)
            //{
            //    Console.WriteLine(item.Name + " " + item.Symbol + " " + item.Price);
            //}
            //Console.ReadLine();
        
        }
    }
}
