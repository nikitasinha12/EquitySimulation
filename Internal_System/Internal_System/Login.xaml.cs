using Internal_System.Shared_ViewModel;
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

namespace Internal_System
{
    /// <summary>
    /// Interaction logic for FooterUserControl.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static Login current;
        public Login()
        {           
            InitializeComponent();
            current = this;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PM_ForgotPasswordViewModel pM_ForgotPasswordViewModel = new PM_ForgotPasswordViewModel(this);
            ForgotPasswordPopup forgotPasswordPopup = new ForgotPasswordPopup();
            forgotPasswordPopup.DataContext = pM_ForgotPasswordViewModel;
            forgotPasswordPopup.Show();
            Application.Current.MainWindow = forgotPasswordPopup;
        }
    }
}
