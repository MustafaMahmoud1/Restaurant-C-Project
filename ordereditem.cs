using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project
{
    internal class ordereditem
    {
        public int itemID {  get; set; } 

        public int quantity {  get; set; }

        public ordereditem(int itemID , int quantity)
        {
            this.itemID = itemID;
            this.quantity = quantity;
        }
    }
}
