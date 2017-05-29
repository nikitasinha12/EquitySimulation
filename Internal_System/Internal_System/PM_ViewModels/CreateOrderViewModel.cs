using Internal_System.Framework;
using Internal_System.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internal_System.Commands;
using Internal_System.PM_Views;

namespace Internal_System.PM_ViewModels
{
    class CreateOrderViewModel : ANotifyPropertyChanged
    {
        EquityEntities db;
        private Order _order;
        private string error;
        public DelegateCommand CreateOrderDelegate { get; set; }
        public string ErrorMessage { get { return error; } set { error = value; OnPropertyChanged(); } }
        public Order order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }
        public CreateOrderViewModel()
        {
            CreateOrderDelegate = new DelegateCommand(CreateOrderPredicate,CreateOrderAction);
            _order = new Order();
            db = new EquityEntities();
        }

        private bool CreateOrderPredicate(object obj)
        {
            return true;
        }

        private void CreateOrderAction(object obj)
        {
           
            if (obj != null)
            {
                var x = obj as Order;
                if (CreateOrder.Buy)
                    x.Side = "Buy";
                else if (CreateOrder.Sell)
                    x.Side = "Sell";
                if (CreateOrder.GTC)
                    x.ExpiryDate = DateTime.Now.AddDays(4);
                else if (CreateOrder.GTD)
                    x.ExpiryDate = DateTime.Now.AddDays(1);
                if (CreateOrder.Stop)
                    x.OrderTypeID = 6;
                else if (CreateOrder.Limit)
                    x.OrderTypeID = 5;
                else if (CreateOrder.StopLimit)
                    x.OrderTypeID = 7;
                else if (CreateOrder.Mkt)
                    x.OrderTypeID = 4;
                x.CreationDate = DateTime.Now;
                x.UpdationDate = DateTime.Now;
                x.PMID = Session.CurrentUser.UserID;
                x.OrderStatusID = 5;
                db.Orders.Add(x);
                db.SaveChanges();
            }
            else
                ErrorMessage = "Invalid data";
        }
    }
}
