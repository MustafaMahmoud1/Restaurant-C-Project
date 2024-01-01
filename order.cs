using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project
{
    internal class order
    {
        public int orderid { get; set; }

        

        public List<int> listitem { get; } = new List<int>();
        public order()
        {
            orderid = 0;
            listitem = null;
          
        }
        public void AddToOrder()
        {
            listitem.Add(orderid);
        }
        public void RemoveFromOrder()
        {
            listitem.Remove(orderid);
        }
        public void DeleteOrder()
        {
            listitem.Clear();
        }
    }
       
}
