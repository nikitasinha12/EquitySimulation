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

namespace Mock_Project.PM_Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            this.Closed += Dashboard_Closed;
        }

        void Dashboard_Closed(object sender, EventArgs e)
        {
            if (App.Current.MainWindow.Title.Equals("Dashboard"))
                App.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder c = new CreateOrder();
            c.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreatePortfolio c = new CreatePortfolio();
            c.ShowDialog();
        }        
    }
}
