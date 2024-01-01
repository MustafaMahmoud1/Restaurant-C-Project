using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project
{
    internal class reservations
    {
        public int  reserveid {  get; set; }
        public int reservetime { get; set; }

        public string reservename { get; set; }


        public string  reservantphone { get; set; }


        public string reservanttable { get; set; }
        public List<int> reservants { get; set; } = new List<int>();
        public reservations() { }

        public reservations(int reserveid, int reservetime, string reservename, string reservantphone, string reservanttable, List<int>reservats)
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
            reservants.Add(reserveid);
        }
        public void RemoveFromReservation()
        {
            reservants.Remove(reserveid);
        }
        public void DeleteReservation()
        {
            reservants.Clear();
        }
    }
}
