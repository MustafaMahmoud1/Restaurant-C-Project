using Newtonsoft.Json;

namespace jsonnn
{
    internal class Program
    { 
        static void Main(string[] args)
        {
             string json = System.IO.File.ReadAllText(@"C:/Users/abdelrahman shalaby/Desktop/json files/menuuu.json");
            //Console.WriteLine(json);

            Menu restaurantMenu = JsonConvert.DeserializeObject<Menu>(json);
            foreach (var menuItem in restaurantMenu.MenuItems)
            {
                Console.WriteLine($"ItemID: {menuItem.ItemID}, ItemName: {menuItem.ItemName}");
            }


            //string serialized = JsonConvert.SerializeObject(deserialized);
            //Console.WriteLine(serialized);
        }
    }
}
// the problem is this isnot one item its a list of objects