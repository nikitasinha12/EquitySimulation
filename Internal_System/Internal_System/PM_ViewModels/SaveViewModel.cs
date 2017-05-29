using Internal_System.Commands;
using Internal_System.DataModel;
using Internal_System.Framework;
using Internal_System.PM_Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Internal_System.PM_ViewModels
{
    class SaveViewModel : ANotifyPropertyChanged
    {
        private ObservableCollection<Order> _Orders;
        EquityEntities db;
        AmendEquityOrder newAmend;
        public Order Order { get; set; }
        public DelegateCommand AmendDelegate { get; set; }
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

        public SaveViewModel() {
            refresh();
        }

        private void refresh()
        {
            EditSavedOrder edit=new EditSavedOrder();
            AmendDelegate = new DelegateCommand(CanAmendExecute,AmendExecute);
            Order = new Order();
            db = new EquityEntities();
            _Orders = new ObservableCollection<Order>(db.Orders.Where(t => t.OrderStatusID == 2 && t.PMID==Session.CurrentUser.UserID).ToList());
        }

        private void AmendExecute(object obj)
        {
            {
                //App.Current.MainWindow.Hide();
                //App.Current.MainWindow = newAmend;
                if (obj == null)
                {
                    MessageBox.Show("Select an order");
                    return;
                }
                newAmend = new AmendEquityOrder();
                newAmend.DataContext = new SaveViewModel() { Order = obj as Order };
                newAmend.ShowDialog();
            }
        }

        private bool CanAmendExecute(object obj)
        {
            return true;
        }
    }
}
