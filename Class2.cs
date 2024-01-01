using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class Customer
    {
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public List<Order> activeOrders { get; set; }
        public List<Order> orderHistory { get; set; }
        public List<Reservation> activeReservations { get; set; }
        public int balance { get; set; }

        public Customer(string fullname, string phonenumber, string address)
        {
            List<Order> activeOrders = new List<Order>;
            List<Order> orderHistory = new List<Order>;
            List<Reservation> activeReservations = new List<Reservation>;
            balance = 0;
            fullName = fullname;
            phoneNumber = phonenumber;
            this.address = address;
        }



    }
}