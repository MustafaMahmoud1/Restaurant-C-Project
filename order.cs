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
        public int OrderId { get; set; }

        

        public List<int> ListItem { get; } = new List<int>();
        public order()
        {
            OrderId = 0;
            ListItem = null;
          
        }
      
        public void AddToOrder()
        {
            foreach (var item in ListItem)
            {
                ListItem.Add(item);
            }
        }
        public void RemoveFromOrder()
        {
            foreach (var item in ListItem)
            {
                ListItem.Remove(item);
            }
        }
        public void DeleteOrder()
        {
            ListItem.Clear();
        }
        public void ShowOrder()
        {
            foreach (var item in ListItem)
            {
                Console.WriteLine(item);
            }
        }
    }
       
}
