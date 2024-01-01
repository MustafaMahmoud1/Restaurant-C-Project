using round2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restaurant_C__Project
{
    internal class Customer
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<Order> activeOrders { get; set; }
        public List<Order> orderHistory { get; set; }
        public List<Reservation> activeReservations { get; set; }
        public int balance { get; set; }
        public Customer() { }

        public Customer(string Fullname, string Phonenumber, string Address)
        {
            List<Order> activeOrders = new List<Order>;
            List<Order> orderHistory = new List<Order>;
            List<Reservation> activeReservations = new List<Reservation>;
            balance = 0;
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
        public string showMenu ()
        {
            menu.ckeck().
        }
        //waiting for diningtable class
        public string showTables ()
        {
            
        }
        // waiting for ordereditem
        public void createOrder ()
        {
            Console.WriteLine();
        }

        public void addToBalance ()
        { 
            Console.WriteLine($"Hi {fullName}, your account balance is currently at {balance}. Consider adding more funds to avoid any issues.");
            int addedbalance = int.Parse(Console.ReadLine());
            balance = balance + addedbalance;
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