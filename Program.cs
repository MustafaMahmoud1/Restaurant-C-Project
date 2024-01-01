using System.Transactions;
using System.Xml;
using Newtonsoft.Json;
namespace round2
{
    internal class Program
    {
        static void Main()
        {
            
            string jsonFilePath = "C:/Users/abdelrahman shalaby/Desktop/ingredients.json";

            List<ingredients> ingredients1 = LoadIngredients(jsonFilePath);

            Console.WriteLine("List of Ingredients:");

            foreach (var ingredient in ingredients1)
            {
                Console.WriteLine($"ID: {ingredient.IngredientID}");
                Console.WriteLine($"Name: {ingredient.IngredientName}");
                Console.WriteLine($"Status: {ingredient.IngredientStatus}");
                Console.WriteLine($"Quantity: {ingredient.IngredientQuantity}\n");
            }
        }

        static List<ingredients> LoadIngredients(string filePath)
        {
            string jsonText = System.IO.File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<ingredients>>(jsonText);
        }
    }
}
