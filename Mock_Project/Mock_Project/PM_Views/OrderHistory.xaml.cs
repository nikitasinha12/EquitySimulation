using Mock_Project.DataModel;
using Mock_Project.PM_ViewModels;
using Mock_Project.Services;
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

namespace Mock_Project.PM_Views
{
    /// <summary>
    /// Interaction logic for OrderHistory.xaml
    /// </summary>
    public partial class OrderHistory : UserControl
    {
        EquityEntities db;
        public OrderHistory()
        {
            InitializeComponent();
            db = new EquityEntities();
            grdHistory.MouseEnter += SavedOrders_MouseEnter;
        }

        void SavedOrders_MouseEnter(object sender, MouseEventArgs e)
        {
            grdHistory.ItemsSource = null;
            grdHistory.ItemsSource = db.Orders.Where(t => t.OrderStatusID == 1 && t.PMID == Session.CurrentUser.UserID).ToList();
        }
    }
}
