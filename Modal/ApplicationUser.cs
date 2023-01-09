using lab9_WebDriver.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9_WebDriver.Data
{
    public class ApplicationUser
    {
        public string Login { get; set; }
        public string Password { get; set; }

        private static string DefaultLogin = "testUserEpamLab";
        private static string DefaultPassword = "UtaRAaUo3a1^";

        public ApplicationUser(string login,string password) { Login = login; Password = password; }
        public ApplicationUser() { }

        //public static ApplicationUser DefaultUser => JsonParser.GetUserByEnviroment() ?? JsonParser.AddUserToEnviroment(new ApplicationUser("testUserEpamLab", "UtaRAaUo3a1"));

        public static ApplicationUser DefaultUser { get => new ApplicationUser(DefaultLogin, DefaultPassword); }

        //public static ApplicationUser EnviromentUser => JsonParser.GetUserByEnviroment();


    }
}
