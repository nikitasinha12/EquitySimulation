using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExchangeSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITraderFillService" in both code and config file together.
    [ServiceContract]
    public interface ITraderFillService
    {
        [OperationContract]
        Response GetData(Request request);
    }
}
