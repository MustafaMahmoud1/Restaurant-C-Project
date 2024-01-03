using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restaurant_C__Project
{
    public class Customer
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }

        public string UserPassword { get; set; }
        public List<Order> ActiveOrders { get; set; }
        public List<Order> OrderHistory { get; set; }
        public List<Reservations> ActiveReservations { get; set; }
        public int Balance { get; set; }
        public static List<Customer> AllCustomer = new List<Customer> { };
        public Customer() { }

        public Customer(string Fullname, string Phonenumber, string Address, string username, string password)
        {
            List<Order> ActiveOrders = new List<Order> { };
            List<Order> OrderHistory = new List<Order> { };
            List<Reservations> ActiveReservations = new List<Reservations> { };
            Balance = 0;
            FullName = Fullname;
            PhoneNumber = Phonenumber;
            this.Address = Address;
            UserName = username;
            UserPassword = password;
        }
        public void GetCustomerData ()
        {
            Console.WriteLine(FullName);
            Console.WriteLine(PhoneNumber);
            Console.WriteLine(Address);
        }
        //waiting for diningtable class
        //public string ShowTables ()
        //{
            
        //}
        // waiting for ordereditem
        public void CreateOrder ()
        {
            Console.WriteLine("May I take your order now?");
            Order order = new Order();
            while (true)
            {
                Console.WriteLine("Please select an item from the menu above.");
                int IdInput = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the quantity you'd like to order.");
                int QuantityInput = int.Parse(Console.ReadLine());
                OrderedItem item = new OrderedItem(IdInput, QuantityInput);
                order.AddToOrder(item);
                order.UpdateOrderPrice(item.Price);
                Console.WriteLine(@"Do you want to add more items?
                                    1: Yes, I'd like to add more items
                                    2: No, I want to procced with current order.");
                int OrderMore = int.Parse(Console.ReadLine());
                if (OrderMore == 2)
                {
                    break;
                }
            }
            if (Balance < order.OrderPrice)
            {
                Console.WriteLine(@"Sorry, you don't have enough funds to complete this order.
                                    Do you wish to top up?
                                     1: Yes, I want to top up and Process with my order.
                                     2: No, Cancel my order.");
                int TopUp = int.Parse(Console.ReadLine());
                if (TopUp == 1)
                {
                    addToBalance();
                    Console.WriteLine("Your order has been placed successfully.");
                    //ActiveOrders.Add(order);
                    Balance = Balance - order.OrderPrice;
                }
                else
                {
                    Console.WriteLine("Your order has been cancelled.");
                    order.DeleteOrder();
                }
            }
            else
            {
                Console.WriteLine("Your order has been placed successfully.");
                //ActiveOrders.Add(order);
                Balance = Balance - order.OrderPrice;
                ShowNotification("Order");
            }

            }


        public void addToBalance()
        { 
            Console.WriteLine($"Hi {FullName}, your account balance is currently at {Balance}. Consider adding more funds to avoid any issues.");
            int addedbalance = int.Parse(Console.ReadLine());
            Balance = Balance + addedbalance;
            Console.WriteLine($"Success! an amount of {addedbalance} has been added to your account.");
        }

        public void ShowNotification(string service)
        {
            switch (service)
            {
                case "Order":
                    Console.WriteLine("Thank you for your order from [Restaurant Name]! We're busy preparing your delicious food");
                    break;
                case "Reservation":
                    Console.WriteLine("Your table at [Restaurant Name] is waiting!");
                    break;
                default:
                    Console.WriteLine("Error: Invalid service.");
                    break;
            }
        }

        //public void showReservations()
        //{
        //    foreach (var member in ActiveReservations)
        //    {
        //        if (ActiveReservation.Reservation.reservantName == FullName && ActiveReservation.Reservation.reservantPhone == PhoneNumber)
        //        Console.WriteLine(ActiveReservation.Reservation.reserveTime 
        //                          + "\n" + ActiveReservation.Reservation.reservedTable);
        //    }
        //}
    }
}
