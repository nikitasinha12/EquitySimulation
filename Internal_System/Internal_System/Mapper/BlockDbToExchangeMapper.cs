using Internal_System.DataModel;
using Internal_System.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal_System.Mapper
{
    class BlockDbToExchangeMapper
    {
        public static Request MapDbToExchange(Block block)
        {
            Request exchangeRequest = new Request();


            exchangeRequest.BlockID = block.BlockID;
            exchangeRequest.TraderID = block.UserID;
            //exchangeRequest.BlockStatusID = block.BlockStatusID;
            //exchangeRequest.SymbolID = block.SymbolID;
            exchangeRequest.QtyAllocated = block.ExectuedQty;
            //exchangeRequest.LimitPrice = block.LimitPrice;
            exchangeRequest.QtyRequested = block.TotalQty;
            //exchangeRequest.Status = block.Block_status.StatusName;
            exchangeRequest.TimeStamp = block.UpdationDate;
            //exchangeRequest.UpdationDate = block.UpdationDate;
            exchangeRequest.Side = block.Orders.ToList()[0].Side;
            exchangeRequest.Type = block.Orders.ToList()[0].OrderTypeID.ToString();
            exchangeRequest.StatusID = Convert.ToSByte(block.Block_status.BlockStatusId);
            exchangeRequest.Symbol = block.Symbol_Properties.Symbol;
            //exchangeRequest.TimeStamp = 

            return exchangeRequest;
        }
    }
}
