using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            string json = JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText(@"C:\Users\HP\Desktop\Restaurant C# Project\Restaurant C# Project\user.json", json);
        }
          public static  bool Signin (string username, string password, string role)
        {
            string json = System.IO.File.ReadAllText(@"C:\Users\HP\Desktop\Restaurant C# Project\Restaurant C# Project\user.json");
            foreach (User user in JsonConvert.DeserializeObject<List<User>>(json))
            {
                if (user.UserName == username && user.UserPassword == password && user.UserRole == role)
                {
                    return true;
                }
            }
        }

    }

}
