
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class Cashier : Employee
    {
        public Cashier(string EmpName, int EmpSalary, string PhoneNumber, string EmployeeAdress, string UserName, string UserPassword, string UserRole) : base(EmpName, EmpSalary, PhoneNumber, EmployeeAdress, UserName, UserPassword, UserRole)
        {

        }
        //print an order invoice
        public static void PrintInvoice(int OrderId)
        {
            Order.LoadAllOrders(@"D:\C# Projects\Restaurant C# Project\Order.json");
            foreach (var item in Order.OrderList)
            {
                if (item.OrderId == OrderId)
                {
                    Console.WriteLine("Order Price: " + item.OrderPrice);
                    Console.WriteLine("Order Items: ");
                    foreach (var item2 in item.ListItem)
                    {
                        Menu.LoadAllItemsFromJson(@"D:\C# Projects\Restaurant C# Project\Item.json");
                        Console.WriteLine("Item Name: " + Menu.GetInstance().GetItemName(item2.ItemID));
                        Console.WriteLine("Item Quantity: " + item2.Quantity);
                        Console.WriteLine("Item Price: " + item2.Price);
                    }
                }
            }
        }
    }
}
