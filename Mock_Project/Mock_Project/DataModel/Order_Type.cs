//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Internal_System.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Type
    {
        public Order_Type()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public long OrderTypeID { get; set; }
        public string OrderTypeName { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
