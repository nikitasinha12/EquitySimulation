using Mock_Project.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Project.Traders.Models
{
    class TypeSymbolSideCombo
    {
        public string Type { get; set; }
        public string Symbol { get; set; }
        public string Side { get; set; }

        public List<Order> Orders { get; set; }

        public int Count { get; set; }

        public string Key
        {
            get
            {
                return Type + Symbol + Side;
            }
        }

        public TypeSymbolSideCombo(string type, string symbol, string side)
        {
            // TODO: Complete member initialization
            this.Type = type;
            this.Symbol = symbol;
            this.Side = side;
            this.Count = 0;
            this.Orders = new List<Order>();
        }
    }
}
