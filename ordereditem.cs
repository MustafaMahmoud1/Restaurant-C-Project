using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class OrderedItem
    {
        public int ItemID { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
        public List<int> ItemIdAndQuantities { get; set; }
        public List<int> ItemPrice { get; set; }
        public ordereditem() { }

        public ordereditem(int itemID, int quantity)
        {
            this.ItemID = itemID;
            this.Quantity = quantity;
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
        public static void Printing(int orID)
        {
            WebRequest request = WebRequest.Create(@"C:\Users\abdelrahman shalaby\Source\Repos\MustafaMahmoud1\Restaurant-C-Project\Order.json");
            WebResponse response = request.GetResponse();
            using Stream datastream = response.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);
            string responsefromserver = reader.ReadToEnd();
            OrderList = JsonConvert.DeserializeObject<List<Order>>(responsefromserver);

            foreach (Order x in OrderList)
            {
                if (x.OrderId == orID)
                    Console.WriteLine(x.OrderPrice);
                else
                    Console.WriteLine("sorry, this order is not found");
            }
        }
    }
}
