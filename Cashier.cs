using c__project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Project
{
    internal class Cashier : Employee
    {
        ordereditem ordereditem = new ordereditem();
        public Cashier(int empId, int empSalary, string empName, string UserName, string UserPassword, string UserRole) : base(empId, empSalary, empName, UserName, UserPassword, "Cashier") { }
        public void PrintInvoice()
        {
            ordereditem.Printing();
        }
    }
}
