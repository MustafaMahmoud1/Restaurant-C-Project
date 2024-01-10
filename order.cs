using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
Newtonsoft.Json;

namespace Restaurant_C__Project
{
    internal class Order
    {
        public static List<Order> ActiveOderList = new List<Order>();

        public static List<Order> OrderList = new List<Order>();

        public static List<Order> WaitingOrderList = new List<Order>();

        public int OrderId { get; set; }

        public double OrderPrice { get; set; }

        public string CustomerId { get; set; }

        public List<OrderItem> ListItem { get; } = new List<OrderItem>();
        public Order()
        {
            OrderId = 0;
            ListItem = null;

        }


        //Parametarize constructor
        public Order(List<OrderItem> Items)
        {
            Random R = new Random();
            OrderId = R.Next();
            //OrderId = OrderId;
            ListItem = Items;
            double TotalPrice = 0.0;
            foreach (OrderItem x in ListItem)
            {
                TotalPrice += (double)(x.Quantity * x.Price);
            }
            OrderPrice = TotalPrice;
        }
        //function to create order
        public void CreateOrder()
        {
            Menu.GetInstance().LoadAllItemsFromJson(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\Menu.json");
            Menu.GetInstance().Showitemstocustomer();
            Console.WriteLine("Please chosse Item Id");
            int Item = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Inter The Quentity");
            int Quentity = int.Parse(Console.ReadLine());
            foreach (Item item in Menu.AllItems)
            {
                if (item.ItemID == Item)
                {
                    OrderItem orderitem = new OrderItem(Item, Quentity, item.ItemPrice);
                    ListItem.Add(orderitem);
                }
            }
            Order order = new Order(ListItem);
            ShowOrdersList(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\Order.json")
            ShowActiveOrdersList(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\ActiveOrder.json");
            AddToOrderList(order);
            Console.WriteLine("Order Created Successfully");
            SaveOrderToJson(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\Order.json");
            SaveActiveOrderToJson(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\ActiveOrder.json");
        }

        public static void AddToOrderList(Order order)
        {
            if (ActiveOderList.Count < 10)
            {
                OrderList.Add(order);
                ActiveOderList.Add(order);
                return;
            }
            else
            {
                ShowWaitingOrderList(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\WaitingOrders.json");

                WaitingOrderList.Add(order);
                SaveOrderToWaitingJson(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\WaitingOrders.json");
            }

        }


        //load active orders from json
        public static void ShowActiveOrdersList(string JsonFile)
        {
            string json = File.ReadAllText(JsonFile);
            ActiveOderList = JsonConvert.DeserializeObject<List<Order>>(json);

        }
        //function to show all Active Orders
        public static void LoadAllActiveOrder()
        {
            Console.WriteLine("All Active Oders Oders ");
            foreach (var x in ActiveOderList)
            {
                Console.WriteLine("Oder Id:   " + x.OrderId);
                foreach (OrderItem y in x.ListItem)
                {
                    Console.WriteLine("Item Id:   " + y.ItemId);
                    Console.WriteLine("Item Quentity:   " + y.Quantity);
                    Console.WriteLine("Item Price:   " + y.Price);
                }
                Console.WriteLine("Order Total Price:   " + x.OrderPrice);

            }
        }
        public static void ShowWaitingOrderList(string JsonFile)
        {
            WebRequest reque = WebRequest.Create(JsonFile);
            WebResponse respon = reque.GetResponse();
            using Stream datastre = respon.GetResponseStream();
            StreamReader read = new StreamReader(datastre);
            string responsefromserv = read.ReadToEnd();
            WaitingOrderList = JsonConvert.DeserializeObject<List<Order>>(responsefromserv);

        }
        ////////
        public static void ShowOrdersList(string JsonFile)
        {
            WebRequest request = WebRequest.Create(JsonFile);
            WebResponse response = request.GetResponse();
            using Stream datastream = response.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);
            string responsefromserver = reader.ReadToEnd();
            OrderList = JsonConvert.DeserializeObject<List<Order>>(responsefromserver);
            foreach (Order x in OrderList)
            {
                Console.WriteLine(x.OrderId);
                Console.WriteLine(x.OrderPrice);
                Console.WriteLine(x.CustomerId);
                foreach (OrderItem y in x.ListItem)
                {
                    Console.WriteLine(y.ItemId);
                    Console.WriteLine(y.Quantity);
                    Console.WriteLine(y.Price);
                }
            }

        }

        public void RemoveItemFromOrder(int OrderId, int ItemId)
        {
            foreach (Order x in OrderList)
            {
                if (x.OrderId != OrderId)
                {
                    continue;
                }
                foreach (OrderItem y in x.ListItem)
                {
                    if (y.ItemId == ItemId)
                    {
                        ListItem.Remove(y);
                        Console.WriteLine("sucssesfully removed");
                        x.OrderPrice -= y.Price * y.Quantity;
                        Console.WriteLine(x.OrderPrice);
                    }
                }
            }
        }


        public void ClearOrderList()
        {
            OrderList.Clear();
            Console.WriteLine("All Orders removed sucssesfully");
        }
        //Delete Order From Order List
        public void DeleteOrderFromOrderList(int OrderIdToDelete)
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
        public static void RemoveFromActiveList(int OrderId)
        {

            ShowActiveOrdersList(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\ActiveOrder.json");

            foreach (Order order in ActiveOderList)
            {
                if (order.OrderId == OrderId)
                {
                    ActiveOderList.Remove(order);
                    SaveActiveOrderToJson(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\ActiveOrder.json");


                    ShowWaitingOrderList(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\WaitingOrders.json");
                    ShowActiveOrdersList(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\ActiveOrder.json");
                    ShowOrdersList(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\Order.json");

                    if (WaitingOrderList != null)
                    {
                        for (int j = 0; j < WaitingOrderList.Count; j++)
                        {
                            if (ActiveOderList.Count < 10)
                            {


                                AddToOrderList(WaitingOrderList[j]);
                                WaitingOrderList.Remove(WaitingOrderList[j]);
                                Console.WriteLine("New Order From Waiting List");
                                SaveActiveOrderToJson(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\ActiveOrder.json");

                                SaveOrderToJson(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\Order.json");
                                SaveOrderToWaitingJson(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\WaitingOrders.json");
                            }

                        }
                        //ActiveOderList[ActiveOderList.Count - 1] = WaitingOrderList[0];

                        Console.WriteLine("Rmoved done succseefully");
                    }




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



    }

}
