using Newtonsoft.Json;
using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    public sealed class Admin : Employee
    {   
        
        private static Admin MyAdmin;
        
        public static List<Employee> Employees = new List<Employee> { };
        
        private Admin(string AdminName, int AdminSalary, string AdminPhone, string AdminAdress, string AdminUsername, string AdminPassword, string UserRole) : base(AdminName, AdminSalary,AdminPhone, AdminAdress, AdminUsername, AdminPassword, "Admin") 
        { }

        public static Admin AddNewAdmin(string AdminName, int AdminSalary, string AdminPhone, string AdminAdress, string AdminUsername, string AdminPassword, string UserRole)
        {
            if (MyAdmin == null)
                MyAdmin = new Admin( AdminName, AdminSalary, AdminPhone, AdminAdress, AdminUsername, AdminPassword, UserRole);
            return MyAdmin;
        }
        public static void LoadAllEmployeesFromJsonFile(string jsonFilepath)
        {
            if (System.IO.File.Exists(jsonFilepath))
            {
                string Json = File.ReadAllText(jsonFilepath);
                Employees = JsonConvert.DeserializeObject<List<Employee>>(Json);
            }
        }
        //public static void LoadAllEmplUsersFromJsonFile(string JsonFilepath)
        //{
        //    if (System.IO.File.Exists(JsonFilepath))
        //    {
        //        string Json = File.ReadAllText(JsonFilepath);
        //        UserEmp = JsonConvert.DeserializeObject<List<Employee>>(Json);
        //    }
        //}
        public static void SaveAllEmployeesToJsonFile(string jsonFilepath)
        {
            string Json = JsonConvert.SerializeObject(Employees, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilepath, Json);
        }
        //public static void SaveAllEmplUsersToJsonFile(string jsonFilepath)
        //{
        //    string Json = JsonConvert.SerializeObject(UserEmp, Formatting.Indented);
        //    System.IO.File.WriteAllText(jsonFilepath, Json);
        //}
        public static void SignUp(string EmployeeName, int EmployeeSalary, string EmployeePhone, string EmployeeAdress, string UserName, string UserPassword, string EmployeeRoll)
        {



            if (EmployeePhone.Length == 11 && EmployeePhone.StartsWith("01") && EmployeePhone.All(char.IsDigit))

            {
                if (!string.IsNullOrEmpty(EmployeeName) && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(UserPassword) && !string.IsNullOrEmpty(EmployeeAdress) && EmployeeSalary != 0)
                {
                    Employee Emp = new Employee(EmployeeName, EmployeeSalary, EmployeePhone, EmployeeAdress, UserName, UserPassword, EmployeeRoll);
                    Employees.Add(Emp);
                    //Employee User = new Employee(UserName, UserPassword, EmployeeRoll);
                    //UserEmp.Add(User);

                }
                else { Console.WriteLine("there is a wrong sign up becouse you do not enter all requirements"); }
            }
            else
            {
                Console.WriteLine("Sorry Insert Invalid Phone Number Contain 11 number ");

            }
        }
        public void ShowAllEmployees()
        {
            foreach (var item in Employees)
            {
                Console.WriteLine("Employee Name: " + item.EmpName);
                Console.WriteLine("Employee ID is: " + item.EmpId);
                Console.WriteLine("Employee Salary is: " + item.EmpSalary);
                Console.WriteLine("Employee Phone Number is: " + item.PhoneNumber);
                Console.WriteLine("Employee Address is: " + item.Adress);
            }
            //foreach (var y in UserEmp)
            //{
            //    Console.WriteLine("User Name is: " + y.UserName);
            //    Console.WriteLine("User Password is: " + y.UserPassword);
            //    Console.WriteLine("User Role is: " + y.UserRole);
            //}
        }
        public void AddItemToMenu(string NewItemName, int NewItemPrice, int NewItemID, string NewDescription)
        {
            Menu.GetInstance().AddItem(NewItemName, NewItemPrice, NewItemID, NewDescription);
        }
        public void ShowAllItemsInMenu()
        {
            Menu.GetInstance().ShowItems();
        }
        public void ShowEveryThingInStock()
        {
            Stock.Get_Instance().ShowListOfIngredients();
        }
        public void AddIngresientToStock(int IngredientID, string IngredientName, int IngredientQuantity)
        {
            Stock.Get_Instance().AddIngredient(IngredientID, IngredientName, IngredientQuantity);
        }
        public void ShowAllTables()
        {
            DiningTable.ShowTables();
        }
        public void AddTables(int TableNo, int TableCapicty, bool type)
        {
            DiningTable.LoadAlldiningtableFromJson(@"C:\Users\HP\Desktop\Restaurant C# Project\Restaurant C# Project\DiningTable.json");
            DiningTable diningTable = new DiningTable(TableNo, TableCapicty, type);
            diningTable.AddDiningTable();
            DiningTable.SaveDiningTableToFile(@"C:\Users\HP\Desktop\Restaurant C# Project\Restaurant C# Project\DiningTable.json");
        }
        public void ShowAllReservations()
        {
            Reservations.ShowReservations();
        }
        public void ShowAllCustomers()
        {
            Customer.ShowCustomers();
        }
        public static Admin VerifyAdmin(string username, string password)
        {
            foreach (Employee admin in Employees)
            {
                if (admin.UserName == username && admin.UserPassword == password && admin.UserRole == "Admin")
                {
                    return (Admin)admin;
                }
            }
            return null;
        }


        //public void ShowCustomerInfo()
        //public void ShowCustomerInfo(string JsonFile)
        //{
        //    Customer.GetCustomerData();
        //    if (File.Exists(JsonFile))
        //    {
        //        string json = File.ReadAllText(JsonFile);
        //        CustomerData = JsonConvert.DeserializeObject<List<Customer>>(json);
        //    }
        //    public void UpdateMenu()
        //}

        /* public void UpdateMenu()
         {
             string NewItemName = Console.ReadLine();
             int NewItemPrice = int.Parse(Console.ReadLine());
             int NewItemID = int.Parse(Console.ReadLine());
             string NewDescription = Console.ReadLine();
             menu.ckeck().AddItem( NewItemName,  NewItemPrice,  NewItemID,  NewDescription);
         }
         public void ModifyOrder()
         {
             int OrderId=int.Parse(Console.ReadLine());
             List< int > ItemData=new List< int >();
             order.AddToOrder(OrderId, ItemData);
             order.RemoveFromOrder();
         }
        */

        //    public void CancelOrder()
        //    {
        //        order.DeleteOrder();
        //        //  order.DeleteOrder();
        //    }
        //    public void ModifyReservation()
        //    {
        //        int ReserveId = int.Parse(Console.ReadLine());
        //        reservations.AddToReservation(ReserveId);
        //        reservations.RemoveFromReservation();
        //        // reservations.AddToReservation(ReserveId);
        //        // reservations.RemoveFromReservation();
        //    }
        //    public void CancelReservation()
        //    {
        //        reservations.DeleteReservation();
        //        // reservations.DeleteReservation();
        //    }
        //    public void SignUp()
        //    {
        //        /*
        //        UserName = "RestaurantAdmin";
        //        UserPassword = "123MMB";
        //        UserRole = string.Empty;
        //        EmpName = string.Empty;
        //        EmpId= int.MaxValue;
        //        */
        //    }
        //    public void GetIngredient()
        //    {
        //        ingredients.LoadIngredient();
        //    }


    }
}
