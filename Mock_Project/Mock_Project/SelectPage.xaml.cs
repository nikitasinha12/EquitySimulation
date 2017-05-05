using Mock_Project.Login_ViewModel;
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

namespace Mock_Project
{
    /// <summary>
    /// Interaction logic for SelectPage.xaml
    /// </summary>
    public partial class SelectPage : Window
    {
        public SelectPage()
        {
            InitializeComponent();
            this.Loaded += SelectPage_Loaded;
            btnPM.IsEnabled = false;
            btnPM.Background = Brushes.White;
            btnTrader.IsEnabled = false;
            btnPM.Background = Brushes.White;
            btnAdmin.IsEnabled = false;
            btnPM.Background = Brushes.White;
            this.Closed += SelectPage_Closed;
            
        }

        void SelectPage_Closed(object sender, EventArgs e)
        {
            if (App.Current.MainWindow.Title.Equals("SelectPage"))
                App.Current.Shutdown();
        }

        void SelectPage_Loaded(object sender, RoutedEventArgs e)
        {
            if(LoginViewModel.PM)
            {
                btnPM.IsEnabled = true;
                btnPM.Foreground = Brushes.White;
                btnPM.Background = Brushes.Black;
            }
            if (LoginViewModel.Trader)
            {
                btnTrader.IsEnabled = true;
                btnTrader.Foreground = Brushes.White;
                btnTrader.Background = Brushes.Black;

            }
                if (LoginViewModel.Admin)
            {
                btnAdmin.IsEnabled = true;
                btnAdmin.Foreground = Brushes.White;
                btnAdmin.Background = Brushes.Black;

            }
        }
    }
}
