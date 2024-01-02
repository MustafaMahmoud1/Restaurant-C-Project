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
        public int OrderId { get; set; }

        

        public List<int> ListItem { get; } = new List<int>();
        public List<int>ItemData { get; } = new List<int>();
        public order()
        {
            OrderId = 0;
            ListItem = null;
          
        }
      
        public void AddToOrder(int OrderId, List<int> ItemData)
        {
            int ItemId=int.Parse(Console.ReadLine());
            int Quantity=int.Parse(Console.ReadLine());
            int Price=int.Parse(Console.ReadLine());
            ItemData.AddRange(new List<int> { ItemId, Quantity, Price});
            ListItem.AddRange(new List<int> { OrderId});
            foreach (var item in ListItem)
            {
                foreach (var x in ItemData)
                {
                    ItemData.Add(x);
                }
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
