using c__project;
using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace Restaurant_C__Project
{
    internal class Waiter : Employee
    {
        public Waiter(int empId, int empSalary, string empName, string UserName, string UserPassword, string UserRole) : base(empId, empSalary, empName, UserName, UserPassword, UserRole) { }
        reservations reserve = new reservations();
        ordereditem orderitem = new ordereditem();
        public int ShowReservationList()
        {
            int ReserveId=int.Parse(Console.ReadLine());
            reserve.ShowActiveReservatioList(ReserveId);
            return ShowReservationList();
        }
        public void OrderCreation()
        {
             int ItemID = int.Parse(Console.ReadLine());
             int Quantity = int.Parse(Console.ReadLine());
            orderitem.CreateOrder( ItemID,  Quantity);
        }
        public void TableReservation()
        {
            int tableNo=int.Parse(Console.ReadLine());
            int ReserveTime=int.Parse(Console.ReadLine());
            reserve.ReserveTable( tableNo,  ReserveTime);
        }
        public void ModifyReservation()
        {
            reserve.RemoveFromReservation();
        }
    }
}
