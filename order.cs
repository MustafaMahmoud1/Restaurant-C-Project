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
        public double OrderPrice { get; set; }



        public List<OrderedItem> ListItem { get; } = new List<OrderedItem>();
        public List<Order> ItemData { get; } = new List<Order>();
        public static List<Order> OrderList = new List<Order> { };
        public Order()
        {
            OrderId = 0;
            ListItem = null;

        }
        public static void LoadAllOrderItemFromJson(string JsonFile)
        {
            string json = File.ReadAllText(JsonFile);
            OrderList = JsonConvert.DeserializeObject<List<Order>>(json);
        }
        public static void ShowOrdersList()
        {
            foreach(var x in OrderList)
            {
                Console.WriteLine($"order ID : {x.OrderId}");
                Console.WriteLine($"order ID : {x.OrderPrice}");
            }
            Console.WriteLine("*************************************");
        }

        //Done
        //public static void ShowOrdersList(string JsonFile)
        //{
        //    string json = File.ReadAllText(JsonFile);
        //    OrderList = JsonConvert.DeserializeObject<List<Order>>(json);

        //}
        //Done successfuly

        public void ModifyOrder(Order OrderWantoModify, ordereditem OrderDataToModify, Order OrderDataToModifydata)
        {
            foreach (var ExistOrder in OrderList)
            {
                if (ExistOrder == OrderWantoModify)
                {
                    ExistOrder.OrderId = OrderDataToModifydata.OrderId;
                    ExistOrder.OrderPrice = OrderDataToModifydata.OrderPrice;

                    foreach (var Item in ExistOrder.ListItem)
                    {
                        Item.ItemID = OrderDataToModify.ItemID;
                        Item.Price = OrderDataToModify.Price;
                        Item.Quantity = OrderDataToModify.Quantity;

                    }
                }
            }
        }
        //Done
        public void AddToOrder()
        {
            OrderList.Add(this);
        }
        //Done
        public void RemoveFromOrder(ordereditem item)
        {

            ListItem.Remove(item);

        }
        public void DeleteOrder()
        {
            ListItem.Clear();
        }
        /* public void ShowOrder(int OrderId, int ItemID, int Quantity, int Price)
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
        */
        public static void SaveOrderToJson(string JsonFile)
        {
            string json = JsonConvert.SerializeObject(OrderList, Formatting.Indented);
            File.WriteAllText(JsonFile, json);
        }
    }
       
}
