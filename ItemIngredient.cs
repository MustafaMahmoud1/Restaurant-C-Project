using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    public class ItemIngredient
    {
        public int IngredientID { get; set; }
        public string ItemIngredientQuantity { get; set; }
        public ItemIngredient(int id, string quantity) 
        {
            IngredientID = id;
            ItemIngredientQuantity = quantity;
        }
    }

}
