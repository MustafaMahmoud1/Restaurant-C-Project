using C__Project;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;

namespace Restaurant_C__Project
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {

        loop:
            Console.WriteLine("Welcome to our restaurant");
            Console.WriteLine("Please select what describes you best.");
            Console.WriteLine("1: Customer");
            Console.WriteLine("2: Employee");
            int start = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (start)
            {
                case 0:
                    //Menu.LoadAllItemsFromJson(@"D:\C# Projects\Restaurant C# Project\Menu.json");
                    //Menu.GetInstance().AddItem("pizza", 220 , 2042235, "pizzaaa");
                    //Menu.SaveItemsToFile(@"D:\C# Projects\Restaurant C# Project\Menu.json");
                    //Menu.GetInstance().ShowItems();
                    break;
                case 1:
                    Console.WriteLine("Choose from options.");
                    Console.WriteLine("1: Sign up");
                    Console.WriteLine("2: Sign in");
                    Console.WriteLine("3: Go back to main page.");
                    int sign = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (sign)
                    {
                        case 1:
                            //Sign up proccess.
                            Console.WriteLine("Enter your Username (Used when Logging in). Don't include space.");
                            string username = Console.ReadLine();
                            Console.Clear();
                            username = username.Trim();
                            username = username.ToLower();
                            //check if username is already taken.
                            Customer.LoadAllCustomersFromJson(@"D:\C# Projects\Restaurant C# Project\Customer.json");
                            foreach (var x in Customer.AllCustomer)
                            {
                                if (username == x.UserName)
                                {
                                    Console.WriteLine("Username is already taken, please choose another one.");
                                    goto case 1;
                                }
                            }

                            Console.WriteLine("Enter your Password");
                            string password = Console.ReadLine();
                            Console.Clear();
                            password = password.ToLower();

                            Console.WriteLine("Enter your Fullname");
                            string fullname = Console.ReadLine();
                            Console.Clear();
                            fullname = fullname.ToLower();

                            string phone = "";
                            while (true)
                            {
                                Console.WriteLine("Enter your Phone Number");
                                phone = Console.ReadLine();
                                Console.Clear();
                                if (phone.StartsWith("01") && phone.Length == 11 && phone.All(char.IsDigit))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please enter a valid phone number.");
                                }
                            }
                            Console.WriteLine("Enter your Address");
                            string address = Console.ReadLine();
                            Console.Clear();
                            address = address.ToLower();
                            Customer customer = new Customer(fullname, phone, address, username, password);
                            Console.WriteLine("You signed up successfully. The program will restart now, please sign in.");
                            Customer.LoadAllCustomersFromJson(@"D:\C# Projects\Restaurant C# Project\Customer.json");
                            customer.AddCustomer();
                            Customer.SaveCustomersToFile(@"D:\C# Projects\Restaurant C# Project\Customer.json");
                            goto loop;
                        case 2:
                            // sign in proccess.
                            Console.WriteLine("Please enter your username");
                            string usernametrial = Console.ReadLine();
                            usernametrial = usernametrial.Trim();
                            usernametrial = usernametrial.ToLower();
                            Console.WriteLine("Please enter your password");
                            string passwordtrial = Console.ReadLine();
                            passwordtrial = passwordtrial.Trim();
                            passwordtrial = passwordtrial.ToLower();
                            Customer.LoadAllCustomersFromJson(@"D:\C# Projects\Restaurant C# Project\Customer.json");
                            customer = Customer.VerifyCustomer(usernametrial, passwordtrial);
                            if (customer != null)
                            {
                                Console.WriteLine("You signed in successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid username or password.");
                                goto loop;
                            }
                        serviceloop:
                            Console.WriteLine("please choose a service");
                            Console.WriteLine("1: order online now.");
                            Console.WriteLine("2: reserve a table.");
                            Console.WriteLine("3: Go back to main page.");
                            int servicechoice = int.Parse(Console.ReadLine());
                            Console.Clear();
                            switch (servicechoice)
                            {
                                case 1:
                                    Menu.LoadAllItemsFromJson(@"D:\C# Projects\Restaurant C# Project\Menu.json");
                                    Menu.GetInstance().ShowItemstoCustomer();
                                    Customer.LoadAllCustomersFromJson(@"D:\C# Projects\Restaurant C# Project\Customer.json");
                                    customer.CreateOrder(@"D:\C# Projects\Restaurant C# Project\Orders.json");
                                    Customer.SaveCustomersToFile(@"D:\C# Projects\Restaurant C# Project\Customer.json");
                                    Customer.ShowNotification("Order");
                                    goto serviceloop;
                                case 2:
                                    //Bassant's code

                                    Console.WriteLine("Welecome to Reservation Feature ");
                                    Console.WriteLine("This All Tables In Our Restaurant");
                                   
                                    DiningTable.ShowTables();

                                    Console.WriteLine("please enter your Name");

                                    string ReservantName = (Console.ReadLine());
                                    string ReservantPhone = "";
                                    while (true)
                                    {
                                        Console.WriteLine("please enter your Phone ");
                                        ReservantPhone = (Console.ReadLine());
                                        if (ReservantPhone.Length == 11 && ReservantPhone.StartsWith("01") && ReservantPhone.All(char.IsDigit))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("invalid phone number ,please try again");
                                        }
                                    }

                                    Console.WriteLine("please enter TableNo");
                                    int ReservantTableno = int.Parse(Console.ReadLine());
                                    Console.WriteLine("please enter the ReserveDate");
                                    int ReserveDate = int.Parse(Console.ReadLine());
                                    Console.WriteLine("please enter Reserve Time");
                                    int ReserveTime = int.Parse((Console.ReadLine()));


                                    Reservations reservant = new Reservations(ReserveTime, ReserveDate, ReservantName, ReservantPhone, ReservantTableno);


                                    bool x = reservant.CheckReservation(ReservantTableno, ReserveTime, ReserveDate);
                                    Console.WriteLine(x);
                                    if (x == true)
                                    {
                                        Reservations.LoadAllReserervisionFromJson(@"C:\Users\Mega Store\Source\Repos\Restaurant-C-Projecta\Reservations.json");
                                        reservant.AddToReservation();

                                        Reservations.SaveReservationToJson(@"C:\Users\Mega Store\Source\Repos\Restaurant-C-Projecta\Reservations.json");
                                    }

                                    Customer.ShowNotification("Reservation");


                                    break;
                            }
                            break;
                        //sign up/in go back to main page.
                        case 3:
                        goto loop;
                    }




























                    break;
                case 2:
                    Emploeerolepart:
                    Console.WriteLine("choose your role");
                    Console.WriteLine("1:Admin");
                    Console.WriteLine("2:Cashier");
                    Console.WriteLine("3:Chef");
                    Console.WriteLine("4:Waiter");
                    int Emploeerole = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (Emploeerole)
                    {
                        case 1:
                            Console.WriteLine("Please Sign In ");
                            Console.WriteLine("Enter your User Name ");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter your Password ");
                            string password = Console.ReadLine();
                            Admin.VerifyCustomer(username, password);
                            if (Admin.VerifyCustomer != null)
                            {
                            adminloop:
                                Console.WriteLine("Choose from options");
                                Console.WriteLine("1- SignUp Employee");
                                Console.WriteLine("2- Show All Employee");
                                Console.WriteLine("3- Add Item to Menu");
                                Console.WriteLine("4- Show All Items in Menu");
                                Console.WriteLine("5- Show Everything in Stock");
                                Console.WriteLine("6- Add Ingredient to Stock");
                                Console.WriteLine("7- Show All Tables");
                                Console.WriteLine("8- Add Table");
                                Console.WriteLine("9- Show All Reservats");
                                Console.WriteLine("10- Show All Orders");
                                Console.WriteLine("11- Show All Customers");
                                Console.WriteLine("12- Go Back to Main Page");
                                int adminchoice = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (adminchoice)
                                {
                                    case 1:
                                        Console.WriteLine("Please Enter Employee Name ");
                                        string EmployeeName = Console.ReadLine();
                                        Console.WriteLine("Please Enter Employee Phone Number ");
                                        string EmployeePhone = Console.ReadLine();
                                        Console.WriteLine("Please Enter Employee Salary ");
                                        int EmployeeSalary = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Please Enter Employee Adress ");
                                        string EmployeeAdress = Console.ReadLine();
                                        Console.WriteLine("Please Enter Employee Username ");
                                        string UserName = Console.ReadLine();
                                        Console.WriteLine("Please Enter Employee Password ");
                                        string Password = Console.ReadLine();
                                        Console.WriteLine("Please Enter Employee Roll ");
                                        string EmployeeRoll = Console.ReadLine();
                                        Admin.LoadAllEmployeesFromJsonFile(@"C:\Users\M&M\source\repos\resturant\Employee.json");
                                        Admin.LoadAllEmplUsersFromJsonFile(@"C:\Users\M&M\source\repos\resturant\User.json");
                                        Admin.SignUp(EmployeeName, EmployeeSalary, EmployeePhone, EmployeeAdress,
                                            UserName, Password, EmployeeRoll);
                                        Admin.SaveAllEmplUsersToJsonFile(@"C:\Users\M&M\source\repos\resturant\User.json");
                                        Admin.SaveAllEmployeesToJsonFile(@"C:\Users\M&M\source\repos\resturant\Employee.json");
                                        goto adminloop;
                                    case 2:
                                        Console.WriteLine("All Employees: ");
                                        Admin.LoadAllEmployeesFromJsonFile(@"D:\ITI\new\c#\c# project1\FINAL\Employee.json");
                                        Admin.LoadAllEmplUsersFromJsonFile(@"D:\ITI\new\c#\c# project1\FINAL\User.json");
                                        Admin.SaveAllEmployeesToJsonFile(@"D:\ITI\new\c#\c# project1\FINAL\Employee.json");
                                        Admin.SaveAllEmplUsersToJsonFile(@"D:\ITI\new\c#\c# project1\FINAL\User.json");
                                        Admin.ckeck().ShowAllEmployees();
                                        goto adminloop;
                                    case 3:
                                        Menu.LoadAllItemsFromJson(@"D:\ITI\new\c#\c# project1\FINAL\Menu.json");
                                        string NewItemName = Console.ReadLine();
                                        int NewItemPrice = int.Parse(Console.ReadLine());
                                        int NewItemID = int.Parse(Console.ReadLine());
                                        string NewDescription = Console.ReadLine();
                                        Admin.ckeck().AddItemToMenu(NewItemName, NewItemPrice, NewItemID, NewDescription);
                                        Menu.SaveItemsToFile(@"D:\ITI\new\c#\c# project1\FINAL\Menu.json");
                                        goto adminloop;
                                    case 4:
                                        Menu.LoadAllItemsFromJson(@"D:\ITI\new\c#\c# project1\FINAL\Menu.json");
                                        Menu.SaveItemsToFile(@"D:\ITI\new\c#\c# project1\FINAL\Menu.json");
                                        Admin.ckeck().ShowAllItemsInMenu();
                                        goto adminloop;
                                    case 5:
                                        Stock.LoadAllItemsFromJson(@"D:\ITI\new\c#\c# project1\FINAL\stock ingredient.json");
                                        Stock.SaveItemsToFile(@"D:\ITI\new\c#\c# project1\FINAL\stock ingredient.json");
                                        Admin.ckeck().ShowEveryThingInStock();
                                        goto adminloop;
                                    case 6:
                                        Stock.LoadAllItemsFromJson(@"D:\ITI\new\c#\c# project1\FINAL\stock ingredient.json");
                                        Stock.SaveItemsToFile(@"D:\ITI\new\c#\c# project1\FINAL\stock ingredient.json");
                                        int IngredientID = int.Parse(Console.ReadLine());
                                        string IngredientName = Console.ReadLine();
                                        int IngredientQuantity = int.Parse(Console.ReadLine());
                                        Admin.ckeck().AddIngresientToStock(IngredientID, IngredientName, IngredientQuantity);
                                        goto adminloop;
                                    case 7:
                                        DiningTable.LoadAlldiningtableFromJson(@"D:\ITI\new\c#\c# project1\FINAL\DiningTable.json");
                                        DiningTable.SaveDiningTableToFile(@"D:\ITI\new\c#\c# project1\FINAL\DiningTable.json");
                                        Admin.ckeck().ShowAllTables();
                                        goto adminloop;
                                    case 8:
                                        DiningTable.LoadAlldiningtableFromJson(@"D:\ITI\new\c#\c# project1\FINAL\DiningTable.json");
                                        int TableNo = int.Parse(Console.ReadLine());
                                        int TableCapicty = int.Parse(Console.ReadLine());
                                        Admin.ckeck().AddTables(TableNo, TableCapicty);
                                        DiningTable.SaveDiningTableToFile(@"D:\ITI\new\c#\c# project1\FINAL\DiningTable.json");
                                        goto adminloop;
                                    case 9:
                                        Reservations.LoadAllReserervisionFromJson(@"D:\ITI\new\c#\c# project1\FINAL\Reservations.json");
                                        Reservations.SaveReservationToJson(@"D:\ITI\new\c#\c# project1\FINAL\Reservations.json");
                                        Admin.ckeck().ShowAllReservations();
                                        goto adminloop;
                                    case 10:
                                        Order order = new Order();
                                        order.ShowOrdersList(@"D:\ITI\new\c#\c# project1\menna\Order.Json");
                                        order.SaveOrderToJson(@"D:\ITI\new\c#\c# project1\menna\Order.Json");
                                        goto adminloop;
                                    case 11:
                                        Customer.LoadAllCustomersFromJson(@"D:\ITI\new\c#\c# project1\FINAL\Customer.json");
                                        Customer.SaveCustomersToFile(@"D:\ITI\new\c#\c# project1\FINAL\Customer.json");
                                        Admin.ckeck().ShowAllCustomers();
                                        goto adminloop;
                                    case 12:
                                        goto adminloop;
                                }
                            }
                        break;     
                        case 2:
                            //Cashier code       still 
                            Cashier cashier;
                            Console.WriteLine("please, sign in by your user name and password");
                            cashier.SignIn();

                            break;
                        case 3:
                            // Chef code
                            Chef chef;
                            Console.WriteLine("please, sign in by your user name and password");
                            chef.SignIn();
                        chefWindow:
                            Console.WriteLine("choose what you want to do");
                            Console.WriteLine("1:show order list");
                            Console.WriteLine("2:serve an oder");
                            Console.WriteLine("3:show stock");
                            Console.WriteLine("4:request an ingredient");
                            int chefAction = int.Parse(Console.ReadLine());
                            switch (chefAction)
                            {
                                case 1:
                                    //show order list
                                    chef.ShowOrderList("Order list json file here"); 
                                    break;
                                case 2:
                                    //serve order  
                                    // still
                                    break;
                                case 3:
                                    //show stock
                                    chef.ShowStock();
                                    break;
                                case 4:
                                    // Request ingredient
                                    Console.WriteLine("enter the ingredient ID and ingredient quantity you want to request");
                                    int ingID = int.Parse(Console.ReadLine());
                                    int ingQuant = int.Parse(Console.ReadLine());
                                    chef.RequestIngredient(ingID, ingQuant);
                                    break;
                                default:
                                    Console.WriteLine("Invalid Option. Please retart the chef window.");
                                    goto chefWindow;
                                    break;
                            }


                            break;
                        case 4:
                            // waiter code
                            Waiter waiter;
                            Console.WriteLine("please, sign in by your user name and password");
                            waiter.SignIn();
                        waiterWindow:
                            Console.WriteLine("choose what you want to do");
                            Console.WriteLine("1:show active reservation");
                            Console.WriteLine("2:create an order");
                            Console.WriteLine("3:reserve a table");
                            int waiterAction = int.Parse(Console.ReadLine());
                            switch (waiterAction)
                            {
                                case 1:
                                    //show active reservation
                                    Console.WriteLine("please, enter start time of reservation");
                                    int fromTime=int.Parse(Console.ReadLine());
                                    Console.WriteLine("please, enter end time of reservation");
                                    int toTime = int.Parse(Console.ReadLine());  //time format??
                                    waiter.ShowReservationList(fromTime,toTime); 
                                    break;
                                 case 2:
                                    //create an order
                                    orderAgain:
                                    waiter.OrderCreation();
                                    Console.WriteLine("do you want to order another item ?");
                                    Console.WriteLine("1:yes");
                                    Console.WriteLine("2:no");
                                    int orderProceed = int.Parse(Console.ReadLine());
                                    switch (orderProceed)
                                    {
                                        case 1:
                                            goto orderAgain;
                                            break;
                                        case 2:
                                            Console.WriteLine("your order is : ");
                                            waiter.showOrderToWaiter();
                                            break;
                                        default:
                                            Console.WriteLine("invalid input , go back to waiter window");
                                            goto waiterWindow;
                                    }
                                    break;
                                 case 3:
                                    //reserve a table
                                    waiter.TableReservation();  //all in waiter and reservation 
                                    break;
                                 default:
                                    Console.WriteLine("Invalid Option. Please restart the waiter window.");
                                    goto waiterWindow;
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Option. Please Start the employee window.");
                            goto Emploeerolepart;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please Start the program again.");
                    goto loop;
            }
        }
    }
}
