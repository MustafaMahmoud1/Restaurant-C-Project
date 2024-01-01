using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class Reservation
    {
        public int  reserveId {  get; set; }
        public int reserveTime { get; set; }

        public string reservantName { get; set; }


        public string  reservantPhone { get; set; }


        public string reservantTable { get; set; }

        public Reservation (int reserveid, int reservetime, string reservename, string reservantphone, string reservanttable)
        {
           reserveId = reserveid;
        
            reserveTime = reservetime;
           
            reservantName = reservename;

            reservantPhone = reservantphone;

            reservantTable = reservanttable;
        }
    }
}
