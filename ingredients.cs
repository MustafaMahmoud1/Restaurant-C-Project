using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class ingredients
    {

        public string IngredientName { get; set; }
        public int IngredientID { get; set; }
        public bool IngredientStatus { get; set; }
        public int IngredientQuantity { get; set; }

        /// <summary>
        /// JSON PART
        /// </summary>
        /// 


        //public void deserializ()
        //{
        //    string json = System.IO.File.ReadAllText(@"C:\Users\abdelrahman shalaby\Desktop\ingredients.json");

        //    ingredients Deserialized = JsonConvert.DeserializeObject<ingredients>(json);
        //    Console.WriteLine(Deserialized.IngredientID);

        //} 
        public ingredients() { }
        static List<ingredients> LoadIngredients(string filePath)
        {
            string jsonText = System.IO.File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<ingredients>>(jsonText);
        }
        public void LoadIngredient()
        {
            List<ingredients>LoadIngredients=new List<ingredients>();
            foreach (var item in LoadIngredients)
            {
                Console.WriteLine(LoadIngredients);
            }
        }
        public void RequestIngredients()
        {
            List<int> ReaquestIngredients = new List<int>();
            ReaquestIngredients.AddRange(new List<int> { IngredientID, IngredientQuantity });
            foreach (var item in ReaquestIngredients)
            {
                Console.WriteLine(item);
            }
        }
            //foreach (var x in Deserialized)
            //{
            //    Console.WriteLine(x.IngredientName);
            //    Console.WriteLine(x.IngredientID);
            //    Console.WriteLine(x.IngredientStatus);
            //    Console.WriteLine(x.IngredientQuantity);
            //}
        }

    

}
