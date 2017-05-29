using Internal_System.Commands;
using Internal_System.DataModel;
using Internal_System.Traders.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal_System.Traders.View_Blocks
{
    class ViewBlockVM
    {
       public List<Block> Block { get; set; }
       public ObservableCollection<Order> OrderInBlock { get; set; }
       public DelegateCommand ViewBlockOrdersCommand { get; set; }
       public DelegateCommand DashBoardPageCommand { get; set; }

       EquityEntities db = new EquityEntities();
       public ViewBlockVM()
        {
           Block = db.Blocks.ToList();

           var unassignedOrderList = db.Orders.Where(o => o.BlockID == null);

           var helper = new ProposedBlockHelper(unassignedOrderList);
           var proposedBlocks = helper.GetProposedBlocks();

           Block.AddRange(proposedBlocks);

           OrderInBlock = new ObservableCollection<Order>();
           ViewBlockOrdersCommand = new DelegateCommand(ViewBlockOrdersPredicate, ViewBlockOrdersAction);

           DashBoardPageCommand = new DelegateCommand((obj) => true, TradersDashBoardAction);
        }

       private void TradersDashBoardAction(object obj)
       {
           Traders.TraderDashboard.TraderDashboard traderDashboard = new Traders.TraderDashboard.TraderDashboard();

           var current = App.Current.MainWindow;
           App.Current.MainWindow = traderDashboard;

           current.Close();
           traderDashboard.Show();
       }

       private void ViewBlockOrdersAction(object obj)
       {
           long blockid = (long)obj;
           OrderInBlock.Clear();
           var list = db.Orders.Where(o => o.BlockID == blockid).ToList();
           foreach (var item in list)
           {
               OrderInBlock.Add(item);
           }
       }

       private bool ViewBlockOrdersPredicate(object obj)
       {
           return true;
       }
    }
}
