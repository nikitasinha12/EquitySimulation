using Internal_System.DataModel;
using Internal_System.PM_ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Internal_System.Services;

namespace Internal_System.PM_Views
{
    /// <summary>
    /// Interaction logic for PendingOrders.xaml
    /// </summary>
    public partial class PendingOrders : UserControl
    {
        EquityEntities db;
        public List<OrdersViewModel> PendingOrder { get; set; }
        public PendingOrders()
        {
            InitializeComponent();
            db = new EquityEntities();
            grdPending.MouseEnter += SavedOrders_MouseEnter;
        }

        void SavedOrders_MouseEnter(object sender, MouseEventArgs e)
        {
            grdPending.ItemsSource = null;
            grdPending.ItemsSource = db.Orders.Where(t => t.OrderStatusID == 2 && t.PMID == Session.CurrentUser.UserID).ToList();
        }


        //private void LoadGrid()
        //{
        //    EquityEntities db = new EquityEntities();
        //    PendingOrder = new List<OrdersViewModel>();
        //    var statusId = db.Order_Status.Where(t => t.StatusName.Equals("Pending")).Select(s => s.OrderStatusID).FirstOrDefault();
        //    var tempOrders = db.Orders.Where(t => t.OrderStatusID == statusId).ToList();
        //    foreach (var item in tempOrders)
        //    {
        //        PendingOrder.Add(new OrdersViewModel(new DialogService()) { OrderModel = new OrderModel() { Order = item } });
        //    }

        //    grdPending.ItemsSource = PendingOrder;
        //}
    }
}
