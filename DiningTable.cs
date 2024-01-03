using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Restaurant_C__Project
{
    internal class DiningTable 
    {
        public int TableNo { get; set; }
        public int TableCapicty { get; set; }
        public bool Type { get; set; }
        static List<DiningTable> table = new List<DiningTable>();
        public DiningTable() { }

        public DiningTable(int TableNo , int TableCapicty , bool Type)
        {
            this.TableNo = TableNo;
            this.TableCapicty = TableCapicty;
            this.Type = Type;
            table.Add(this);
            string json = JsonConvert.SerializeObject(table);
            System.IO.File.WriteAllText(@"C:\Users\HP\Desktop\Restaurant C# Project\Restaurant C# Project\DiningTable.json", json);
        }
        public void ShowTables()
        {
            var json = System.IO.File.ReadAllText(@"C:\Users\HP\Desktop\Restaurant C# Project\Restaurant C# Project\DiningTable.json");
            var table = JsonConvert.DeserializeObject<List<DiningTable>>(json);
            foreach (var item in table)
            {
                Console.WriteLine(item.TableNo);
                Console.WriteLine(item.TableCapicty);
                Console.WriteLine(item.Type);
            }
        }
       
        
    }
}
