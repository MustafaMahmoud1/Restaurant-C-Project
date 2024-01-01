using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project
{
    internal class DiningTable
    {
        private int tableNo { get; set; }
        private int tableCapicty { get; set; }
        

        private bool type { get; set; }

        public DiningTable(int tableNo , int tableCapicty , bool state , bool type)
        {
            this.tableNo = tableNo;
            this.tableCapicty = tableCapicty;
            

            this.type = type;
        }

    }
}
