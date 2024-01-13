using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    public class OrderedItem
    {
        public int ItemID { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
        public List<int> ItemIdAndQuantities { get; set; }
        public List<int> ItemPrice { get; set; }

        public OrderedItem(int itemID, int quantity, int totalprice)
        {
            this.ItemID = itemID;
            this.Quantity = quantity;
            this.Price = totalprice;
        }
        public void CreateOrder(int ItemID, int Quantity)
        {
            ItemIdAndQuantities.AddRange(new List<int> { ItemID, Quantity });
            //foreach (var item in ItemIdAndQuantities)
            //{                                                  //i will show this list through another function [showOrderToWaiter()] to
            //    Console.WriteLine(item);                        display the list once after taking all orders
            //}
        }
        public void showOrderToWaiter()
        {
            foreach (var item in ItemIdAndQuantities)
            {
                Console.WriteLine(item);
            }
        }
  
        //public static void Printing(int orID)
        //{
        //    string json = File.ReadAllText(@"C:\Users\abdelrahman shalaby\Source\Repos\MustafaMahmoud1\Restaurant-C-Project\Order.json");
        //    OrderList = JsonConvert.DeserializeObject<List<Order>>(json);

        //    foreach (Order x in OrderList)
        //    {
        //        if (x.OrderId == orID)
        //            Console.WriteLine(x.OrderPrice);
        //        else
        //            Console.WriteLine("sorry, this order is not found");
        //    }
        //}
    }
}
