using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace round2
{
    public sealed class menu
    {
        List<Item> MenuItems = new List<Item>()
        {
            new Item
            {ItemName="pasta" , ItemPrice=100 , ItemID=1 , description="errkfjnejnerjgnejgnerjfnqerjne", availability=true , category="main dish" ,ItemRecipe r1 =new Recipe() },
            new Item
            {ItemName="pasta" , ItemPrice=100 , ItemID=1 , description="errkfjnejnerjgnejgnerjfnqerjne", availability=true , category="main dish" , ItemRecipe},
             new Item
            {ItemName="pasta" , ItemPrice=100 , ItemID=1 , description="errkfjnejnerjgnejgnerjfnqerjne", availability=true , category="main dish" , ItemRecipe},
              new Item
            {ItemName="pasta" , ItemPrice=100 , ItemID=1 , description="errkfjnejnerjgnejgnerjfnqerjne", availability=true , category="main dish" , ItemRecipe},
               new Item
            {ItemName="pasta" , ItemPrice=100 , ItemID=1 , description="errkfjnejnerjgnejgnerjfnqerjne", availability=true , category="main dish" , ItemRecipe},
        };

        private menu(){}

        private static menu MyMenu;

        public static menu ckeck()
        {
            if (MyMenu == null)
                MyMenu = new menu();
            return MyMenu;
        }
        public void showItems()
        {
            foreach (var x in MenuItems)
            {
                Console.Write($"item name {x.ItemName}  ");
                Console.Write($"item name {x.ItemPrice}  ");
                Console.Write($"item name {x.ItemID}  ");
                Console.Write($"item name {x.description}   ");
                Console.WriteLine();
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
