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
            switch (start)
            {
                case 1:
                    Console.WriteLine("Choose from options.");
                    Console.WriteLine("1: Sign up");
                    Console.WriteLine("2: Sign in");
                    Console.WriteLine("3: Go back to main page.");
                    int sign = int.Parse(Console.ReadLine());
                    switch (sign)
                    {
                        case 1:
                            //Sign up proccess.
                            Console.WriteLine("Enter your Username (Used when Logging in). Don't include space.");
                            string username = Console.ReadLine();
                            username = username.Trim();
                            username = username.ToLower();

                            Console.WriteLine("Enter your Password");
                            string password = Console.ReadLine();
                            password = password.ToLower();

                            Console.WriteLine("Enter your Fullname");
                            string fullname = Console.ReadLine();
                            fullname = fullname.ToLower();

                            string phone = "";
                            while (true)
                            {
                                Console.WriteLine("Enter your Phone Number");
                                phone = Console.ReadLine();
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
                            address = address.ToLower();
                            //List<string> customerdata = new List<string>()
                            //{
                            //    username, password, fullname, phone, address
                            //};

                            //Utilities.GetInstance().signUpUser(fullname, phone, address, username, password);
                            User user = new User(username, password, "customer");
                            Customer customer = new Customer(fullname, phone, address);
                            Console.WriteLine("You signed up successfully. The program will restart now, please sign in.");
                            goto loop;
                        // sign in proccess.
                        case 2:
                            Console.WriteLine("Please enter your username & password");
                            //write a function that check that the enterend username and password combination exist in user.json
                            //if it does exist, return true, else return false
                            string usernametrial = Console.ReadLine();
                            string passwordtrial = Console.ReadLine();
                            if (User.Signin(usernametrial, passwordtrial, "customer"))
                            {
                                Console.WriteLine("You signed in successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid username or password.");
                                goto loop;
                            }   
                            break;
                            Console.WriteLine("please choose a service");
                            Console.WriteLine("1: order online now.");
                            Console.WriteLine("2: reserve a table.");
                            Console.WriteLine("3: Go back to main page.");
                            int servicechoice = int.Parse(Console.ReadLine());
                            switch (servicechoice)
                            {
                                case 1:
                                    menu.ckeck().Showitemstocustomer();
                                    customer.CreateOrder();
                                    customer.ShowNotification("Order");
                                break;
                                case 2:
                                    //reserve a table
                                customer.ShowTables();

                                break;
                            }
                        //sign up/in go back to main page.
                        case 3:
                        goto loop;
                    }




























                    break;
                case 2:
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please Start the program again.");
                    break;
            }
        }
    }
}
