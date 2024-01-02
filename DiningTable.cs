using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project
{
    internal class DiningTable 
    {
        public int tableNo { get; set; }
        public int tableCapicty { get; set; }
        

        public bool type { get; set; }
        public DiningTable() { }

        public DiningTable(int tableNo , int tableCapicty , bool type)
        {
            this.tableNo = tableNo;
            this.tableCapicty = tableCapicty;
            this.type = type;
        }
       

    }
}
