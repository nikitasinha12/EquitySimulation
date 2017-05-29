using Mock_Project.DataModel;
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
    /// Interaction logic for Dashboard_Admin.xaml
    /// </summary>
    public partial class Dashboard_Admin : Window
    {
        EquityEntities db;
        public static User selectedUser;
        public Dashboard_Admin()
        {
            InitializeComponent();
            this.MouseEnter += Dashboard_Admin_MouseEnter;
            db = new EquityEntities();
            this.Closing += Dashboard_Admin_Closing;
        }

        void Dashboard_Admin_Closing(object sender, EventArgs e)
        {
            if (App.Current.MainWindow.Title.Equals("Dashboard_Admin"))
                App.Current.Shutdown();
        }

        void Dashboard_Admin_MouseEnter(object sender, MouseEventArgs e)
        {
            grdUsers.ItemsSource = db.Users.Where(t=> t.ISActive==true).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selectedUser = grdUsers.SelectedItem as User;
        }

    }
}
