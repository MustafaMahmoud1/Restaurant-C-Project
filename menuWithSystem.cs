using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProjectPart {
    class ItemIngredient
    {
        public int IngredientID { get; set; }
        public string IngredientQuantity { get; set; }
    }

    class MenuItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string Description { get; set; }
        public bool Availability { get; set; }
        public string Category { get; set; }
        public List<ItemIngredient> Recipe { get; set; } = new List<ItemIngredient>();
    }

    class Menu
    {
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}

