using c__project;
using Restaurant_C__Project;
using round2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Project
{
    internal sealed class Admin : Employee
    {
        public Admin (int EmpId, int EmpSalary, string EmpName, string UserName, string UserPassword, string UserRole):base( EmpId, EmpSalary, EmpName, UserName, UserPassword, "Admin") { }
        Customer customer = new Customer();
        order order = new order();
        reservations reservations = new reservations();
        ingredients ingredients = new ingredients();
        private Admin() { }
        private static Admin MyAdmin;
        public static Admin ckeck()
        {
            if (MyAdmin == null)
                MyAdmin = new Admin();
            return MyAdmin;
        }

        public void ShowCustomerInfo()
        {
            customer.GetCustomerData();
        }

        public void UpdateMenu()
        {
            string NewItemName = Console.ReadLine();
            int NewItemPrice = int.Parse(Console.ReadLine());
            int NewItemID = int.Parse(Console.ReadLine());
            string NewDescription = Console.ReadLine();
            menu.ckeck().AddItem( NewItemName,  NewItemPrice,  NewItemID,  NewDescription);
        }
        public void ModifyOrder()
        {
            order.AddToOrder();
            order.RemoveFromOrder();
        }
        public void CancelOrder()
        {
            order.DeleteOrder();
        }
        public void ModifyReservation()
        {
            reservations.AddToReservation();
            reservations.RemoveFromReservation();
        }
        public void CancelReservation()
        {
            reservations.DeleteReservation();
        }
        public void SignUp()
        {
            UserName = "RestaurantAdmin";
            UserPassword = "123MMB";
            UserRole = string.Empty;
            EmpName = string.Empty;
            EmpId= int.MaxValue;
        }
        public void GetIngredient()
        {
            ingredients.LoadIngredient();
        }
    }
}
