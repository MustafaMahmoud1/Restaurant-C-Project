using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project
{
    internal class order
    {
        public int orderid { get; set; }

        

        public List<int> listitem { get; } = new List<int>();
        public order()
        {
            orderid = 0;
            listitem = null;
          
        }
    }
       
}
