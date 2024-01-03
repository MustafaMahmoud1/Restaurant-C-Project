using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class Order
    {
        public int OrderId { get; set; }

        public int OrderPrice { get; set; }

        public List<OrderedItem> ListItem { get; } = new List<OrderedItem>();
        public Order()
        {
            OrderId = 0;
            ListItem = null;
          
        }
        //continue from here
        public void AddToOrder(OrderedItem ordereditem)
        {
            ListItem.Add(ordereditem);
        }
        public void RemoveFromOrder(OrderedItem orderedItem)
        {
            ListItem.Remove(orderedItem);
        }
        public void DeleteOrder()
        {
            ListItem.Clear();
        }
        public void ShowOrder(int OrderId, int ItemID, int Quantity, int Price)
        {
            foreach (var item in ListItem)
            { 
                Console.WriteLine(item);
            }
        }
        public void UpdateOrderPrice (int price)
        {

            int TotalPrice = 0; 
            TotalPrice = TotalPrice + price;
            OrderPrice = TotalPrice;
        }
    }
       
}
