using Mock_Project.DataModel;
using Mock_Project.MapperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Project.Mapper
{
    class CheckedOpenOrderToOrderMapper
    {
        public static CheckedOpenOrder ToCheckedOrder(Order order)
        {
            CheckedOpenOrder checkedOrder = new CheckedOpenOrder();

            checkedOrder.OrderID           = order.OrderID          ;
            checkedOrder.OrderTypeID       = order.OrderTypeID      ;
            checkedOrder.BlockID           = order.BlockID          ;
            checkedOrder.PortfolioID       = order.PortfolioID      ;
            checkedOrder.PMID              = order.PMID             ;
            checkedOrder.OrderStatusID     = order.OrderStatusID    ;
            checkedOrder.MarketPrice       = order.MarketPrice      ;
            checkedOrder.LimitPrice        = order.LimitPrice       ;
            checkedOrder.AllocatedQty      = order.AllocatedQty     ;
            checkedOrder.TotalQty          = order.TotalQty         ;
            checkedOrder.ExpiryDate        = order.ExpiryDate       ;
            checkedOrder.Side              = order.Side             ;
            checkedOrder.SymbolID          = order.SymbolID         ;
            checkedOrder.StopPrice         = order.StopPrice        ;
            checkedOrder.CreationDate      = order.CreationDate     ;
            checkedOrder.UpdationDate      = order.UpdationDate     ;
                                                             
            checkedOrder.Block             = order.Block            ;
            checkedOrder.Order_Status      = order.Order_Status     ;
            checkedOrder.Order_Type        = order.Order_Type       ;
            checkedOrder.Portfolio         = order.Portfolio        ;
            checkedOrder.Symbol_Properties = order.Symbol_Properties;
            checkedOrder.User              = order.User             ;

            return checkedOrder;
        }

        public static List<CheckedOpenOrder> ToCheckedOrderList(List<Order> orderList)
        {
            List<CheckedOpenOrder> list = new List<CheckedOpenOrder>();
            foreach(var item in orderList)
            {
                list.Add(ToCheckedOrder(item));
            }

            return list;
        }

        public static List<Order> ToOrderList(List<CheckedOpenOrder> checkedOrderList)
        {
            List<Order> list = new List<Order>();
            foreach (var item in checkedOrderList)
            {
                list.Add(ToOrder(item));
            }

            return list;
        }

        public static Order ToOrder(CheckedOpenOrder checkedOrder)
        {
            Order order = new Order();

            order.OrderID          = checkedOrder.OrderID          ;
            order.OrderTypeID      = checkedOrder.OrderTypeID      ;
            order.BlockID          = checkedOrder.BlockID          ;
            order.PortfolioID      = checkedOrder.PortfolioID      ;
            order.PMID             = checkedOrder.PMID             ;
            order.OrderStatusID    = checkedOrder.OrderStatusID    ;
            order.MarketPrice      = checkedOrder.MarketPrice      ;
            order.LimitPrice       = checkedOrder.LimitPrice       ;
            order.AllocatedQty     = checkedOrder.AllocatedQty     ;
            order.TotalQty         = checkedOrder.TotalQty         ;
            order.ExpiryDate       = checkedOrder.ExpiryDate       ;
            order.Side             = checkedOrder.Side             ;
            order.SymbolID         = checkedOrder.SymbolID         ;
            order.StopPrice        = checkedOrder.StopPrice        ;
            order.CreationDate     = checkedOrder.CreationDate     ;
            order.UpdationDate     = checkedOrder.UpdationDate     ;

            order.Block            = checkedOrder.Block            ;
            order.Order_Status     = checkedOrder.Order_Status     ;
            order.Order_Type       = checkedOrder.Order_Type       ;
            order.Portfolio        = checkedOrder.Portfolio        ;
            order.Symbol_Properties= checkedOrder.Symbol_Properties;
            order.User             = checkedOrder.User             ;

            return order;
        }
    }
}
