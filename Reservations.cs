using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project
{
    internal class reservations: DiningTable
    {
        public int  ReserveId {  get; set; }
        public int ReserveTime { get; set; }
        public string ReserveName { get; set; }
        public string  ReservantPhone { get; set; }
        public string ReservantTable { get; set; }
        public List<int> Reservants { get; set; } = new List<int>();
        public List<int>DinningTableList { get; set; }= new List<int>();
        public reservations() { }

        public reservations(int TableNo, int TableCapacity ,bool Type, int Reserveid, int Reservetime, string ReserveName, string ReservantPhone, string ReservantTable, List<int>reservats):base(TableNo, TableCapacity, Type)
        {
           ReserveId = ReserveId;
           ReserveTime = ReserveTime;
           ReserveName = ReserveName;
           ReservantPhone = ReservantPhone;
           ReservantTable = ReservantTable;
           Reservants = Reservants;
        }
    public void AddToReservation()
        {
            foreach (var item in ReserveName)
            {
                Reservants.Add(item);
            }
        }
        public void RemoveFromReservation()
        {
            foreach (var item in ReserveName)
            {
                Reservants.Remove(item);
            }
        }
        public void DeleteReservation()
        {
            Reservants.Clear();
        }
        public void ShowActiveReservatioList()
        {
            Console.WriteLine(Reservants);
        }
        public void ReserveTable()
        {
            DinningTableList.AddRange(new List<int> { TableNo, ReserveTime});
            foreach (var item in ReserveName)
            {
                Console.WriteLine(item);
            }
        }
    }
}
