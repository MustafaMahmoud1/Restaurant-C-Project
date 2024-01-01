using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Project
{
    internal interface IOrder
    {
        public void CreateOrder(List<int> ItemId, List<int> Quantities);
        public void ReserveTable(int TableNo, DateTime dateTime);
    }
}
