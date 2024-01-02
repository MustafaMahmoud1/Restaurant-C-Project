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
            foreach (var item in listitem)
            {
                listitem.Add(item);
            }
        }
        public void RemoveFromOrder()
        {
            foreach (var item in listitem)
            {
                listitem.Remove(item);
            }
        }
        public void DeleteOrder()
        {
            listitem.Clear();
        }
        public void ShowOrder()
        {
            foreach (var item in listitem)
            {
                Console.WriteLine(item);
            }
        }
    }
       
}
