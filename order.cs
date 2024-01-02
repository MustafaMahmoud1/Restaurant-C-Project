using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    public class Order
    {
<<<<<<< HEAD
        public int orderid { get; set; }
        public int OrderPrice { get; set; }

        public List<OrderedItem> listitem { get; } = new List<OrderedItem>();
        public Order()
        {
            orderid = 0;
            listitem = null;
            OrderPrice = 0;
          
=======
        public int OrderId { get; set; }

        

        public List<int> ListItem { get; } = new List<int>();
        public order()
        {
            OrderId = 0;
            ListItem = null;
          
>>>>>>> 38d97c139af3fba3f5784c3233cbe3e9c82b4e98
        }
      
        public void AddToOrder()
        {
<<<<<<< HEAD
            foreach (var item in listitem)
            {
                listitem.Add(item);
=======
            foreach (var item in ListItem)
            {
                ListItem.Add(item);
>>>>>>> 38d97c139af3fba3f5784c3233cbe3e9c82b4e98
            }
        }
        public void RemoveFromOrder()
        {
<<<<<<< HEAD
            foreach (var item in listitem)
            {
                listitem.Remove(item);
=======
            foreach (var item in ListItem)
            {
                ListItem.Remove(item);
>>>>>>> 38d97c139af3fba3f5784c3233cbe3e9c82b4e98
            }
        }
        public void DeleteOrder()
        {
            ListItem.Clear();
        }
        public void ShowOrder()
        {
<<<<<<< HEAD
            foreach (var item in listitem)
=======
            foreach (var item in ListItem)
>>>>>>> 38d97c139af3fba3f5784c3233cbe3e9c82b4e98
            {
                Console.WriteLine(item);
            }
        }
        public void UpdateOrderPrice ()
        {

            int TotalPrice = 0; 
            foreach (var item in listitem)
            {
                TotalPrice = TotalPrice + item.Price;
            }
            OrderPrice = TotalPrice;
        }

    }
       
}
