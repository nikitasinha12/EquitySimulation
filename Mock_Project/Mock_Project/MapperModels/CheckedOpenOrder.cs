using Mock_Project.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Project.MapperModels
{
    class CheckedOpenOrder
    {
        public bool IsChecked { get; set; }

        // Default
        public long OrderID { get; set; }
        public long OrderTypeID { get; set; }
        public Nullable<long> BlockID { get; set; }
        public long PortfolioID { get; set; }
        public long PMID { get; set; }
        public long OrderStatusID { get; set; }
        public Nullable<decimal> MarketPrice { get; set; }
        public Nullable<decimal> LimitPrice { get; set; }
        public long AllocatedQty { get; set; }
        public long TotalQty { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Side { get; set; }
        public long SymbolID { get; set; }
        public Nullable<decimal> StopPrice { get; set; }
        public System.DateTime CreationDate { get; set; }
        public System.DateTime UpdationDate { get; set; }

        public virtual Block Block { get; set; }
        public virtual Order_Status Order_Status { get; set; }
        public virtual Order_Type Order_Type { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual Symbol_Properties Symbol_Properties { get; set; }
        public virtual User User { get; set; }
    }
}
