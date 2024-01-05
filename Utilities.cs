using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Restaurant_C__Project
{
    public class Utilities
    {
        private static Utilities util_instance;

        private Utilities()
        {
        }

        public static Utilities GetInstance()
        {
            if (util_instance == null)
            {
                util_instance = new Utilities();
            }
            return util_instance;
        }
    }
}
