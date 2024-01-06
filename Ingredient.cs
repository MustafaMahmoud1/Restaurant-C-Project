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
    public class Ingredient
    {

        public string IngredientName { get; set; }
        public int IngredientID { get; set; }
        public bool IngredientStatus { get; set; }
        public int IngredientQuantity { get; set; }

        public Ingredient()
        {
            this.IngredientName = "";
            this.IngredientID = 0;
            this.IngredientStatus = false;
            this.IngredientQuantity = 0;
        }
    }



}
