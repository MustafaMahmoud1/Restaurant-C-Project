using Restaurant_C__Project;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

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
                                    break;
                                case 2:
                                    DiningTable.LoadAlldiningtableFromJson(@"D:\C# Projects\Restaurant C# Project\DiningTable.json");
                                    Reservations.LoadAllReserervisionFromJson(@"D:\C# Projects\Restaurant C# Project\Reservations.json");
                                    DiningTable.ShowTables();
                                    Console.WriteLine("Please enter the table number you want to reserve.");
                                    string tablenumber = Console.ReadLine();
                                    Console.WriteLine("Please enter the month you want to reserve in. (JAN/FEB/MAR..etc)");
                                    string month = Console.ReadLine();
                                    Console.WriteLine("Please enter the day you want to reserve in. (SAT/SUN/MON..etc)");
                                    string day = Console.ReadLine();
                                    Console.WriteLine("Please enter the hour you want to reserve in. (00-23)");
                                    int hour = int.Parse(Console.ReadLine());
                                    string reservedate = month + day + hour;
                                    bool tableavailable = true;
                                    foreach (var x in Reservations.Reservants)
                                    {
                                        if (tablenumber == x.ReservedTableNo)
                                        {
                                            if (x.ReserveDate == reservedate)
                                            {
                                                tableavailable = false;
                                                break;
                                            }
                                            else if (x.ReserveDate == month + day + (hour + 1))
                                            {
                                                tableavailable = false;
                                                break;
                                            }
                                            else if (x.ReserveDate == month + day + (hour + 2))
                                            {
                                                tableavailable = false;
                                                break;
                                            }
                                            else if (x.ReserveDate == month + day + (hour - 1))
                                            {
                                                tableavailable = false;
                                                break;
                                            }
                                            else if (x.ReserveDate == month + day + (hour - 2))
                                            {
                                                tableavailable = false;
                                                break;
                                            }
                                        }
                                    }
                                    if (tableavailable == true)
                                    {
                                        Reservations reservation = new Reservations(reservedate, tablenumber, customer);
                                        reservation.AddToReservation();
                                        Reservations.SaveReservationToJson(@"D:\C# Projects\Restaurant C# Project\Reservations.json");
                                        Customer.ShowNotification("Reservation");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sorry, the table is not available at this time.");
                                        Console.WriteLine("1: Reserve another table.");
                                        Console.WriteLine("2: Cancel the reservation.");
                                        int choice = int.Parse(Console.ReadLine());
                                        switch (choice)
                                        {
                                            case 1:
                                                goto case 2;
                                            case 2:
                                                break;
                                        }
                                    }
                                    break;
                                //sign up/in go back to main page.
                                case 3:
                                    goto loop;
                            }
                            break;
            }
                    break;
                case 2:
                Employeerolepart:
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
                            bool log = Admin.VerifyAdmin(username, password);
                            if (log)
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
                                Console.WriteLine("9- Show All Reservations");
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
                                        Admin.LoadAllEmployeesFromJsonFile(@"D:\C# Projects\Restaurant C# Project\Employee.json");
                                        Admin.SignUp(EmployeeName, EmployeeSalary, EmployeePhone, EmployeeAdress,
                                            UserName, Password, EmployeeRoll);
                                        Admin.SaveAllEmployeesToJsonFile(@"D:\C# Projects\Restaurant C# Project\Employee.json");
                                        goto adminloop;
                                    case 2:
                                        Console.WriteLine("All Employees: ");
                                        Admin.LoadAllEmployeesFromJsonFile(@"D:\C# Projects\Restaurant C# Project\Employee.json");
                                        Admin.SaveAllEmployeesToJsonFile(@"D:\C# Projects\Restaurant C# Project\Employee.json");
                                        Admin.ShowAllEmployees();
                                        goto adminloop;
                                    case 3:
                                        Menu.LoadAllItemsFromJson(@"D:\C# Projects\Restaurant C# Project\Menu.json");
                                        Console.WriteLine("Enter new item name.");
                                        string NewItemName = Console.ReadLine();
                                        Console.WriteLine("Enter new item price.");
                                        int NewItemPrice = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter new item ID.");
                                        int NewItemID = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter new item description.");
                                        string NewDescription = Console.ReadLine();
                                        Console.WriteLine("Enter new item category.");
                                        string category = Console.ReadLine();
                                        Console.WriteLine("Enter ingredients. When done enter null");
                                        List<ItemIngredient> recipe = new List<ItemIngredient>();
                                        while (true)
                                        {
                                            Console.WriteLine("Enter Ingredient id");
                                            int ingid = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter ingredient quantity");
                                            string ingquantity = Console.ReadLine();
                                            ItemIngredient itemIngredient = new ItemIngredient(ingid,ingquantity);
                                            recipe.Add(itemIngredient);
                                            Console.WriteLine("Add more ingredients? 1- Yes, I want to add more items 2- No, Don't add more items");
                                            string answer = Console.ReadLine();
                                            if (answer == "2")
                                            {
                                                break;
                                            }
                                        }
                                        Menu.GetInstance().AddItem(NewItemName, NewItemPrice, NewItemID, NewDescription, category, recipe);
                                        Menu.SaveItemsToFile(@"D:\C# Projects\Restaurant C# Project\Menu.json");
                                        goto adminloop;
                                    case 4:
                                        Menu.LoadAllItemsFromJson(@"D:\C# Projects\Restaurant C# Project\Menu.json");
                                        Menu.SaveItemsToFile(@"D:\C# Projects\Restaurant C# Project\Menu.json");
                                        Admin.ShowAllItemsInMenu();
                                        goto adminloop;
                                    case 5:
                                        Stock.LoadAllItemsFromJson(@"D:\C# Projects\Restaurant C# Project\stock ingredient.json");
                                        Stock.SaveItemsToFile(@"D:\C# Projects\Restaurant C# Project\stock ingredient.json");
                                        Admin.ShowEveryThingInStock();
                                        goto adminloop;
                                    case 6:
                                        Stock.LoadAllItemsFromJson(@"D:\C# Projects\Restaurant C# Project\stock ingredient.json");
                                        Console.WriteLine("Enter ingredient ID.");
                                        int IngredientID = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Ingregient Name.");
                                        string IngredientName = Console.ReadLine();
                                        Console.WriteLine("Enter Ingredient quantity");
                                        int IngredientQuantity = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter availability status: true for available, faslse for unavailable");
                                        bool availability = bool.Parse(Console.ReadLine());
                                        Stock.Get_Instance().AddIngredient(IngredientID, IngredientName, IngredientQuantity, availability);
                                        Stock.SaveItemsToFile(@"D:\C# Projects\Restaurant C# Project\stock ingredient.json");
                                        goto adminloop;
                                    case 7:
                                        DiningTable.LoadAlldiningtableFromJson(@"D:\C# Projects\Restaurant C# Project\DiningTable.json");
                                        DiningTable.SaveDiningTableToFile(@"D:\C# Projects\Restaurant C# Project\DiningTable.json");
                                        Admin.ShowAllTables();
                                        goto adminloop;
                                    case 8:
                                        DiningTable.LoadAlldiningtableFromJson(@"D:\C# Projects\Restaurant C# Project\DiningTable.json");
                                        Console.WriteLine("enter table Number.");
                                        int TableNo = int.Parse(Console.ReadLine());
                                        Console.WriteLine("enter table capacity.");
                                        int TableCapicty = int.Parse(Console.ReadLine());
                                        Console.WriteLine("enter type. true for smoking, false for non smoking");
                                        bool type = bool.Parse(Console.ReadLine());
                                        Admin.AddTables(TableNo, TableCapicty, type);
                                        DiningTable.SaveDiningTableToFile(@"D:\C# Projects\Restaurant C# Project\DiningTable.json");
                                        goto adminloop;
                                    case 9:
                                        Reservations.LoadAllReserervisionFromJson(@"D:\C# Projects\Restaurant C# Project\Reservations.json");
                                        Admin.ShowAllReservations();
                                        goto adminloop;
                                    case 10:
                                        Order.LoadAllOrders(@"D:\C# Projects\Restaurant C# Project\Order.json");
                                        Order.ShowOrdersList();
                                        goto adminloop;
                                    case 11:
                                        Customer.LoadAllCustomersFromJson(@"D:\C# Projects\Restaurant C# Project\Customer.json");
                                        Customer.SaveCustomersToFile(@"D:\C# Projects\Restaurant C# Project\Customer.json");
                                        Admin.ShowAllCustomers();
                                        goto adminloop;
                                    case 12:
                                        goto loop;
                                }
                            }
                            else
                            {
                                goto Employeerolepart;
                            }
                            break;
                        case 2:
                            //Cashier code     
                            Console.WriteLine("please, sign in");
                            Console.WriteLine("enter your user name");
                            string cashierUsername = Console.ReadLine();
                            Console.WriteLine("enter your password");
                            string cashierPassword = Console.ReadLine();
                            bool CashiersigninCond = Employee.EmpSignIn(cashierUsername, cashierPassword, "cashier");
                            if (CashiersigninCond)
                            {
                                Console.WriteLine("signing in done successfully");
                                Console.WriteLine("*----------------------------------------*");
                            }
                            else
                            {
                                Console.WriteLine("invalid username or password , please try to sign in again");
                                goto Employeerolepart;
                            }
                            Console.WriteLine("choose what you want to do");
                            Console.WriteLine("1:print invoice");
                            Console.WriteLine("2:go back to employee menu");
                            int cashierInput = int.Parse(Console.ReadLine());
                            switch (cashierInput) 
                            {
                                case 1:
                                Order.ShowOrdersList();
                                Console.WriteLine("enter order Id you want to print it's invoice");
                                int IDToInvoice = int.Parse(Console.ReadLine());
                                Cashier.PrintInvoice(IDToInvoice);
                                    break;
                                case 2: 
                                goto Employeerolepart;
                                    break;
                            }
                            break;
                        case 3:
                            // Chef code
                            Console.WriteLine("please, sign in");
                            Console.WriteLine("enter your user name");
                            string chefUsername = Console.ReadLine();
                            Console.WriteLine("enter your password");
                            string chefPassword = Console.ReadLine();
                            bool ChefsigninCond = Employee.EmpSignIn(chefUsername, chefPassword, "chef");
                            if (ChefsigninCond)
                            {
                                Console.WriteLine("signing in done successfully");
                                Console.WriteLine("*----------------------------------------*");
                            }
                            else
                            {
                                Console.WriteLine("invalid username or password , please try to sign in again");
                                goto Employeerolepart;
                            }
                        chefWindow:
                            Console.WriteLine("choose what you want to do");
                            Console.WriteLine("1:show order list");
                            Console.WriteLine("2:show stock");
                            Console.WriteLine("3:request an ingredient");
                            Console.WriteLine("4:delete order from active order list");
                            int chefAction = int.Parse(Console.ReadLine());
                            switch (chefAction)
                            {
                                case 1:
                                    Order.LoadAllActiveOrders(@"C:\Users\abdelrahman shalaby\Source\Repos\MustafaMahmoud1\Restaurant-C-Project\ActiveOrder.json");
                                    Order.ShowActiveOrdersList();
                                    break;
                                case 2:
                                    //show stock
                                    Stock.LoadAllItemsFromJson(@"C:\Users\abdelrahman shalaby\Source\Repos\MustafaMahmoud1\Restaurant-C-Project\stock ingredient.json");
                                    Stock.Get_Instance().ShowListOfIngredients();
                                    break;
                                case 3:
                                    // Request ingredient
                                    Console.WriteLine("enter the ingredient ID and ingredient quantity you want to request");
                                    int ingID = int.Parse(Console.ReadLine());
                                    int ingQuant = int.Parse(Console.ReadLine());
                                    Stock.Get_Instance().IngredientToChef(ingID, ingQuant);
                                    break;
                                case 4:
                                    Order.LoadAllActiveOrders(@"C:\Users\abdelrahman shalaby\Source\Repos\MustafaMahmoud1\Restaurant-C-Project\ActiveOrder.json");
                                    Order.ShowActiveOrdersList();
                                    Console.WriteLine("enter the order ID you want to remove");
                                    int orderIDToRemove = int.Parse(Console.ReadLine());
                                    Order.FinishAnOrder(orderIDToRemove);
                                    break;
                                default:
                                    Console.WriteLine("Invalid Option. Please retart the chef window.");
                                    goto chefWindow;
                                    break;
                            }


                            break;
                        case 4:
                            // waiter code
       
                            Console.WriteLine("please, sign in");
                            Console.WriteLine("enter your user name");
                            string waiterUsername = Console.ReadLine();
                            Console.WriteLine("enter your password");
                            string waiterPassword = Console.ReadLine();
                            bool WaitersigninCond = Employee.EmpSignIn(waiterUsername, waiterPassword, "waiter");
                            if (WaitersigninCond)
                            {
                                Console.WriteLine("signing in done successfully");
                                Console.WriteLine("*----------------------------------------*");
                            }
                            else
                            {
                                Console.WriteLine("invalid username or password , please try to sign in again");
                                goto Employeerolepart;
                            }
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
                                    Reservations.LoadAllReserervisionFromJson(@"C:\Users\abdelrahman shalaby\Source\Repos\MustafaMahmoud1\Restaurant-C-Project\Reservations.json");
                                    Reservations.ShowReservations();
                                    break;
                                case 2:
                                //create an order
                                orderAgain:
                                    //Waiter.OrderCreation();
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
                                            Order.LoadAllActiveOrders(@"C:\\Users\\M&M\\Source\\Repos\\Restaurant-C-Project\\ActiveOrder.json");
                                            Order.ShowActiveOrdersList();
                                            break;
                                        default:
                                            Console.WriteLine("invalid input , go back to waiter window");
                                            goto waiterWindow;
                                    }
                                    break;
                                case 3:
                                    //Add a table                         
                                    DiningTable.ShowTables();
                                    Console.WriteLine("enter table number you want to add");
                                    int tableNoToAdd = int.Parse(Console.ReadLine());
                                    Console.WriteLine("enter table capacity you want to add");
                                    int tableCapToAdd = int.Parse(Console.ReadLine());
                                    Console.WriteLine("enter table type you want to add");
                                    Console.WriteLine("if smoking enter 'true'");
                                    Console.WriteLine("if non-smoking enter 'false'");
                                    bool tableTypeToAdd = bool.Parse(Console.ReadLine());
                                    DiningTable.LoadAlldiningtableFromJson(@"C:\Users\HP\Desktop\Restaurant C# Project\Restaurant C# Project\DiningTable.json");
                                    DiningTable diningTable = new DiningTable(tableNoToAdd, tableCapToAdd, tableTypeToAdd);
                                    diningTable.AddDiningTable();
                                    DiningTable.SaveDiningTableToFile(@"C:\Users\HP\Desktop\Restaurant C# Project\Restaurant C# Project\DiningTable.json");
                                    DiningTable.ShowTables();
                                    break;
                                default:
                                    Console.WriteLine("Invalid Option. Please restart the waiter window.");
                                    goto waiterWindow;
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Option. Please Start the employee window.");
                            goto Employeerolepart;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please Start the program again.");
                    goto loop;
            }
        }
    }
}