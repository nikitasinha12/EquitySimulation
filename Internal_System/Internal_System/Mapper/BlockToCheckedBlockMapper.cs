using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internal_System.DataModel;
using Internal_System.MapperModels;

namespace Internal_System.Mapper
{
    class BlockToCheckedBlockMapper
    {
        public static CheckedBlock ToCheckedBlock(Block block)
        {
            CheckedBlock checkedBlock = new CheckedBlock();

            
            checkedBlock.BlockID = block.BlockID;
            checkedBlock.UserID = block.UserID;
            checkedBlock.BlockStatusID = block.BlockStatusID;
            checkedBlock.LimitPrice = block.LimitPrice;
            checkedBlock.ExectuedQty = block.ExectuedQty;
            checkedBlock.TotalQty = block.TotalQty;
            checkedBlock.SymbolID = block.SymbolID;
            checkedBlock.StopPrice = block.StopPrice;
            checkedBlock.CreationDate = block.CreationDate;
            checkedBlock.UpdationDate = block.UpdationDate;
             
            checkedBlock.Block_status = block.Block_status;
            checkedBlock.Symbol_Properties = block.Symbol_Properties;
            checkedBlock.User = block.User;
            checkedBlock.Orders = block.Orders;
            return checkedBlock;
        }

        public static List<CheckedBlock> ToCheckedBlockList(List<Block> blockList)
        {
            List<CheckedBlock> list = new List<CheckedBlock>();
            foreach (var item in blockList)
            {
                list.Add(ToCheckedBlock(item));
            }

            return list;
        }

        public static List<Block> ToBlockList(List<CheckedBlock> checkedBlockList)
        {
            List<Block> list = new List<Block>();
            foreach (var item in checkedBlockList)
            {
                list.Add(ToBlock(item));
            }

            return list;
        }

        public static Block ToBlock(CheckedBlock checkedBlock)
        {
            Block block = new Block();

            
            block.BlockID = checkedBlock.BlockID;

            block.UserID = checkedBlock.UserID;
            block.BlockStatusID = checkedBlock.BlockStatusID;

            block.LimitPrice = checkedBlock.LimitPrice;
            block.ExectuedQty = checkedBlock.ExectuedQty;
            block.TotalQty = checkedBlock.TotalQty;

            block.SymbolID = checkedBlock.SymbolID;
            block.StopPrice = checkedBlock.StopPrice;
            block.CreationDate = checkedBlock.CreationDate;
            block.UpdationDate = checkedBlock.UpdationDate;

            block.Block_status = checkedBlock.Block_status;
            block.Symbol_Properties = checkedBlock.Symbol_Properties;
            block.User = checkedBlock.User;
            block.Orders = checkedBlock.Orders;
            return block;
        }
    }
}
