using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ExchangeSystem
{
    [DataContract]
    public class ResponsePM
    {
        string symbol;
        string name;
        double price;

        [DataMember]
        public String Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

    }
}