using Mock_Project.Commands;
using Mock_Project.DataModel;
using Mock_Project.Mapper;
using Mock_Project.MapperModels;
using Mock_Project.Traders.TraderDashboard;
using Mock_Project.Traders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Mock_Project.ServiceReference1;
using Mock_Project.Traders.View_Blocks;
using Mock_Project.Traders.Cancel_Blocks;
using Mock_Project.Traders.Edit_Blocks;

namespace Mock_Project.Traders.TraderDashboard
{
    class TraderDashboardVM
    {
        public static IndividualOrder IndividualOrder { get ; set; }
        public static IndividualBlock IndividualBlock { get; set; }
        public ObservableCollection<CheckedOpenOrder> Order { get; set; }
        public ObservableCollection<Order> OrderInBlock { get; set; }
        public ObservableCollection<CheckedBlock> Block { get; set; }
        
        EquityEntities db = new EquityEntities();

        public DelegateCommand EditBlockOrdersCommand { get; set; }
        public DelegateCommand ViewBlockOrdersCommand { get; set; }
        public DelegateCommand CreateNewBlockCommand { get; set; }
        public DelegateCommand AddToExistingCommand { get; set; }
        public DelegateCommand CancelBlockOrdersCommand { get; set; }
        public DelegateCommand ViewBlockCommand { get; set; }
        public DelegateCommand SendToExchangeCommand { get; set; }


        public TraderDashboardVM()
        {
            IndividualOrder = new IndividualOrder();
            IndividualBlock = new IndividualBlock();
            OrderInBlock = new ObservableCollection<Order>();
            Order = new ObservableCollection<CheckedOpenOrder>(CheckedOpenOrderToOrderMapper.ToCheckedOrderList(db.Orders.Where(o=>o.BlockID == null).ToList()));
           // OrderInBlock = db.Orders.ToList().Where(o => o.BlockID == 8);
            Block = new ObservableCollection<CheckedBlock>(BlockToCheckedBlockMapper.ToCheckedBlockList(db.Blocks.ToList()));
            ViewBlockOrdersCommand = new DelegateCommand(ViewBlockOrdersPredicate, ViewBlockOrdersAction);
            CreateNewBlockCommand = new DelegateCommand(CreaetNewBlockPredicte, CreateNewBlockAction);
            AddToExistingCommand = new DelegateCommand(AddToExistingPredicate, AddToExistingAction);
            EditBlockOrdersCommand = new DelegateCommand((obj) => true, EditBlockOrdersAction);
            CancelBlockOrdersCommand = new DelegateCommand((obj) => true, CancelBlockOrdersAction);
            ViewBlockCommand = new DelegateCommand((obj) => true, ViewBlockAction);
            SendToExchangeCommand = new DelegateCommand(SendToExchangePredicate, SendToExchangeAction);
        }

        private void CancelBlockOrdersAction(object obj)
        {
            long newBlockStatusId = db.Block_status.Where(o => o.StatusName == "New")
                .Select(s => s.BlockStatusId)
                .FirstOrDefault();
            long newBlockCount = db.Blocks.Where(o => o.BlockStatusID == newBlockStatusId).Count();
            if (newBlockCount > 0)
            {
                CancelBlockWindow cancel = new CancelBlockWindow();

                var current = App.Current.MainWindow;
                App.Current.MainWindow = cancel;

                current.Close();
                cancel.Show();
            }
            else
            {
                MessageBox.Show("No new Block exist");
            }
        }

        private void ViewBlockAction(object obj)
        {
            ViewBlocksWindow viewBlocksWindow = new ViewBlocksWindow();

            var current = App.Current.MainWindow;
            App.Current.MainWindow = viewBlocksWindow;

            current.Close();
            viewBlocksWindow.Show();
        }

        private void SendToExchangeAction(object obj)
        {
            Request req = new Request();
            if(obj == null)
            {
                MessageBox.Show("Please select a block to send");
            }
            else
            {   
                long blockId = (long)obj;
                var selectedBlock = BlockDbToExchangeMapper.MapDbToExchange(db.Blocks.First(o => o.BlockID == blockId));
                req.RequestID = selectedBlock.RequestID;
                req.BlockID = selectedBlock.BlockID;
                req.TraderID = selectedBlock.TraderID;
                req.Symbol = selectedBlock.Symbol;
                req.QtyRequested = selectedBlock.QtyRequested;
                req.QtyAllocated = selectedBlock.QtyAllocated;
                req.Type = selectedBlock.Type;
                req.Side = selectedBlock.Side;
                req.StatusID = selectedBlock.StatusID;
                ServiceReference1.TraderFillServiceClient a = new ServiceReference1.TraderFillServiceClient();
                Console.WriteLine(a.GetData(req).QtyAllocated);
                Console.Read();
                MessageBox.Show("Block Sent");
            }
        }

        private bool SendToExchangePredicate(object obj)
        {
            return true;
        }

        private void EditBlockOrdersAction(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Please select a block to Edit");
            }
            else
            {
                Edit_Block_Order edit = new Edit_Block_Order(Convert.ToInt64(obj));

                var current = App.Current.MainWindow;
                App.Current.MainWindow = edit;

                current.Close();
                edit.Show();
            }
        }

