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

        public void signUpUser(string fullname, string phone, string address, string username, string password)
        {
            Customer customer = new Customer(fullname, phone, address);
            SystemUser user = new SystemUser(username, password, "customer");
        }
    }
}
