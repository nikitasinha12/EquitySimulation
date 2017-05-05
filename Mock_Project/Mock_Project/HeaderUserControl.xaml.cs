using Mock_Project.PM_Views;
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

namespace Mock_Project
{
    /// <summary>
    /// Interaction logic for HeaderUserControl.xaml
    /// </summary>
    public partial class HeaderUserControl : UserControl
    {
        public HeaderUserControl()
        {
            InitializeComponent();
            this.Loaded += HeaderUserControl_Loaded;
        }


        void HeaderUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(App.Current.MainWindow == Login.current)
            {
                lblSignOut.Visibility = Visibility.Hidden;
            }
            if(App.Current.Windows.Count > 1)
            {
                if(App.Current.Windows[1].Title.Equals("CreateOrder"))
                    lblSignOut.Visibility = Visibility.Hidden;
            }
            if (Session.CurrentUser == null)
                UserID.Content = "";
            else
                UserID.Content = "Welcome, " + Session.CurrentUser.FName + " " + Session.CurrentUser.LName;
        }

        private void lblSignOut_Click(object sender, RoutedEventArgs e)
        {
            Session.CurrentUser = null;
            Session.CurrentRole = null;
            var oldCurrentWindow = Application.Current.MainWindow;
            Login login = new Login();
            App.Current.MainWindow = login;
            App.Current.MainWindow.Show();
            oldCurrentWindow.Close();
        }
    }
}
