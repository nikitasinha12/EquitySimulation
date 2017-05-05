using Mock_Project.Commands;
using Mock_Project.DataModel;
using Mock_Project.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Project.PM_ViewModels
{
    class OrderHistoryViewModel : ANotifyPropertyChanged
    {
        private ObservableCollection<Order> _Orders;
        EquityEntities db;
        public DelegateCommand OrderHistoryDelegate { get; set; }
        public ObservableCollection<Order> OrdersList
        {
            get
            {
                return _Orders;
            }
            set
            {
                _Orders = value;
                OnPropertyChanged();
            }
        }
        private void refresh()
        {
            
            db = new EquityEntities();
            _Orders = new ObservableCollection<Order>(db.Orders.Where(t => t.OrderStatusID == 1 && t.PMID == Session.CurrentUser.UserID).ToList());
        }
        public OrderHistoryViewModel()
        {
            refresh();
        }
    }
}
