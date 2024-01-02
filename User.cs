using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    public class User
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRole {  get; set; }
        public User() { }
        public User (string UserName, string UserPassword, string UserRole)
        {
            this.UserName = UserName;
            this.UserPassword = UserPassword;
            this.UserRole = UserRole;
        }
        public bool Signin (string username, string password, User user)
        {
            if (user.UserName == username && user.UserPassword == password) 
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

    }

}
