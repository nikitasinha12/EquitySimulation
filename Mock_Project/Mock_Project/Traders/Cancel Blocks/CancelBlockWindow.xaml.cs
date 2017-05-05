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

namespace Mock_Project.Traders.Cancel_Blocks
{
    /// <summary>
    /// Interaction logic for CancelBlockWindow.xaml
    /// </summary>
    public partial class CancelBlockWindow : Window
    {
        public CancelBlockWindow()
        {
            InitializeComponent();
            this.DataContext = new CancelBlockVM();
        }
    }
}
