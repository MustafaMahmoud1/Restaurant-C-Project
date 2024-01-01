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

        public reservations(int reserveid, int reservetime, string reservename, string reservantphone, string reservanttable)
        {
           reserveid = reserveid;
        
            reservetime = reservetime;
           
            reservename = reservename;

            reservantphone = reservantphone;
            reservanttable = reservanttable;




        }
    }
}
