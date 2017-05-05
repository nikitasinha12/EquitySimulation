using Mock_Project.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Project.Traders.Models
{
    class ProposedBlockHelper
    {
        private IQueryable<DataModel.Order> unassignedOrderList;
        private Dictionary<string, TypeSymbolSideCombo> CombiDictionary { get; set; }

        public ProposedBlockHelper(IQueryable<DataModel.Order> unassignedOrderList)
        {
            CombiDictionary = new Dictionary<string, TypeSymbolSideCombo>();
            // Proposed Logic
            var types = unassignedOrderList.Select(o => o.Order_Type.OrderTypeName).Distinct();
            var symbols = unassignedOrderList.Select(o => o.Symbol_Properties.Symbol).Distinct();
            var sides = unassignedOrderList.Select(o => o.Side).Distinct();

            foreach (var type in types)
            {
                foreach (var symbol in symbols)
                {
                    foreach (var side in sides)
                    {
                        var combo =  new TypeSymbolSideCombo(type, symbol,side);
                        CombiDictionary.Add(combo.Key, combo);
                    }
                }
            }

            foreach (var combo in CombiDictionary)
            {
                foreach (var order in unassignedOrderList)
                {
                    if (combo.Value.Symbol == order.Symbol_Properties.Symbol && combo.Value.Side == order.Side && combo.Value.Type == order.Order_Type.OrderTypeName)
                    {
                        combo.Value.Count++;
                        combo.Value.Orders.Add(order);
                    }
                }
            }
        }

        private DataModel.Block CreateBlock(List<Order> orders)
        {
            Block newBlock = new Block();

            var firstOrder = orders[0];

            newBlock.CreationDate = System.DateTime.Now;
            newBlock.UpdationDate = System.DateTime.Now;
            newBlock.TotalQty = orders.Sum(o => o.TotalQty);
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

            newBlock.SymbolID = firstOrder.Symbol_Properties.SymbolID;
            newBlock.Orders = orders;

            // This Status ID is New
            newBlock.BlockStatusID = 5;

            // Change this
            newBlock.UserID = firstOrder.User.UserID;

            return newBlock;
        }

        public List<Block> GetProposedBlocks()
        {
            List<Block> blocks = new List<Block>();
            foreach (var combo in CombiDictionary)
            {
                if (combo.Value.Count > 1)
                {
                    var block = CreateBlock(combo.Value.Orders);
                    blocks.Add(block);
                }
            }

            return blocks;
        }

    }
}
