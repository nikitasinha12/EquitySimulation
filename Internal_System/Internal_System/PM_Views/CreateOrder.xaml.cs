using Internal_System.DataModel;
using Internal_System.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Internal_System.PM_Views
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        public static bool Stop, Limit, StopLimit, Mkt, Buy, Sell, GTD, GTC;
        EquityEntities db;
        ObservableCollection<Portfolio> SavedPortfolio;
        ObservableCollection<User_Role> SavedTraderTemp;
        ObservableCollection<User> SavedTrader;
        List<String> PName;
        List<String> SymList;
        List<long> UIDTemp;
        public CreateOrder()
        {
            InitializeComponent();
            PName = new List<string>();
            this.Loaded += CreateOrder_Loaded;
        }

        void CreateOrder_Loaded(object sender, RoutedEventArgs e)
        {
            lblVisibilityPrices.Visibility = Visibility.Hidden;
            db = new EquityEntities();
            SavedPortfolio = new ObservableCollection<Portfolio>(db.Portfolios.Where(t => t.UserID == Session.CurrentUser.UserID).ToList());
            foreach (var item in SavedPortfolio)
            {
                PName.Add(item.PortfolioName);
            }
            Portfoliobox.ItemsSource = PName;
            var y = db.User_Role.Where(t2 => t2.RoleID == 1).Select(s => s.UserID).ToList();
            var x = db.Users.Where(t => y.Contains(t.UserID)).Select(s2 => s2.UserName).ToList();
            //var x = (from u in db.Users join r in db.User_Role on u.UserID equals r.UserID where r.RoleID == 1 select new { u.UserName }).ToList();

            TraderBox.ItemsSource = x;

            SymbolDataRetriveService.UpdateSymbols();
            SymList = db.Symbol_Properties.Select(s => s.Symbol).ToList();
            cbxSymbolList.ItemsSource = SymList;
            cbxSymbolList.SelectedItem = SymList[0];
        }

        private void cbxSymbolList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblSecurityName.Content = db.Symbol_Properties.Where(t => t.Symbol.Equals(cbxSymbolList.SelectedItem.ToString())).Select(s => s.Name).ToList()[0];
            lblMarketPrice.Content = SymbolDataRetriveService.GetMarketPrice(cbxSymbolList.SelectedValue.ToString());
        }

        private void Create_Order(object sender, RoutedEventArgs e)
        {
            if (rbtnBuy.IsChecked==true)
                Buy = true;
            if (rbtnSell.IsChecked==true)
                Sell = true;
            if (rbtnGTC.IsChecked == true)
                GTC = true;
            if (rbtnGTD.IsChecked == true)
                GTD = true;
            if (rbtnStopOrder.IsChecked == true)
                Stop = true;
            if (rbtnStopLimitOrder.IsChecked == true)
                StopLimit = true;
            if (rbtnLimitOrder.IsChecked == true)
                Limit = true;
            if (rbtnMktOrder.IsChecked == true)
                Mkt = true;
            this.DialogResult = true;
                
        }

        private void rbtnStopOrder_Checked(object sender, RoutedEventArgs e)
        {
            lblVisibilityPrices.Visibility = Visibility.Visible;
            lblStopPrice.Visibility = Visibility.Visible;
            txtStopPrice.Visibility = Visibility.Visible;
            lblLimitPrice.Visibility = Visibility.Hidden;
            txtLimitPrice.Visibility = Visibility.Hidden;
        }

        private void rbtnMktOrder_Checked(object sender, RoutedEventArgs e)
        {
           lblVisibilityPrices.Visibility = Visibility.Hidden;         
        }

        private void rbtnLimitOrder_Checked(object sender, RoutedEventArgs e)
        {
            lblVisibilityPrices.Visibility = Visibility.Visible;
            lblStopPrice.Visibility = Visibility.Hidden;
            txtStopPrice.Visibility = Visibility.Hidden;
            lblLimitPrice.Visibility = Visibility.Visible;
            txtLimitPrice.Visibility = Visibility.Visible;
        }

        private void rbtnStopLimitOrder_Checked(object sender, RoutedEventArgs e)
        {
            lblVisibilityPrices.Visibility = Visibility.Visible;
            lblStopPrice.Visibility = Visibility.Visible;
            txtStopPrice.Visibility = Visibility.Visible;
            lblLimitPrice.Visibility = Visibility.Visible;
            txtLimitPrice.Visibility = Visibility.Visible;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
    }
}
