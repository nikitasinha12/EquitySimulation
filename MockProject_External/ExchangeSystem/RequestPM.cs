using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ExchangeSystem
{
    [DataContract]
    public class RequestPM
    {
        string symbol;

        [DataMember]
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

    }
}