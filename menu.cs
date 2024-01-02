using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    public sealed class menu
    {

        List<Item> MenuItems = new List<Item>()
        {
            new Item
            {
                ItemName="Spaghetti Bolognese" , 
                ItemPrice=100 , 
                ItemID=1 , 
                description="Classic Italian dish with meat sauce", 
                category="pasta" ,
                recipe=new List<ItemIngredient>
                {
                     new ItemIngredient { IngredientID = 1, ItemIngredientQuantity = "500g" },
                    new ItemIngredient { IngredientID = 2, ItemIngredientQuantity  = "300g" },
                    new ItemIngredient { IngredientID = 3, ItemIngredientQuantity  = "1 cup" },
                    new ItemIngredient { IngredientID = 4, ItemIngredientQuantity  = "2 cloves" },
                    new ItemIngredient { IngredientID = 5, ItemIngredientQuantity  = "1 tsp" }
                }
            },
            new Item
            {
                
                ItemName = "Chicken Caesar Salad",
                ItemPrice = 9,
                ItemID = 2,
                description = "Fresh salad with grilled chicken and Caesar dressing",
                category = "Salad",
                recipe = new List<ItemIngredient>
                {
                    new ItemIngredient { IngredientID = 6, ItemIngredientQuantity = "300g" },
                    new ItemIngredient { IngredientID = 7, ItemIngredientQuantity = "1 head" },
                    new ItemIngredient { IngredientID = 8, ItemIngredientQuantity = "1 cup" },
                    new ItemIngredient { IngredientID = 9, ItemIngredientQuantity = "1/4 cup" },
                    new ItemIngredient { IngredientID = 10, ItemIngredientQuantity = "2 tbsp" }
                }
            },
            new Item
            {
                
                ItemName = "Chicken Caesar Salad",
                ItemPrice = 9,
                ItemID = 3,
                description = "Fresh salad with grilled chicken and Caesar dressing",
                category = "Salad",
                recipe = new List<ItemIngredient>
                {
                    new ItemIngredient { IngredientID = 5, ItemIngredientQuantity = "300g" },
                    new ItemIngredient { IngredientID = 6, ItemIngredientQuantity = "1 head" },
                    new ItemIngredient { IngredientID = 1, ItemIngredientQuantity = "1 cup" },
                    new ItemIngredient { IngredientID = 10, ItemIngredientQuantity = "1/4 cup" },
                    new ItemIngredient { IngredientID = 3, ItemIngredientQuantity = "2 tbsp" }
                }
            },
            new Item
            {
               
                ItemName = "Chicken Caesar Salad",
                ItemPrice = 9,
                 ItemID = 4,
                description = "Fresh salad with grilled chicken and Caesar dressing",
                category = "Salad",
                recipe = new List<ItemIngredient>
                {
                    new ItemIngredient { IngredientID = 9, ItemIngredientQuantity = "300g" },
                    new ItemIngredient { IngredientID = 6, ItemIngredientQuantity = "1 head" },
                    new ItemIngredient { IngredientID = 4, ItemIngredientQuantity = "1 cup" },
                    new ItemIngredient { IngredientID = 7, ItemIngredientQuantity = "1/4 cup" },
                    new ItemIngredient { IngredientID = 1, ItemIngredientQuantity = "2 tbsp" }
                }
            }
        };

        private menu() { }

        private static menu MyMenu;

        public static menu ckeck()
        {
            if (MyMenu == null)
                MyMenu = new menu();
            return MyMenu;
        }
        public void showItems()
        {
            foreach (var MenuItems in MenuItems)
            {
                Console.WriteLine($"item ID           : {MenuItems.ItemID}  ");
                Console.WriteLine($"item name         : {MenuItems.ItemName}  ");
                Console.WriteLine($"item price        : {MenuItems.ItemPrice}  ");
                Console.WriteLine($"item description  : {MenuItems.description}   ");
                Console.WriteLine($"item category     : {MenuItems.category}   ");
                Console.WriteLine("Recipe :");
                foreach( var Ingred in MenuItems.recipe)
                {
                    Console.WriteLine($"    Ingredient ID       : {Ingred.IngredientID}");
                    Console.WriteLine($"    Ingredient Quantity : {Ingred.ItemIngredientQuantity}");
                }
                Console.WriteLine();
                Console.WriteLine("******************************************************************");
            }
        }

         public void Showitemstocustomer()
 {
     foreach (var MenuItems in MenuItems)
     {
         Console.WriteLine($"item ID           : {MenuItems.ItemID}  ");
         Console.WriteLine($"item name         : {MenuItems.ItemName}  ");
         Console.WriteLine($"item price        : {MenuItems.ItemPrice}  ");
         Console.WriteLine($"item description  : {MenuItems.description}   ");
         Console.WriteLine($"item category     : {MenuItems.category}   ");
         Console.WriteLine("******************************************************************");
     }
 }
    
        public void AddItem(string NewItemName,int NewItemPrice ,int NewItemID ,string NewDescription)
        { 
            MenuItems.Add(new Item
            { ItemName = NewItemName, ItemPrice = NewItemPrice, ItemID = NewItemID, description = NewDescription });
        }

        public void RemoveItem(int deleteItemID)
        {
           foreach(var x in MenuItems)
            {
                if (x.ItemID == deleteItemID)
                {
                    MenuItems.Remove(x);
                }
            }
        }
    }
}
