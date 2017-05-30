using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Internal_System.Commands;
using Internal_System.DataModel;
using Internal_System.Mapper;
using Internal_System.MapperModels;
using Internal_System.Traders.TraderDashboard;

namespace Internal_System.Traders.Cancel_Blocks
{
    class CancelBlockVM
    {
        public static IndividualBlock IndividualBlock { get; set; }
        public ObservableCollection<Block> Block { get; set; }
        public DelegateCommand CancelBlockCommand { get; set; }
        public DelegateCommand DashBoardPageCommand { get; set; }
        public ObservableCollection<CheckedBlock> BlockCheckedList { get; set; }
        EquityEntities db = new EquityEntities();
        public Block block { get; set; }

        public CancelBlockVM()
        {
            IndividualBlock = new IndividualBlock();
            Block = new ObservableCollection<Block>(db.Blocks.Where(o=>o.BlockStatusID==5).ToList());
            CancelBlockCommand = new DelegateCommand(CancleBlockPredicate,CancelBlockAction);
            DashBoardPageCommand = new DelegateCommand((obj)=> true, TradersDashBoardAction);
            var statusIdValue = db.Block_status.Where(o => o.StatusName == "New").Select(s => s.BlockStatusId).FirstOrDefault();
            BlockCheckedList = new ObservableCollection<CheckedBlock>(BlockToCheckedBlockMapper.ToCheckedBlockList(db.Blocks.Where(o => o.BlockStatusID == statusIdValue).ToList()));
        }

        private void TradersDashBoardAction(object obj)
        {
            Traders.TraderDashboard.TraderDashboard traderDashboard = new Traders.TraderDashboard.TraderDashboard();

            var current = App.Current.MainWindow;
            App.Current.MainWindow = traderDashboard;

            current.Close();
            traderDashboard.Show();
        }

        private void CancelBlockAction(object obj)
        {
            var checkedBlocksIds = BlockCheckedList.Where(o => o.IsChecked).Select(o => o.BlockID).ToList();
            bool isEmpty = !checkedBlocksIds.Any();
            if (isEmpty)
            {
                MessageBox.Show("Please select a block");
            }
            else
            {
                var blockList = db.Blocks.Where(o => checkedBlocksIds.Contains(o.BlockID));
                foreach (var item in blockList)
                {

                    DeleteBlock(item.BlockID);
                    db.Entry(item).State = EntityState.Deleted;
                    BlockCheckedList.Remove(BlockCheckedList.FirstOrDefault(o => o.BlockID == item.BlockID));
                }
                int saveValue = db.SaveChanges();
                if (saveValue > 0)
                {
                    MessageBox.Show("Block is Cancelled");
                }
                else
                {
                    MessageBox.Show("Block is not Cancelled");
                }
                
            }

            long newBlockStatusId = db.Block_status.Where(o => o.StatusName == "New").Select(s => s.BlockStatusId).First();
            int newBlockCount = db.Blocks.Where(o => o.BlockStatusID == newBlockStatusId).Count();
            if (newBlockCount == 0)
            {
                Traders.TraderDashboard.TraderDashboard traderDashboard = new Traders.TraderDashboard.TraderDashboard();

                var current = App.Current.MainWindow;
                App.Current.MainWindow = traderDashboard;

                current.Close();
                traderDashboard.Show();
            }
        }

        private bool CancleBlockPredicate(object obj)
        {
            return true;
        }
        private void DeleteBlock( long blockId)
        {
            var dbOrder = db.Orders.Where(orderId => orderId.BlockID == blockId);
            foreach(var items in dbOrder)
            {
                items.UpdationDate = System.DateTime.Now;
                items.BlockID = null;
                items.OrderStatusID = db.Order_Status.Where(o => o.StatusName == "Pending").Select(s => s.OrderStatusID).FirstOrDefault();
            }
            

        }
    }
}
