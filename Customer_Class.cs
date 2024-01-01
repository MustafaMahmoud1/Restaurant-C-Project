using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}