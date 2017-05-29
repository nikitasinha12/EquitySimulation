using Internal_System.DataModel;
using Internal_System.Framework;
using Internal_System.PM_ViewModels;
using Internal_System.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Internal_System.PM_Views
{
    /// <summary>
    /// Interaction logic for SavedOrders.xaml
    /// </summary>
    public partial class SavedOrders : UserControl
    {
        EquityEntities db;
        public ObservableCollection<OrdersViewModel> SavedOrder { get; set; }
        public SavedOrders()
        {
            InitializeComponent();
            db = new EquityEntities();
            grdSaved.MouseEnter += SavedOrders_MouseEnter;
        }

        void SavedOrders_MouseEnter(object sender, MouseEventArgs e)
        {
            grdSaved.ItemsSource = null;
            grdSaved.ItemsSource = db.Orders.Where(t => t.OrderStatusID == 5 && t.PMID == Session.CurrentUser.UserID).ToList();
        }

       

        //private void CheckBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    var chk = (CheckBox)sender;
        //    var row = VisualTreeHelpers.FindAncestor<DataGridRow>(chk);
        //    var newValue = !chk.IsChecked.GetValueOrDefault();

        //    row.IsSelected = newValue;
        //    chk.IsChecked = newValue;

        //    // Mark event as handled so that the default 
        //    // DataGridPreviewMouseDown doesn't handle the event
        //    e.Handled = true;
        //}

    }
}
