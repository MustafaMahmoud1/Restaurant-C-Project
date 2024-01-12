﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class Employee
    {
        public int EmpId { get; set; }
        public int EmpSalary { get; set; }
        public string EmpName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public Employee() { }

        public Employee(string EmpName, int EmpSalary, string PhoneNumber, string EmployeeAdress, string UserName, string UserPassword, string UserRole)
        {
            Random R = new Random();
            this.EmpId = R.Next();
            this.EmpSalary = EmpSalary;
            this.EmpName = EmpName;
            this.PhoneNumber = PhoneNumber;
            this.Adress = EmployeeAdress;
            this.UserName = UserName;
            this.UserPassword = UserPassword;
            this.UserRole = UserRole;

        }
        public Employee(string UserName, string UserPassword, string UserRole)
        {
            this.UserName = UserName;
            this.UserPassword = UserPassword;
            this.UserRole = UserRole;

        }
        //signin function
        public static bool EmpSignIn(string UserName, string Password, string Roll)
        {
            bool check = false;
            Admin.LoadAllEmployeesFromJsonFile(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\User.json");
                foreach (var user in Admin.Employees)
                    {
                if (user.UserName == UserName && user.UserPassword == UserPassword && user.UserRole == Roll)
                {
                    check = true;

                }
                else
                {
                    check = false;
                }
            }
            return check;
        }

        public virtual string EmployeeData()
        {
            EmpName = this.EmpName;
            EmpSalary = this.EmpSalary;
            EmpId = this.EmpId;
            return EmpName;
        }


    }
}
