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
        public List<Order> ActiveOrders { get; set; }
        public List<Order> OrderHistory { get; set; }
        public List<Reservations> ActiveReservations { get; set; }
        public int Balance { get; set; }
        public Customer() { }

        public Customer(string Fullname, string Phonenumber, string Address)
        {
            List<Order> ActiveOrders = new List<Order> { };
            List<Order> OrderHistory = new List<Order> { };
            List<Reservations> activeReservations = new List<Reservations> { };
            Balance = 0;
            FullName = Fullname;
            PhoneNumber = Phonenumber;
            this.Address = Address;
        }
        public void GetCustomerData ()
        {
            Console.WriteLine(FullName);
            Console.WriteLine(PhoneNumber);
            Console.WriteLine( Address);
        }
        //waiting for confirmation on menu structure
        public void showMenu ()
        {
        }
        //waiting for diningtable class
        public string ShowTables ()
        {
            
        }
        // waiting for ordereditem
        public void CreateOrder ()
        {
            Console.WriteLine("May I take your order now?");
            List<int> PotentialOrderItemId = new List<int>();
            List<int> PotentialOrderQuantity = new List<int>();
            while (true)
            {
                Console.WriteLine("Please select an item from the menu above.");
                int IdInput = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the quantity you'd like to order.");
                int QuantityInput = int.Parse(Console.ReadLine());
                Order order = new Order();
                OrderedItem item = new OrderedItem(IdInput, QuantityInput);
                order.AddToOrder(item);
                order.UpdateOrderPrice();
                Console.WriteLine(@"Do you want to add more items?
                                    1: Yes, I'd like to add more items
                                    2: No, I want to procced with current order.");
                int OrderMore = int.Parse(Console.ReadLine());
                if (OrderMore == 2)
                {
                    break;
                }
            }


            }


        }

        public void addToBalance()
        { 
            Console.WriteLine($"Hi {FullName}, your account balance is currently at {Balance}. Consider adding more funds to avoid any issues.");
            int addedbalance = int.Parse(Console.ReadLine());
            Balance = Balance + addedbalance;
            Console.WriteLine($"Success! an amount of {addedbalance} has been added to your account.");
        }

        public string showNotification()
        {
            Console.WriteLine("");
        }

        public void showReservations()
        {
            foreach (var member in activeReservations)
            {
                if (activeReservation.Reservation.reservantName == fullName && activeReservation.Reservation.reservantPhone == phoneNumber)
                Console.WriteLine(activeReservation.Reservation.reserveTime + /n + activeReservation.Reservation.reservedTable);
            }
        }
    }
}