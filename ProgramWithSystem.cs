using System.Text.Json;
//using Newtonsoft.Json;
namespace ProjectPart
{
   internal class Program
    {
 

        static void Main()
        {
            //try
            //{
                string jsonFilePath = "C:/Users/abdelrahman shalaby/Desktop/json files/menuuu.json";
                string jsonString = File.ReadAllText(jsonFilePath);
            //Console.WriteLine(jsonString);

                Menu restaurantMenu = JsonSerializer.Deserialize<Menu>(jsonString);

            //    // Now you can access the menu items
                foreach (var menuItem in restaurantMenu.MenuItems)
                {
                    Console.WriteLine($"ItemID: {menuItem.ItemID}, ItemName: {menuItem.ItemName}");
                }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error during deserialization: {ex.Message}");
            //}
        }
    }
}

