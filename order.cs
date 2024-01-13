using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restaurant_C__Project
{
    public class Order
    {
        public static List<Order> ActiveOderList = new List<Order>();

        public static List<Order> OrderList = new List<Order>();

        public static List<Order> WaitingOrderList = new List<Order>();

        public int OrderId { get; set; }
        public double OrderPrice { get; set; }
        public string CustomerId { get; set; }

        public List<OrderedItem> ListItem { get; set; } = new List<OrderedItem>();
        public Order(double orderPrice, string customerid, List<OrderedItem> items)
        {
            Random rnd = new Random();
            OrderId = rnd.Next(1, 10000000);
            OrderPrice = orderPrice;
            CustomerId = customerid;
            ListItem = items;
        }

        //function to create order
        //public static void CreateOrder()
        //{
        //    Menu.GetInstance().LoadAllItemsFromJson(@"C:\Users\abdelrahman shalaby\Source\Repos\MustafaMahmoud1\Restaurant-C-Project\Menu.json");
        //    Menu.GetInstance().Showitemstocustomer();
        //    Console.WriteLine("Please chosse Item Id");
        //    int Item = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Please Inter The Quentity");
        //    int Quentity = int.Parse(Console.ReadLine());
        //    foreach (Item item in Menu.GetInstance().AllItems)
        //    {
        //        if (item.ItemID == Item)
        //        {
        //            OrderItem orderitem = new OrderItem(Item, Quentity, item.ItemPrice);
        //            ListItem.Add(orderitem);
        //        }
        //    }
        //    Order order = new Order(ListItem);
        //    ShowOrdersList(@"D:\C# Projects\Restaurant C# Project\Order.json");
        //    ShowActiveOrdersList(@"D:\C# Projects\Restaurant C# Project\ActiveOrder.json");
        //    AddToOrderList(order);
        //    Console.WriteLine("Order Created Successfully");
        //    SaveOrderToJson(@"D:\C# Projects\Restaurant C# Project\Order.json");
        //    SaveActiveOrderToJson(@"D:\C# Projects\Restaurant C# Project\ActiveOrder.json");
        //}

        public void AddToOrderList()
        {
            if (ActiveOderList.Count < 10)
            {
                LoadAllOrders(@"D:\C# Projects\Restaurant C# Project\Order.json");
                LoadAllActiveOrders(@"D:\C# Projects\Restaurant C# Project\ActiveOrder.json");
                OrderList.Add(order);
                ActiveOderList.Add(order);
                SaveOrderToJson(@"D:\C# Projects\Restaurant C# Project\Order.json");
                SaveActiveOrderToJson(@"D:\C# Projects\Restaurant C# Project\ActiveOrder.json");
                return;
            }
            else
            {
                LoadAllWaitingOrders(@"D:\C# Projects\Restaurant C# Project\WaitingOrders.json");
                WaitingOrderList.Add(order);
                SaveOrderToWaitingJson(@"D:\C# Projects\Restaurant C# Project\WaitingOrders.json");
            }

        }



        //function to show all Active Orders
        //public static void LoadAllActiveOrder()
        //{
        //    Console.WriteLine("All Active Oders Oders ");
        //    foreach (var x in ActiveOderList)
        //    {
        //        Console.WriteLine("Oder Id:   " + x.OrderId);
        //        foreach (OrderItem y in x.ListItem)
        //        {
        //            Console.WriteLine("Item Id:   " + y.ItemId);
        //            Console.WriteLine("Item Quentity:   " + y.Quantity);
        //            Console.WriteLine("Item Price:   " + y.Price);
        //        }
        //        Console.WriteLine("Order Total Price:   " + x.OrderPrice);

        //    }
        //}
        //public static void ShowWaitingOrderList(string JsonFile)
        //{
        //    WebRequest reque = WebRequest.Create(JsonFile);
        //    WebResponse respon = reque.GetResponse();
        //    using Stream datastre = respon.GetResponseStream();
        //    StreamReader read = new StreamReader(datastre);
        //    string responsefromserv = read.ReadToEnd();
        //    WaitingOrderList = JsonConvert.DeserializeObject<List<Order>>(responsefromserv);

        //}
        ////////
        //public static void ShowOrdersList(string JsonFile)
        //{
        //    WebRequest request = WebRequest.Create(JsonFile);
        //    WebResponse response = request.GetResponse();
        //    using Stream datastream = response.GetResponseStream();
        //    StreamReader reader = new StreamReader(datastream);
        //    string responsefromserver = reader.ReadToEnd();
        //    OrderList = JsonConvert.DeserializeObject<List<Order>>(responsefromserver);
        //    foreach (Order x in OrderList)
        //    {
        //        Console.WriteLine(x.OrderId);
        //        Console.WriteLine(x.OrderPrice);
        //        Console.WriteLine(x.CustomerId);
        //        foreach (OrderItem y in x.ListItem)
        //        {
        //            Console.WriteLine(y.ItemId);
        //            Console.WriteLine(y.Quantity);
        //            Console.WriteLine(y.Price);
        //        }
        //    }

        //}

        //public static void RemoveItemFromOrder(int OrderId, int ItemId)
        //{
        //    foreach (Order x in OrderList)
        //    {
        //        if (x.OrderId == OrderId)
        //        {
        //            foreach (OrderItem y in x.ListItem)
        //            {
        //                if (y.ItemId == ItemId)
        //                {
        //                    ListItem.Remove(y);
        //                    Console.WriteLine("sucssesfully removed");
        //                    x.OrderPrice -= y.Price * y.Quantity;
        //                    Console.WriteLine(x.OrderPrice);
        //                }
        //            }
        //        }

        //    }
        //}


        public static void ClearOrderList()
        {
            OrderList.Clear();
            Console.WriteLine("All Orders removed sucssesfully");
        }
        //Delete Order From Order List
        public static void DeleteOrderFromOrderList(int OrderIdToDelete)
        {
            foreach (Order Order in OrderList)
            {
                if (Order.OrderId == OrderIdToDelete)
                {
                    OrderList.Remove(Order);
                }
            }
        }/*
 public static void RemoveFromActiveList()
 {
     ShowActiveOrdersList(@"C:\\Users\\M&M\\source\\repos\\resturant\\ActiveOrder.json");
    

         ActiveOderList.Remove(ActiveOderList[ActiveOderList.Count-1]);
     SaveActiveOrderToJson(@"C:\\Users\\M&M\\source\\repos\\resturant\\ActiveOrder.json");
     ShowWaitingOrderList(@"C:\\Users\\M&M\\source\\repos\\resturant\\WaitingOrders.json");
     if (WaitingOrderList != null)

             {
                 
             //ActiveOderList[ActiveOderList.Count - 1] = WaitingOrderList[0];
                 
         ShowOrdersList(@"C:\\Users\\M&M\\source\\repos\\resturant\\Order.Json");
                 
                 AddToOrderList(WaitingOrderList[0]);
                 WaitingOrderList.Remove(WaitingOrderList[0]);
                 Console.WriteLine("New Order From Waiting List");
         SaveOrderToJson(@"C:\\Users\\M&M\\source\\repos\\resturant\\Order.Json");
         SaveOrderToWaitingJson(@"C:\Users\M&M\source\repos\resturant\WaitingOrders.json");
             }
         Console.WriteLine("Rmoved done succseefully");

     
 }*/
        //Remove Order from active orders then take waiting orders if exist
        public static void FinishAnOrder(int OrderId)
        {
            LoadAllActiveOrders(@"D:\C# Projects\Restaurant C# Project\ActiveOrder.json");
            LoadAllOrders(@"D:\C# Projects\Restaurant C# Project\Order.json");
            foreach (Order order in ActiveOderList)
            {
                if (order.OrderId == OrderId)
                {
                    ActiveOderList.Remove(order);
                    OrderList.Remove(order);
                    LoadAllWaitingOrders(@"D:\C# Projects\Restaurant C# Project\WaitingOrders.json");
                    if (WaitingOrderList.Count != 0)
                    {
                        ActiveOderList.Add(WaitingOrderList[0]);
                        OrderList.Add(WaitingOrderList[0]);
                        WaitingOrderList.Remove(WaitingOrderList[0]);
                    }
                    SaveActiveOrderToJson(@"D:\C# Projects\Restaurant C# Project\ActiveOrder.json");
                    SaveOrderToJson(@"D:\C# Projects\Restaurant C# Project\Order.json");
                    SaveOrderToWaitingJson(@"D:\C# Projects\Restaurant C# Project\WaitingOrders.json");
                    return;
                }




            }
        }
        //--------------save all listes to jsons files-------------------//
        //1-active order json
        public static void SaveActiveOrderToJson(string JsonFile)
        {
            string json = JsonConvert.SerializeObject(ActiveOderList, Formatting.Indented);
            File.WriteAllText(JsonFile, json);
        }
        //2-all orders in json
        public static void SaveOrderToJson(string JsonFile)
        {
            string json = JsonConvert.SerializeObject(OrderList, Formatting.Indented);
            File.WriteAllText(JsonFile, json);
        }
        //3-waiting order json
        public static void SaveOrderToWaitingJson(string JsonFile)
        {
            string json = JsonConvert.SerializeObject(WaitingOrderList, Formatting.Indented);
            File.WriteAllText(JsonFile, json);
        }
        //4-Load all orders from json
        public static void LoadAllOrders(string JsonFile)
        {
            string json = File.ReadAllText(JsonFile);
            OrderList = JsonConvert.DeserializeObject<List<Order>>(json);
        }
        //5-Load all waiting orders from json
        public static void LoadAllWaitingOrders(string JsonFile)
        {
            string json = File.ReadAllText(JsonFile);
            WaitingOrderList = JsonConvert.DeserializeObject<List<Order>>(json);
        }
        //6-Load all active orders from json
        public static void LoadAllActiveOrders(string JsonFile)
        {
            string json = File.ReadAllText(JsonFile);
            ActiveOderList = JsonConvert.DeserializeObject<List<Order>>(json);
        }

        /// <summary>
        /// //////////////////////////////////////////////////
        /// </summary>
        
        public static void ShowOrdersList()
        {
            foreach (var Order in OrderList)
            {
                Console.WriteLine($"Order ID : {Order.OrderId}");
                Console.WriteLine($"Order Price : {Order.OrderPrice}");
                Console.WriteLine($"Customer ID : {Order.CustomerId}");
                Console.WriteLine("Items :");
                foreach (var Item in Order.ListItem)
                {
                    Console.WriteLine($"Item ID : {Item.ItemID}");
                    Console.WriteLine($"Item Price : {Item.Price}");
                    Console.WriteLine($"Item Quantity : {Item.Quantity}");
                }
                Console.WriteLine("******************************************************************");
            }
        }
        public static void ShowActiveOrdersList()
        {
            foreach (var Order in ActiveOderList)
            {
                Console.WriteLine($"Order ID : {Order.OrderId}");
                Console.WriteLine($"Order Price : {Order.OrderPrice}");
                Console.WriteLine($"Customer ID : {Order.CustomerId}");
                Console.WriteLine("Items :");
                foreach (var Item in Order.ListItem)
                {
                    Console.WriteLine($"Item ID : {Item.ItemID}");
                    Console.WriteLine($"Item Price : {Item.Price}");
                    Console.WriteLine($"Item Quantity : {Item.Quantity}");
                }
                Console.WriteLine("******************************************************************");
            }
        }
        public static void ShowWaitingOrdersList()
        {
            foreach (var Order in WaitingOrderList)
            {
                Console.WriteLine($"Order ID : {Order.OrderId}");
                Console.WriteLine($"Order Price : {Order.OrderPrice}");
                Console.WriteLine($"Customer ID : {Order.CustomerId}");
                Console.WriteLine("Items :");
                foreach (var Item in Order.ListItem)
                {
                    Console.WriteLine($"Item ID : {Item.ItemID}");
                    Console.WriteLine($"Item Price : {Item.Price}");
                    Console.WriteLine($"Item Quantity : {Item.Quantity}");
                }
                Console.WriteLine("******************************************************************");
            }
        }

    }
}
