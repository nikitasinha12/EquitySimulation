using Mock_Project.Commands;
using Mock_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mock_Project.DataModel;
using System.Windows;
using System.Collections.ObjectModel;
using Mock_Project.Framework;
using System.Windows.Controls;

namespace Mock_Project.PM_ViewModels
{
    public class OrdersViewModel:ANotifyPropertyChanged
    {
        private IDialogService _dialogService;
        public DelegateCommand _SaveOrderCommand { get; set; }
        public DelegateCommand _EditCommand { get; set; }
        private ObservableCollection<Order> _Orders;
        EquityEntities db;
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
            _SaveOrderCommand = new DelegateCommand(CanSaveExecute, SaveExecute);
            db = new EquityEntities();
            _Orders = new ObservableCollection<Order>(db.Orders.Where(t => t.OrderStatusID == 5 && t.PMID == Session.CurrentUser.UserID).ToList());
        }

       
        public OrdersViewModel()
        {
            refresh();
        }
        public OrdersViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            refresh();
        }

        private void SaveExecute(object obj)
        {
            if(obj == null)
            {
                MessageBox.Show("Select atleast one order");
                return;
            }
            DataGrid dg = obj as DataGrid;
            List<long> orderIdList = new List<long>();
            for (int i = 0; i < dg.SelectedItems.Count; i++)
            {
                var order = dg.SelectedItems[0] as Order;
                orderIdList.Add(order.OrderID);
                
            }
            foreach (var item in orderIdList)
            {
                db.Orders.Find(item).OrderStatusID=2;
                db.SaveChanges();
            }
        }

        private bool CanSaveExecute(object obj)
        {
            return true;
        }
    }
}