        //Add To Existing Block Logic
        private void AddToExistingAction(object obj)
        {
            var checkedOrders = Order.Where(o => o.IsChecked).ToList();
            if(checkedOrders.Count==0)
            {
                MessageBox.Show("Please select Orders To Add");
            }
            else if (checkedOrders.Count != 0&&obj==null)
            {
                MessageBox.Show("Please select Block");
            }
            else
            {

            
            long blockid = (long)obj;
            var selectedBlockOrderlist = db.Orders.Where(o => o.BlockID == blockid).ToList();
            var firstBlockOrder = selectedBlockOrderlist[0];
            bool isValid = CheckValidation(checkedOrders);
            var checkedOrderFirstItem = checkedOrders[0];

            if (!isValid)
            {
                MessageBox.Show("Type or Side of Your Selected Orders doesn't match");
            }
            else if (isValid && (checkedOrderFirstItem.Order_Type != firstBlockOrder.Order_Type || checkedOrderFirstItem.Side != firstBlockOrder.Side))
            {
                MessageBox.Show("Type or Side  of Your Selected Orders doesn't match with the Block");
            }
            else
            {
                var block = db.Blocks.FirstOrDefault(o => o.BlockID == blockid);
                block.TotalQty += checkedOrders.Sum(o => o.TotalQty);
                block.UpdationDate = DateTime.Now;

                var blockInGrid = Block.FirstOrDefault(o => o.BlockID == blockid);
                if (blockInGrid != null)
                {
                    blockInGrid.TotalQty = block.TotalQty;
                }
                

                db.Entry(block).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                UpdateOrders(checkedOrders, blockid);

                MessageBox.Show("Order have been added to Block");
            }
            
            }
        }
        //Add To Existing Block Predicate
        private bool AddToExistingPredicate(object obj)
        {
            return true;
        }

        // CREATE NEW BLOCK COMMAND FUNCTIONS
        private void CreateNewBlockAction(object obj)
        {   
                var checkedOrders = Order.Where(o => o.IsChecked).ToList();

                if (checkedOrders.Count==0)
                {
                    MessageBox.Show("Please select an order !");
                    return;
                }

                // Validate
                bool isValid = CheckValidation(checkedOrders);

                if (!isValid)
                {
                    MessageBox.Show("Type or Side doesn't match");
                }
                else
                {
                    Block newBlock = CreateBlock(checkedOrders);

                    db.Entry(newBlock).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();

                    // Update Orders with new block id
                    UpdateOrders(checkedOrders, newBlock.BlockID);

                    //Update Order blotter
                    

                    // Add to Block blotter
                    Block.Add(BlockToCheckedBlockMapper.ToCheckedBlock(db.Blocks.First(o => o.BlockID == newBlock.BlockID)));
                    MessageBox.Show("Block Successfully Created!");

                }
        }

        private DataModel.Block CreateBlock(List<CheckedOpenOrder> checkedOrders)
        {
            Block newBlock = new Block();

            var firstOrder = checkedOrders[0];
            newBlock.CreationDate = System.DateTime.Now;
            newBlock.UpdationDate = System.DateTime.Now;
            newBlock.TotalQty = checkedOrders.Sum(o => o.TotalQty);
            newBlock.ExectuedQty = 0;

            if (firstOrder.LimitPrice != null)
            {
                newBlock.LimitPrice = Convert.ToDecimal(firstOrder.LimitPrice);
            }
            else { newBlock.LimitPrice = 0; }
            if (firstOrder.LimitPrice != null)
            {
                newBlock.StopPrice = Convert.ToDecimal(firstOrder.StopPrice);
            }
            else { newBlock.StopPrice = 0; }

            newBlock.BlockStatusID = db.Block_status.Where(o => o.StatusName == "New").Single().BlockStatusId;
            newBlock.Block_status = db.Block_status.Where(o => o.StatusName == "New").Single();
            newBlock.SymbolID = firstOrder.Symbol_Properties.SymbolID;
            newBlock.Symbol_Properties = firstOrder.Symbol_Properties;
            newBlock.UserID = firstOrder.User.UserID;

            // IMPORTANT Assign appropriate user
            newBlock.User = firstOrder.User;
            return newBlock;
        }

        private void UpdateOrders(List<CheckedOpenOrder> checkedOrders, long blockId)
        {
            var checkedOrderIDs = checkedOrders.Select(o => o.OrderID);
            var dbOrders = db.Orders.Where(order => checkedOrderIDs.Contains(order.OrderID));

            

            foreach (var item in dbOrders)
            {
                item.BlockID = blockId; // Db Orders
                checkedOrders.First(o => o.OrderID == item.OrderID).BlockID = blockId; // View Orders
                
                //var itemToRemove = checkedOrders.Single(o => o.IsChecked == true);
                //checkedOrders.Remove(itemToRemove);
                Order.Remove(Order.FirstOrDefault(o => o.BlockID == blockId));
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }

        private bool CheckValidation(List<CheckedOpenOrder> checkedOrders)
        {
            
            var firstOrder = checkedOrders[0];
            var firstOrderType = firstOrder.Order_Type;
            var firstOrderSide = firstOrder.Side;

            bool isValid = true;

            foreach (var item in checkedOrders)
            {
                if (item.Order_Type != firstOrderType || item.Side != firstOrderSide)
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        private bool CreaetNewBlockPredicte(object obj)
        {
            return true;
        }

        // VIEW BLOCK ORDER COMMAND FUNCTIONS
        private bool ViewBlockOrdersPredicate(object obj)
        {
            return true;
        }

        private void ViewBlockOrdersAction(object obj)
        {
            if (obj!=null)
            {
                long blockid = (long)obj;
                OrderInBlock.Clear();
                var list = db.Orders.Where(o => o.BlockID == blockid).ToList();
                foreach (var item in list)
                {
                    OrderInBlock.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Please select a block !");
            }
        }
    }
}
