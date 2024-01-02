using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Project
{
    internal class Employee: User
    {
        public int EmpId { get; set; }
        public int EmpSalary { get; set; }
        public string EmpName { get; set; }
        public Employee() { }

        public Employee(int empId, int empSalary, string empName, string UserName, string UserPassword, string UserRole):base(UserName, UserPassword, UserRole)
        {
            EmpId = empId;
            EmpSalary = empSalary;
            EmpName = empName;
        }

        public override void SignIn()
        {
           string UserName = Console.ReadLine();
           string UserPassword = Console.ReadLine();
           string UserRole = "Employee";
           // Console.WriteLine(UserRole);
        }
        public virtual string EmployeeData()
        {
            EmpName=this.EmpName;
            EmpSalary=this.EmpSalary;
            EmpId=this.EmpId;
            return EmpName;
        }
    }
}
