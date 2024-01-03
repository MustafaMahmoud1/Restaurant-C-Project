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

        public static List<User> AllUsers = new List<User> { };

        public User() { }
        public User (string UserName, string UserPassword, string UserRole)
        {
            this.UserName = UserName;
            this.UserPassword = UserPassword;
            this.UserRole = UserRole;
        }

        public static void LoadAllUsersFromJson(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                AllUsers = JsonConvert.DeserializeObject<List<User>>(json);
            }
        }
        public void AddUser()
        {
            AllUsers.Add(this);
        }

        public static bool VerifyUser(string username, string password, string role)
        {
            foreach (User user in AllUsers)
            {
                if (user.UserName == username && user.UserPassword == password && user.UserRole == role)
                {
                    return true;
                }
            }
            return false;
        }

        public static void SaveUsersToFile(string jsonFilePath)
        {
            string json = JsonConvert.SerializeObject(AllUsers, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }

    }

}
