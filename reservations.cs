using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class Reservations: DiningTable
    {
        public int  reserveid {  get; set; }
        public int reservetime { get; set; }

        public string reservename { get; set; }


        public string  reservantphone { get; set; }


        public string reservanttable { get; set; }
        public List<int> reservants { get; set; } = new List<int>();
        public List<int>DinningTableList { get; set; }= new List<int>();
        public reservations() { }

        public reservations(int tableNo, int tableCapacity ,bool type, int reserveid, int reservetime, string reservename, string reservantphone, string reservanttable, List<int>reservats):base(tableNo, tableCapacity, type)
        {
           reserveid = reserveid;
        
            reservetime = reservetime;
           
            reservename = reservename;

            reservantphone = reservantphone;
            reservanttable = reservanttable;
            reservats = reservats;
        }
        public void AddToReservation()
        {
            foreach (var item in reservename)
            {
                reservants.Add(item);
            }
        }
        public void RemoveFromReservation()
        {
            foreach (var item in reservename)
            {
                reservants.Remove(item);
            }
        }
        public void DeleteReservation()
        {
            reservants.Clear();
        }
        public void ShowActiveReservatioList()
        {
            Console.WriteLine(reservants);
        }
        public void ReserveTable()
        {
            DinningTableList.AddRange(new List<int> { tableNo, reservetime});
            foreach (var item in reservename)
            {
                Console.WriteLine(item);
            }
        }
    }
}
