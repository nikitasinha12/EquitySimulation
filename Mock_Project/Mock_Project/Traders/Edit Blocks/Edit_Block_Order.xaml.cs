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

namespace Mock_Project.Traders.Edit_Blocks
{
    /// <summary>
    /// Interaction logic for Edit_Block_Order.xaml
    /// </summary>
    public partial class Edit_Block_Order : Window
    {
        public Edit_Block_Order()
        {
            InitializeComponent();

        }

        public Edit_Block_Order(long blockId)
            : this()
        {
            this.DataContext = new TraderEditVM(blockId);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
