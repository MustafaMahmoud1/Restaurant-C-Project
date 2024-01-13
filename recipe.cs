using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restaurant_C__Project
{
    internal class Recipe
    {
        public List<ItemIngredient> recipe { get; set; }
        public List<ItemIngredient> AllItems { get; set; }

        public static void LoadAllItemsFromJson(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                AllItems = JsonConvert.DeserializeObject<List<ItemIngredient>>(json);
            }
        }
        public static void SaveItemsToFile(string jsonFilePath)
        {
            string json = JsonConvert.SerializeObject(AllItems, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }

        public void AddItemIngredint(int id, string quantity)
        {
            AllItems.Add(new ItemIngredient
            { IngredientID = id, ItemIngredientQuantity = quantity });
        }
        public void RemoveItemIngredient(int deletedItemIngredient)
        {
            foreach (var x in AllItems)
            {
                if (x.IngredientID == deletedItemIngredient)
                {
                    AllItems.Remove(x);
                }
            }
        }
        public void ChangeItemIngredient(int IDtoChange, int NewItemIngredientID, string NewItemIngredientQuan)
        {
            foreach (var x in AllItems)
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
