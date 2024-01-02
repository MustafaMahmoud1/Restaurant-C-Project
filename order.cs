using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    public class Order
    {
        public int orderid { get; set; }
        public int OrderPrice { get; set; }

        public List<OrderedItem> listitem { get; } = new List<OrderedItem>();
        public Order()
        {
            orderid = 0;
            listitem = null;
            OrderPrice = 0;
          
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
        public void UpdateOrderPrice ()
        {

            int TotalPrice = 0; 
            foreach (var item in listitem)
            {
                TotalPrice = TotalPrice + item.Price;
            }
            OrderPrice = TotalPrice;
        }

    }
       
}
