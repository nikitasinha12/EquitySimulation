using System;
using Mock_Project.Commands;
using Mock_Project.DataModel;
using Mock_Project.Traders.TraderDashboard;
using Mock_Project.Traders;
using Mock_Project.Traders.TraderDashboard;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mock_Project.Traders
{
    class TraderEditVM
    {
        public static IndividualOrder IndividualOrder { get; set; }
        public static IndividualBlock IndividualBlock { get; set; }
        public List<Order> Order { get; set; }
        public ObservableCollection<Order> OrderInBlock { get; set; }
        public List<Block> Block { get; set; }
        EquityEntities db = new EquityEntities();

        public DelegateCommand SaveDelegateCommand { get; set; }
        public DelegateCommand DashBoardPageCommand { get; set; }

        private long _blockId;

        public TraderEditVM()
        {
            IndividualOrder = new IndividualOrder();
            IndividualBlock = new IndividualBlock();
            OrderInBlock = new ObservableCollection<Order>();
            SaveDelegateCommand = new DelegateCommand(o => true, SaveData);
            Order = db.Orders.ToList();
            Block = db.Blocks.ToList();
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

        private void SaveData(object obj)
        {
            if (obj != null)
            {
                var order = obj as Order;
                var dbOrder = db.Orders.First(o => o.BlockID == order.BlockID);
                dbOrder.LimitPrice = order.LimitPrice;
                dbOrder.StopPrice = order.StopPrice;
                db.Entry(dbOrder).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public TraderEditVM(long blockId)
            : this()
        {
            _blockId = blockId;

            var orders = db.Orders.Where(o => o.BlockID == _blockId).ToList();

            OrderInBlock.Clear();
            foreach (var item in orders)
            {
                OrderInBlock.Add(item);
            }
        }



        private bool EditBlockOrdersPredicate(object obj)
        {
            return true;
        }
    }
}
