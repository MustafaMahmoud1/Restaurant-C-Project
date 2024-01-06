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
                            //admin code
                            break;
                        case 2:
                            //Cashier code       still 
                            Cashier cashier;
                            Console.WriteLine("please, sign in by your user name and password");
                            cashier.SignIn()

                            break;
                        case 3:
                            // Chef code
                            Chef chef;
                            Console.WriteLine("please, sign in by your user name and password");
                            chef.SignIn();
                            chefWindow:
                            Console.WriteLine("choose what you want to do");
                            Console.WriteLine("1:show order list")
                            Console.WriteLine("2:serve an oder")
                            Console.WriteLine("3:show stock")
                            Console.WriteLine("4:request an ingredient")
                            int chefAction = int.Parse(Console.ReadLine());
                            switch (chefAction)
                            {
                                case 1:
                                    //show order list
                                    chef.ShowOrderList("Order list json file here")
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
                            Console.WriteLine("1:show active reservation")
                            Console.WriteLine("2:create an order")
                            Console.WriteLine("3:reserve a table")
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
