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
using System.Windows.Shapes;

namespace Mock_Project.Admin_Views
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        public static bool PM, Trader, Admin;
        public CreateUser()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(chkbxAdmin.IsChecked==true)
            {
                Admin = true;
            }
            if(chkbxPM.IsChecked==true)
            {
                PM = true;
            }
            if(chkbxTrader.IsChecked==true)
            {
                Trader = true;
            }
        }
    }
}
