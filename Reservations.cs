using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project
{
    internal class Reservations
    {
        public int  ReserveId {  get; set; }
        public int ReserveTime { get; set; }
        public string ReservantName { get; set; }
        public string  ReservantPhone { get; set; }
        public string ReservedTable { get; set; }
        public List<int> Reservants { get; set; } = new List<int>();
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
    public void AddToReservation()
        {
            foreach (var item in ReservantName)
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
            DinningTableList.AddRange(new List<int> {tableNo, ReserveTime});
            foreach (var item in ReserveName)
            {
                Console.WriteLine(item);
            }
        }
    }
}
