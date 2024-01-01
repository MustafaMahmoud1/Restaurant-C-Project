using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Project
{
    internal class Admin : Employee, ICustomer
    {
        public Admin (int EmpId, int EmpSalary, string EmpName, string UserName, string UserPassword, string UserRole):base( EmpId, EmpSalary, EmpName, UserName, UserPassword, "Admin") { }

        string ICustomer.FullName { get; set; }
        int ICustomer.PhoneNumber { get; set; }
        string ICustomer.Address { get ; set; }

        public void ShowCustomerInfo() { }
        public void UpdateMenu() { }
        public void ModifyOrder() { }
        public void CancelOrder() { }
        public void ModifyReservation() { }
        public void CancelReservation() { }
    }
}
