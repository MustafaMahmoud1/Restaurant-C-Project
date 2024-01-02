using c__project;
using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Project
{
    internal class Chef : Employee
    {
        public Chef(int empId, int empSalary, string empName, string UserName, string UserPassword, string UserRole) : base(empId, empSalary, empName, UserName, UserPassword, UserRole) { }
        order order = new order();
        ingredients ingredients = new ingredients();
        public void ShowOrderList()
        {
            order.ShowOrder();
        }
        public void FinishOrder()
        {
            order.RemoveFromOrder();
        }
        public void ShowStock()
        {
            stock.ckeck().ShowListOfIngredients();
            
        }
        public void RequestIngredient()
        {
            ingredients.RequestIngredients();
        }


    }
}
