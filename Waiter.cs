using c__project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Project
{
    internal class Waiter : Employee
    {
        public Waiter(int empId, int empSalary, string empName, string UserName, string UserPassword, string UserRole) : base(empId, empSalary, empName, UserName, UserPassword, UserRole) { }
        reservations reserve = new reservations();
        ordereditem orderitem = new ordereditem();
        public int ShowReservationList()
        {
            reserve.ShowActiveReservatioList();
            return ShowReservationList();
        }
        public void OrderCreation()
        {
            orderitem.CreateOrder();
        }
        public void TableReservation()
        {
            reserve.ReserveTable();
        }
        public void ModifyReservation()
        {
            reserve.RemoveFromReservation();
        }
    }
}
