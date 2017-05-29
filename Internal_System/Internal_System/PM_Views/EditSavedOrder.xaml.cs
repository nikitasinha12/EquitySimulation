using Internal_System.DataModel;
using Internal_System.Services;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Internal_System.PM_Views
{
    /// <summary>
    /// Interaction logic for EditSavedOrder.xaml
    /// </summary>
    public partial class EditSavedOrder : Window
    {
        public EditSavedOrder()
        {
            InitializeComponent();
            lblboxLimitPrice.Visibility = Visibility.Hidden;
            txtboxLimitPrice.Visibility = Visibility.Hidden;
            lblboxStopPrice.Visibility = Visibility.Hidden;
            txtboxStopPrice.Visibility = Visibility.Hidden;
            this.Loaded += EditSavedOrder_Loaded;
            List<string> sideList = new List<string>();
            sideList.Add("Sell");
            sideList.Add("Buy");
            cbxSide.ItemsSource = sideList;
            SymbolDataRetriveService.UpdateSymbols();
            EquityEntities db = new EquityEntities();
            var SymList = db.Symbol_Properties.Select(s => s.Symbol).ToList();
            cbxSymbol.ItemsSource = SymList;
        }

        void EditSavedOrder_Loaded(object sender, RoutedEventArgs e)
        {
            if (PM_ViewModels.EditSavedOrder.Type == "Market")
            { 
                lblboxLimitPrice.Visibility = Visibility.Hidden;
                txtboxLimitPrice.Visibility = Visibility.Hidden;
                lblboxStopPrice.Visibility = Visibility.Hidden;
                txtboxStopPrice.Visibility = Visibility.Hidden;
            }
            else if (PM_ViewModels.EditSavedOrder.Type == "Limit")
            {
                lblboxLimitPrice.Visibility = Visibility.Visible;
                txtboxLimitPrice.Visibility = Visibility.Visible;
                lblboxStopPrice.Visibility = Visibility.Hidden;
                txtboxStopPrice.Visibility = Visibility.Hidden;
            }
            else if (PM_ViewModels.EditSavedOrder.Type == "Stop")
            {
                lblboxLimitPrice.Visibility = Visibility.Hidden;
                txtboxLimitPrice.Visibility = Visibility.Hidden;
                lblboxStopPrice.Visibility = Visibility.Visible;
                txtboxStopPrice.Visibility = Visibility.Visible;
            }
            else if (PM_ViewModels.EditSavedOrder.Type == "StopLimit")
            {
                lblboxLimitPrice.Visibility = Visibility.Visible;
                txtboxLimitPrice.Visibility = Visibility.Visible;
                lblboxStopPrice.Visibility = Visibility.Visible;
                txtboxStopPrice.Visibility = Visibility.Visible;
            }  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}