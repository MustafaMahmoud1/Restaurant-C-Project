using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Restaurant_C__Project
{
    internal class Reservations
    {
        public int  ReserveId {  get; set; }
        public int ReserveTime { get; set; }
        public string ReservantName { get; set; }
        public string  ReservantPhone { get; set; }
        public string ReservedTable { get; set; }
        public  List<Reservations> Reservants { get; set; } = new List<Reservations>();
        public List<int>DinningTableList { get; set; }= new List<int>();
        
        public Reservations() { }

        public Reservations(int tableNo, int tableCapacity ,bool type, int reserveid, int reservetime, string reservename, string reservantphone, string reservanttable, List<int>reservats):base(tableNo, tableCapacity, type)
        {
           ReserveId = ReserveId;
           ReserveTime = ReserveTime;
           ReservantName = ReservantName;
           ReservantPhone = ReservantPhone;
           ReservedTable = ReservedTable;
           Reservants = Reservants;
        }
        //done
        public void LoadAllReserervisionFromJson(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(JsonFile);
                Reservants = JsonConvert.DeserializeObject<List<Order>>(json);
            }
        }
        //done
    public void AddToReservation()
        {
            Reservants.Add(this);
        }
        //done
        public void RemoveFromReservation(Reservations Reservant)
        {
            foreach (var Item in Reservants)
            {
                if (Reservant.ReserveId==Item.ReserveId )
                {
                    Reservants.Remove(Item);
                }
            }
        }
        //done
        public void DeleteAllReservation()
        {
            Reservants.Clear();
        }
        ////////???????????????????????????????????
        public void ShowActiveReservatioList(int FromTime,int ToTime)
        {
            foreach (var Item in Reservants)
            {
                if (Item.ReserveTime in(FromTime,ToTime))
                {
                    Console.WriteLine(Item);
                }
            }
           // Console.WriteLine(Reservants);
        }
        ////???????????????????????????
        public void ReserveTable(int TableNo, int ReserveTime)
        {
            DinningTableList.AddRange(new List<int> {tableNo, ReserveTime});
            foreach (var item in ReserveName)
            {
                Console.WriteLine(item);
            }
        }
        //////////////////////////////////////////////////////
        /////done
        public static void SaveOrderToJson(string JsonFile)
        {
            string json = JsonConvert.SerializeObject(Reservations, Formatting.Indented);
            File.WriteAllText(JsonFile, json);
        }
    }
}
