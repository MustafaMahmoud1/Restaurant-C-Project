using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Project
{
    internal abstract class User
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRole {  get; set; }
        public User (string UserName, string UserPassword, string UserRole)
        {
            this.UserName = UserName;
            this.UserPassword = UserPassword;
            this.UserRole = UserRole;
        }
        public abstract void SignIn();

    }

}
