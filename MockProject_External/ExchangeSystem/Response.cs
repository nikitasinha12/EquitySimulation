using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ExchangeSystem
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public int RequestID { get; set; }
        [DataMember]
        public long BlockID { get; set; }
        [DataMember]
        public long TraderID { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public long QtyRequested { get; set; }
        [DataMember]
        public long QtyAllocated { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Side { get; set; }
        [DataMember]
        public short StatusID { get; set; }
        [DataMember]
        public System.DateTime TimeStamp { get; set; }
        [DataMember]
        public virtual Status Status { get; set; }
        [DataMember]
        public virtual StockData StockData { get; set; }
    }

}
