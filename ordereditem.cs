﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project
{
    internal class ordereditem
    {
        public int ItemID {  get; set; } 

        public int Quantity {  get; set; }
        public int Price { get; set; }
        public List<int>ItemIdAndQuantities { get; set; }
        public List<int> ItemPrice { get; set; }
        public ordereditem() { }

        public ordereditem(int itemID , int quantity)
        {
            this.ItemID = itemID;
            this.Quantity = quantity;
        }
        public void CreateOrder (int ItemID, int Quantity)
        {
            ItemIdAndQuantities.AddRange(new List<int> {ItemID,Quantity});
            foreach (var item in ItemIdAndQuantities)
            {
                Console.WriteLine(item);
            }
        }
        public void Printing(int ItemID, int Quantity, int Price)
        {
            ItemPrice.AddRange(new List<int> { ItemID, Quantity,Price });
            int TotalPrice = 0;
            foreach (var item in ItemPrice)
            {
                TotalPrice += Quantity * Price;
                Console.WriteLine(item + "Total Price is " + TotalPrice);
            }


        }
    }
}
