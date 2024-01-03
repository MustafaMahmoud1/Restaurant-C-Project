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
    public class ingredients
    {

        public string IngredientName { get; set; }
        public int IngredientID { get; set; }
        public bool IngredientStatus { get; set; }
        public int IngredientQuantity { get; set; }

        //public void LoadIngredient()
        //{
        //    List<ingredients> LoadIngredients = new List<ingredients>();
        //    foreach (var item in LoadIngredients)
        //    {
        //        Console.WriteLine(LoadIngredients);
        //    }
        //}
        public void RequestIngredients()
        {
            List<int> ReaquestIngredients = new List<int>();
            ReaquestIngredients.AddRange(new List<int> { IngredientID, IngredientQuantity });
            foreach (var item in ReaquestIngredients)
            {
                Console.WriteLine(item);
            }
        }
    }



}
