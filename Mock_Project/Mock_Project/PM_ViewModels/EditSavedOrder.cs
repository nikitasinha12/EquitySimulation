using Mock_Project.Framework;
using Mock_Project.Commands;
using Mock_Project.DataModel;
using Mock_Project.PM_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mock_Project.PM_ViewModels
{
    class EditSavedOrder : ANotifyPropertyChanged
    {
        public static String Type;
        private Order _Order;
        public PM_Views.EditSavedOrder newEdit;
        private DelegateCommand _DelegateCommand;
        public DelegateCommand _EditCommand { get; set; }
        public Order Order
        {
            get { return _Order; }
            set
            {
                _Order = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand DelegateCommand
        {
            get { return _DelegateCommand; }
            set
            {
                _DelegateCommand = value;
                OnPropertyChanged();
            }
        }


        public EditSavedOrder()
        {
            _Order = new Order();
            _DelegateCommand = new DelegateCommand(CustomPredicate, CustomAction);
            _EditCommand = new DelegateCommand(CanEditExecute, EditExecute);

        }

        private void CustomAction(object obj)
        {

            EquityEntities Con = new EquityEntities();

            if (obj != null)
            {
                _Order = obj as Order;

                var temp = Con.Orders.SingleOrDefault(o => o.OrderID == _Order.OrderID);
                temp.Side = _Order.Side;
                temp.OrderStatusID = _Order.OrderStatusID;
                temp.SymbolID = _Order.SymbolID;
                temp.LimitPrice = _Order.LimitPrice;
                temp.StopPrice = _Order.StopPrice;
                temp.TotalQty = _Order.TotalQty;
                temp.UpdationDate = System.DateTime.Now;
                Con.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                Con.SaveChanges();
                //App.Current.MainWindow.Hide();
                //Dashboard d = new Dashboard();
                //App.Current.MainWindow = d;
                //d.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select atleast one order");
            }

        }

        private bool CustomPredicate(object obj)
        {
            return true;
        }
        public void EditExecute(object obj)
        {
            //App.Current.MainWindow.Hide();
            //App.Current.MainWindow = newEdit;
            Order xOrder = obj as Order;
            if (obj == null)
                MessageBox.Show("Please select an Order");
            else
            { 
            newEdit = new PM_Views.EditSavedOrder();
            newEdit.DataContext = new EditSavedOrder(){_Order=obj as Order};
            if (xOrder.OrderTypeID == 4)
                Type = "Market";
            else if (xOrder.OrderTypeID == 5)
                Type = "Limit";
            else if (xOrder.OrderTypeID == 6)
                Type = "Stop";
            else if (xOrder.OrderTypeID == 7)
                Type = "StopLimit";
            newEdit.ShowDialog();
            }
        }

        public bool CanEditExecute(object obj)
        {
            return true;
        }
    }
}
