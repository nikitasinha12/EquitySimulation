using Mock_Project.DataModel;
using Mock_Project.Mapper;
using Mock_Project.Traders.TraderDashboard;
using Mock_Project.Traders.View_Blocks;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Mock_Project.Traders.TraderDashboard
{
    /// <summary>
    /// Interaction logic for TraderDashboard.xaml
    /// </summary>
    public partial class TraderDashboard : Window
    {
        private EquityEntities db;
        public TraderDashboard()
        {
            InitializeComponent();
            //db=new EquityEntities();
            //OrderDataGrid.MouseEnter += BtnCreateNewBlock_MouseLeave;

        }

        

        //void BtnCreateNewBlock_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    OrderDataGrid.ItemsSource =
        //        CheckedOpenOrderToOrderMapper.ToCheckedOrderList(db.Orders.Where(o => o.BlockID == null).ToList());
        //}


        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewBlocksWindow obj = new ViewBlocksWindow(); 
        //    obj.Show();
            
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    CancelBlockWindow cancelBlockWindow = new CancelBlockWindow();
        //    cancelBlockWindow.Show();
        //}

    }
}
