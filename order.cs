using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class order
    {
        public int OrderId { get; set; }

        public int OrderPrice { get; set; }

        public List<int> ListItem { get; } = new List<int>();
        public List<int>ItemData { get; } = new List<int>();
        public Order()
        {
            OrderId = 0;
            ListItem = null;
          
        }
        //continue from here
        public void AddToOrder(OrderedItem ordereditem)
        {

            OrderedItem.ItemID =int.Parse(Console.ReadLine());
            int Quantity=int.Parse(Console.ReadLine());
            int Price=int.Parse(Console.ReadLine());
            ItemData.AddRange(new List<int> { ItemId, Quantity, Price});
            ListItem.AddRange(new List<int> { OrderId});
            foreach (var item in ListItem)
            {
                ListItem.Add(item);
                foreach (var x in ItemData)
                {
                    ItemData.Add(x);
                }
                
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
        public void ShowOrder(int OrderId, int ItemID, int Quantity, int Price)
        {
            foreach (var item in ListItem)
            {
                foreach(var x in ItemData)
                {
                    Console.WriteLine(x);
                }
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
