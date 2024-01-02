using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class Item
    {
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int ItemID { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public bool availability { get; set; }
        public List<ItemIngredient> recipe { get; set; }
       

        //JSON PART

    }
}
