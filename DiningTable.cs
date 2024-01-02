using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project
{
    internal class DiningTable 
    {
        public int TableNo { get; set; }
        public int TableCapicty { get; set; }
        public bool Type { get; set; }
        public DiningTable() { }

        public DiningTable(int TableNo , int TableCapicty , bool Type)
        {
            this.TableNo = TableNo;
            this.TableCapicty = TableCapicty;
            this.Type = Type;
        }
       
        
    }
}
