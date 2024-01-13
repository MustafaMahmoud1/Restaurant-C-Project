
using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace Restaurant_C__Project
{
    public class Waiter : Employee
    {
        public Waiter(string EmpName, int EmpSalary, string PhoneNumber, string EmployeeAdress, string UserName, string UserPassword, string UserRole) : base(EmpName, EmpSalary, PhoneNumber, EmployeeAdress, UserName, UserPassword, UserRole)
        {

        }
        //show reservations of the day

        //public Waiter(int empId, int empSalary, string empName, string UserName, string UserPassword, string UserRole) { }
        //Reservations reserve = new Reservations();
        //OrderedItem orderitem = new OrderedItem();
        ////public void ShowReservationList(int FromTime, int ToTime)     //done in main
        ////{
        ////    reserve.ShowActiveReservatioList(FromTime, ToTime);  //commented in reservation 
        ////}
        //public static void OrderCreation()
        //{
        //    Order.CreateOrder();
        //}
        //public void showOrderToWaiter()
        //{
        //    OrderedItem orderedItem = new OrderedItem();
        //    orderedItem.showOrderToWaiter();
        //}
        //public void TableReservation()
        //{
        //    Console.WriteLine("enter table number you want to reserve");
        //    int tableNo=int.Parse(Console.ReadLine());
        //    Console.WriteLine("enter reservation time");
        //    int ReserveTime=int.Parse(Console.ReadLine());
        //    reserve.ReserveTable( tableNo,  ReserveTime);
           
        //}
        //public void ModifyReservation()
        //{
        //    reserve.RemoveFromReservation();
        //}
    }
}
