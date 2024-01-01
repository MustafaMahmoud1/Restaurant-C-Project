using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;

namespace Restaurant_C__Project
{
    internal class Main
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your Username (Used when Logging in)");
            string username = Console.ReadLine();
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

            Utilities.GetInstance().signUpUser(fullname, phone, address, username, password);
        }
    }
}
