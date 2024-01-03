using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Restaurant_C__Project
{
    public sealed class Stock
    {
        public List<ingredients> IngredientsList = new List<ingredients>();
        //{
        //new ingredients
        //{IngredientID= 1 ,IngredientName="tomato", IngredientQuantity=100, IngredientStatus=true},
        //new ingredients
        //{IngredientID= 2 ,IngredientName="pomato", IngredientQuantity=100, IngredientStatus=false},
        //new ingredients
        //{IngredientID= 3 ,IngredientName="cheese", IngredientQuantity=100, IngredientStatus=true},
        //new ingredients
        //{IngredientID= 4 ,IngredientName="flour", IngredientQuantity=100, IngredientStatus=true},
        //new ingredients
        //{IngredientID= 5 ,IngredientName="pasta", IngredientQuantity=100, IngredientStatus=true},
        //new ingredients
        //{IngredientID= 6 ,IngredientName="rice", IngredientQuantity=100, IngredientStatus=true},
        //new ingredients
        //{IngredientID= 7 ,IngredientName="chicken", IngredientQuantity=100, IngredientStatus=true},
        //new ingredients
        //{IngredientID= 8 ,IngredientName="meat", IngredientQuantity=100, IngredientStatus=true},
        //new ingredients
        //{IngredientID= 9 ,IngredientName="lemon", IngredientQuantity=100, IngredientStatus=true},
        //new ingredients
        //{IngredientID= 10 ,IngredientName="fish", IngredientQuantity=100, IngredientStatus=true},
        //};

        private Stock() { }

        private static Stock MyStock;
        public static Stock Get_Instance()
        {
            if (MyStock == null)
                MyStock = new Stock();
            return MyStock;
        }

        //public void CheckAvailability(int CheckIngredientID)
        //{
        //    bool condition = false;
        //    foreach (var x in IngredientsList)
        //    {
        //        if (CheckIngredientID == x.IngredientID)
        //        {
        //            condition = true;
        //            //break;
        //            Console.WriteLine($"{x.IngredientName} is available by {x.IngredientQuantity}");
        //        }
        //    }
        //    if (condition == false)
        //    {
        //        Console.WriteLine("enter ingredient id and ingredient quantity");
        //        int ingredientID = int.Parse(Console.ReadLine());
        //        int quantity = int.Parse(Console.ReadLine());
        //        AddIngredient(ingredientID, true, quantity);
        //    }
        //}

        public static void LoadAllIngredientsFromJson(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                IngredientsList = JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }
        public static void SaveIngredientToFile(string jsonFilePath)
        {
            string json = JsonConvert.SerializeObject(IngredientsList, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
        public void ShowListOfIngredients()
        {
            foreach (var x in IngredientsList)
            {
                Console.WriteLine($"Ingredient ID        : {x.IngrdientID}");
                Console.WriteLine($"Ingredient Name      : {x.IngrdientName}");
                Console.WriteLine($"Ingredient Status    : {x.IngrdientStatus}");
                Console.WriteLine($"Ingredient Quantity  : {x.IngrdientQuantity}");
                Console.WriteLine("********************************************************");
            }
        }

        public void AddIngredient(int IngredientID, string IngredientName, int IngredientQuantity)
        {
            bool IsIngredientInStock = false;
            foreach (var x in IngredientsList)
            {
                if (IngredientID == x.IngredientID)
                    IsIngredientInStock = true;
                Console.WriteLine("this inredient is already in the stock");
            }
            if (IsIngredientInStock == false)
            {
                IngredientsList.Add(
                    new ingredients
                    {
                        x.IngredientID = IngredientID,
                        x.IngredientName = IngredientName,
                        x.IngredientStatus = true,
                        x.IngredientQuantity = IngredientQuantity
                    });
            }
        }

    }
}
