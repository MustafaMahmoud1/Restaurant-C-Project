using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class Recipe
    {
        public List<ItemIngredient> recipe { get; set; }

        public void AddItemIngredint(int id, string quantity)
        {
            recipe.Add(new ItemIngredient
            { IngredientID = id, ItemIngredientQuantity = quantity });
        }
        public void RemoveItemIngredient(int deletedItemIngredient)
        {
            foreach (var x in recipe)
            {
                if (x.IngredientID == deletedItemIngredient)
                {
                    recipe.Remove(x);
                }
            }
        }
        public void ChangeItemIngredient(int IDtoChange, int NewItemIngredientID, string NewItemIngredientQuan)
        {
            foreach (var x in recipe)
            {
                if (x.IngredientID == IDtoChange)
                {
                    x.IngredientID = NewItemIngredientID;
                    x.ItemIngredientQuantity = NewItemIngredientQuan;
                }
            }

        }
    }
}
