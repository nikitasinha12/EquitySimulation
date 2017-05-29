using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internal_System.DataModel;

namespace Internal_System.MapperModels
{
    class CheckedBlock
    {
        public bool IsChecked { get; set; }

        public CheckedBlock()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public long BlockID { get; set; }
        public long UserID { get; set; }
        public long BlockStatusID { get; set; }
        public long SymbolID { get; set; }
        public long ExectuedQty { get; set; }
        public decimal LimitPrice { get; set; }
        public long TotalQty { get; set; }
        public decimal StopPrice { get; set; }
        public System.DateTime CreationDate { get; set; }
        public System.DateTime UpdationDate { get; set; }
    
        public virtual Block_status Block_status { get; set; }
        public virtual Symbol_Properties Symbol_Properties { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
