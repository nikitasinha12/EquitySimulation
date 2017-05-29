using Internal_System.DataModel;
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

namespace Internal_System.Admin_Views
{
    /// <summary>
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        EquityEntities db;
        public static bool PM, Trader, Admin;
        public EditUser()
        {
            InitializeComponent();
            db = new EquityEntities();
            this.Loaded += EditUser_Loaded;
        }

        void EditUser_Loaded(object sender, RoutedEventArgs e)
        {
            List<User_Role> SelectedUserRoles = new List<User_Role>(db.User_Role.Where(t => t.UserID == Dashboard_Admin.selectedUser.UserID && t.ISActive==true).ToList());
            foreach (var item in SelectedUserRoles)
            {
                if (item.RoleID == 1)
                    chkbxTrader.IsChecked = true;
                if (item.RoleID == 2)
                    chkbxPM.IsChecked = true;
                if (item.RoleID == 3)
                    chkbxAdmin.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (chkbxAdmin.IsChecked == true)
            {
                Admin = true;
            }
            if (chkbxPM.IsChecked == true)
            {
                PM = true;
            }
            if (chkbxTrader.IsChecked == true)
            {
                Trader = true;
            }

            this.DialogResult = true;
        }
    }
}
