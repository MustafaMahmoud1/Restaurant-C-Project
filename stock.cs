using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restaurant_C__Project
{
     internal sealed class stock
    {
        public List<ingredients> IngredientsList = new List<ingredients>() {
        new ingredients
        {IngredientID= 1 ,IngredientName="tomato", IngredientQuantity=100, IngredientStatus=true},
        new ingredients
        {IngredientID= 2 ,IngredientName="pomato", IngredientQuantity=100, IngredientStatus=false},
        new ingredients
        {IngredientID= 3 ,IngredientName="cheese", IngredientQuantity=100, IngredientStatus=true},
        new ingredients
        {IngredientID= 4 ,IngredientName="flour", IngredientQuantity=100, IngredientStatus=true},
        new ingredients
        {IngredientID= 5 ,IngredientName="pasta", IngredientQuantity=100, IngredientStatus=true},
        new ingredients
        {IngredientID= 6 ,IngredientName="rice", IngredientQuantity=100, IngredientStatus=true},
        new ingredients
        {IngredientID= 7 ,IngredientName="chicken", IngredientQuantity=100, IngredientStatus=true},
        new ingredients
        {IngredientID= 8 ,IngredientName="meat", IngredientQuantity=100, IngredientStatus=true},
        new ingredients
        {IngredientID= 9 ,IngredientName="lemon", IngredientQuantity=100, IngredientStatus=true},
        new ingredients
        {IngredientID= 10 ,IngredientName="fish", IngredientQuantity=100, IngredientStatus=true},
        };

        private stock() { }

        private static stock MyStock;
        public static stock ckeck()
        {
            if (MyStock == null)
                MyStock = new stock();
            return MyStock;
        }

        public void CheckAvailability(int CheckIngredientID)
        {
            bool condition = false;
            foreach(var x in IngredientsList)
            {
                if (CheckIngredientID == x.IngredientID)
                {
                    condition = true;
                    //break;
                    Console.WriteLine($"{x.IngredientName} is available by {x.IngredientQuantity}");
                }
            }
            if (condition == false)
            {
                Console.WriteLine("enter ingredient id and ingredient quantity");
                int ingredientID = int.Parse(Console.ReadLine());
                int quantity = int.Parse(Console.ReadLine());
                AddIngredient(ingredientID, true, quantity);
            }
        }
        public void AddIngredient(int IngredientID, bool IngredientStatus, int IngredientQuantity)
        {
            foreach (var x in IngredientsList)
            {
                if (IngredientID == x.IngredientID)
                {
                    x.IngredientID = IngredientID;
                   x.IngredientStatus = true;
                   x.IngredientQuantity = IngredientQuantity;
                }
            }
          
        }
    }
}
