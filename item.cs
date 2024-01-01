using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace round2
{
    internal class Item
    {
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int ItemID { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public bool availability { get; set; }
        public Recipe ItemRecipe { get; set; }   //class for recipe list

        //JSON PART

    }
}
