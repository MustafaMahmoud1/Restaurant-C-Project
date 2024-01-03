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
        private static Stock MyStock;

        private static List<ingredients> IngredientsList = new List<ingredients>();
        private Stock() { }
        public static Stock Get_Instance()
        {
            if (MyStock == null)
                MyStock = new Stock();
            return MyStock;
        }



        public static void LoadAllIngredientsFromJson(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                IngredientsList = JsonConvert.DeserializeObject<List<ingredients>>(json);
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
                Console.WriteLine($"Ingredient ID        : {x.IngredientID}");
                Console.WriteLine($"Ingredient Name      : {x.IngredientName}");
                Console.WriteLine($"Ingredient Status    : {x.IngredientStatus}");
                Console.WriteLine($"Ingredient Quantity  : {x.IngredientQuantity}");
                Console.WriteLine("********************************************************");
            }
        }
        public void CheckAvailability(int CheckIngredientID)
        {
            bool condition = false;
            foreach (var x in IngredientsList)
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
                Console.WriteLine("enter ingredient id , ingredient name and ingredient quantity");
                int ingredientID = int.Parse(Console.ReadLine());
               string ingredientname = Console.ReadLine();
                int quantity = int.Parse(Console.ReadLine());
                AddIngredient(ingredientID, ingredientname, quantity);
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
                    new ingredients {IngredientID = IngredientID, IngredientName = IngredientName,IngredientStatus = true,
                        IngredientQuantity = IngredientQuantity
                    });
            }
        }


    }
}
