using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExchangeSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TraderFillService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TraderFillService.svc or TraderFillService.svc.cs at the Solution Explorer and start debugging.
    public class TraderFillService : ITraderFillService
    {
        public Response GetData(Request request)
        {
            Response response = new Response();
            request.RequestID = 0;
            Transaction transaction = new Transaction();
            try
            {/*Get Connection with the Stock DataBase*/
                //connect to transaction database
                //connect to partial Database
                //check for the available stocks 
                //if available assign the complete block and complete the entry in the transaction table and send the response to the trader.
                //else fill the partial transaction and add to the transaction table and add another entry in the partial table send the partial response.
                //check the partial table for completeness whenever new request is arrived and transact in the FIFO order.
               
               
                if (EnterRequestToDatabase(request))
                {
                    if (request.Side == "Sell")
                    {
                        ExchangeSell(request.Symbol, request.QtyRequested);
                        request.StatusID = 1;
                        response = ConvertRequestToResponse(request);
                        response.QtyAllocated = request.QtyRequested;

                        UpdateServiceRequestSell(request.TraderID, request.BlockID, request.QtyRequested);

                        transaction = ConvertResponse(response);
                        CreateTransaction(transaction);
                        UpdatePrice();
                    }
                    else
                    {
                        long qtyAlloted = ExchangeBuy(request.Symbol, request.QtyRequested);
                        if (qtyAlloted == request.QtyRequested)
                        {
                            request.StatusID = 1;
                            response = ConvertRequestToResponse(request);
                            response.QtyAllocated = qtyAlloted;
                            //Update Request Table Set Quantity=0 For Symbol==Symb


                            UpdateServiceRequestBuy(request.TraderID, request.BlockID, request.QtyRequested);



                            transaction = ConvertResponse(response);
                            CreateTransaction(transaction);
                        }
                        //partial FIll
                        else
                        {
                            request.StatusID = 3;
                            response = ConvertRequestToResponse(request);
                            response.QtyAllocated = qtyAlloted;
                            //Update Request Table Set Quantity=0 For Symbol==Symb


                            UpdateServiceRequestBuy(request.TraderID, request.BlockID, qtyAlloted);



                            transaction = ConvertResponse(response);
                            CreateTransaction(transaction);
                            UpdatePrice();
                        }

                    }
                    //response = (Response)request;
                    //response.QtyAllocated = 0;
                    //response.QtyRequested = 0;



                }
            }
            catch (Exception e)
            {
                response.StatusID = 4;
                response.QtyAllocated = 0;
                return response;
            }
            return response;
        
        }


        public Boolean EnterRequestToDatabase(Request request)
        {
            try {
                External_DatabaseEntities db = new External_DatabaseEntities();
                ServiceRequest requestdp = new ServiceRequest();
                //requestdp = request;
                //requestdp.StatusID = db.Status.Where(x => x.StatusName == "Filled").Select(x => x.StatusID).First();
                //requestdp.Symbol = db.StockDatas.Where(x => x.Symbol == "RIL").Select(x => x.Symbol).First();

                //requestdp.Side = "Sell";

                

                //requestdp.Type = "Market";
                requestdp = ConvertRequest(request);
                //requestdp.TimeStamp = DateTime.Today.ToUniversalTime();
                requestdp.TimeStamp = DateTime.Now;
                requestdp.Status = db.Status.First(c => c.StatusID == 2);

                requestdp.StockData = db.StockDatas.First(c => c.Symbol == request.Symbol);
               
            //List<Status> status = Convert.ToDouble(list.Where(s => s.StatusID == symbol).Select(s => s.MarketPrice));
                db.ServiceRequests.Add(requestdp);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }



        //public void ExchangeSell(String symbol,long qty)
        //{
        //    External_DatabaseEntities db = new External_DatabaseEntities();
        //    var list = db.StockDatas.ToList();
        //    double price = Convert.ToInt32(list.Where(s => s.Symbol == symbol).Select(s => s.MarketPrice));

        //    //return price;
        //}


        public void ExchangeSell(String symbol, long qty)
        {
            External_DatabaseEntities db = new External_DatabaseEntities();

            var query =
                from ord in db.StockDatas
                where ord.Symbol == symbol
                select ord;

            foreach (StockData ord in query)
            {
                ord.QuantityAvailable += (int)qty;
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }  



        //public List<Double> ExchangeBuy(String 
        //    symbol, long qty)
        //{
        //    External_DatabaseEntities db = new External_DatabaseEntities();
        //    var list = db.StockDatas.ToList();
        //    double price = Convert.ToDouble(list.Where(s => s.Symbol == symbol).Select(s => s.MarketPrice));
        //    double quantity = Convert.ToDouble(list.Where(s => s.Symbol == symbol).Select(s => s.QuantityAvailable));
        //    List<Double> listSend=new List<double>();
        //    listSend[0] = price;
        //    listSend[1] = quantity;

        //    return listSend;
        //}


        public long ExchangeBuy(String symbol, long qty)
        {
            External_DatabaseEntities db = new External_DatabaseEntities();

            long alloted=0;

            var query =
                from ord in db.StockDatas
                where ord.Symbol == symbol
                select ord;

            //StockData order = new StockData();

            foreach (StockData order in query)
            {
                if (qty > order.QuantityAvailable)
                {
                    alloted = order.QuantityAvailable;
                    order.QuantityAvailable = 0;
                }
                else
                {
                    alloted = qty;
                    order.QuantityAvailable -= qty;
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            return alloted;

        }
        //public string GetSymbolData(string request)
        //{
        //    string symbol =(string) JsonConvert.DeserializeObject(request);
        //    External_DatabaseEntities db = new External_DatabaseEntities();
        //    var list = db.StockDatas.ToList();
        //    int price =Convert.ToInt32(list.Where(s => s.Symbol == symbol).Select(s => s.MarketPrice));
        //    string name= list.Where(s => s.Symbol == symbol).Select(s => s.Name).ToString();

           
        //    Response obj = new Response();
        //    obj.Name = name;
        //    obj.Price = price;
        //    obj.Symbol = symbol;

        //    string response = JsonConvert.SerializeObject(obj);
            
            
        //    return response;
        //} 



        public ServiceRequest ConvertRequest(Request req)
        {
            ServiceRequest r = new ServiceRequest();

            r.BlockID = req.BlockID;
            r.TraderID = req.TraderID;
            r.Symbol = req.Symbol;
            r.QtyRequested = req.QtyRequested;
            r.QtyAllocated = req.QtyAllocated;
            r.Type = req.Type;
            r.Side = req.Side;
            r.StatusID = req.StatusID;
            //r.TimeStamp = DateTime.Today.ToUniversalTime();
            r.TimeStamp = DateTime.Now;

            return r;
        }

        public Response ConvertRequestToResponse(Request req)
        {
            Response r = new Response();

            r.BlockID = req.BlockID;
            r.TraderID = req.TraderID;
            r.Symbol = req.Symbol;
            r.QtyRequested = req.QtyRequested;
            r.QtyAllocated = req.QtyAllocated;
            r.Type = req.Type;
            r.Side = req.Side;
            r.StatusID = req.StatusID;
            //r.TimeStamp = DateTime.Today.ToUniversalTime();
            r.TimeStamp = DateTime.Now;

            return r;
        }



        public Transaction ConvertResponse(Response res)
        {
            Transaction trans = new Transaction();

            trans.BlockID = res.BlockID;
            trans.TraderID = res.TraderID;
            trans.Symbol = res.Symbol;
            trans.QtyRequested = res.QtyRequested;
            trans.QtyAllocated = res.QtyAllocated;
            trans.Type = res.Type;
            trans.Side = res.Side;
            trans.StatusID = res.StatusID;
            //trans.TimeStamp = DateTime.Today.ToUniversalTime();
            trans.TimeStamp = DateTime.Now;

            return trans;
        }



        public void CreateTransaction(Transaction T)
        {
            External_DatabaseEntities db = new External_DatabaseEntities();

            T.Status = db.Status.First(c => c.StatusID == T.StatusID);
            T.StockData = db.StockDatas.First(c => c.Symbol == T.Symbol); 

            db.Transactions.Add(T);
            db.SaveChanges();

        }



        public void UpdateServiceRequestSell(long traderID,long blockID, long qty)
        {
            External_DatabaseEntities db = new External_DatabaseEntities();

            var query =
                from order in db.ServiceRequests
                where order.TraderID == traderID && order.BlockID == blockID
                select order;

            String symbol = "";

            foreach (ServiceRequest order in query)
            {
                order.QtyAllocated += qty;
                symbol = order.Symbol;
            }

            

            try
            {
                db.SaveChanges();
                UpdatePartialFilled(traderID, blockID, symbol);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public void UpdateServiceRequestBuy(long traderID, long blockID, long qty)
        {
            External_DatabaseEntities db = new External_DatabaseEntities();

            var query =
                from order in db.ServiceRequests
                where order.TraderID == traderID && order.BlockID == blockID
                select order;

            foreach (ServiceRequest order in query)
            {
                order.QtyAllocated += qty;
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdatePartialFilled(long traderID, long blockID, String symbol)
        {
            External_DatabaseEntities db = new External_DatabaseEntities();


            try
            {
                var queryService =
                    from ord1 in db.ServiceRequests
                    where (ord1.QtyRequested > ord1.QtyAllocated) && (ord1.Side == "Buy") && (ord1.Symbol == symbol)
                    select ord1;

                var queryStock =
                    from ord2 in db.StockDatas
                    where ord2.Symbol == symbol
                    select ord2;

                long availableQuantity = 0;
                long addedQuantity = 0;

                var order2 = queryService.First();
                var order1 = queryStock.First();


                //foreach (ServiceRequest order2 in queryService)
                //{
                //    foreach (StockData order1 in queryStock)
                //    {
                        availableQuantity = order1.QuantityAvailable;

                        if (availableQuantity > (order2.QtyRequested - order2.QtyAllocated))
                        {
                            addedQuantity = order2.QtyRequested - order2.QtyAllocated;
                            order2.QtyAllocated = order2.QtyRequested;
                            order1.QuantityAvailable -= addedQuantity;
                        }
                        else
                        {
                            addedQuantity = availableQuantity;
                            order2.QtyAllocated += availableQuantity;
                            order1.QuantityAvailable -= addedQuantity;
                        }

                //    }
                //}



                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // and send the response to the trader service based on their trader ID But in this itteration Internal(Trader Team) is not accepting excecuted table.
        }

        public void UpdatePrice()
        {
            Random rnd = new Random();
            External_DatabaseEntities db = new External_DatabaseEntities();

                foreach (var item in db.StockDatas)
                {
                    int sign = rnd.Next(1, 3);
                    switch (sign)
                    {
                        case 1:
                            item.MarketPrice += rnd.Next(1, 20);
                            break;
                        case 2:
                            if (item.MarketPrice > 20)
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
