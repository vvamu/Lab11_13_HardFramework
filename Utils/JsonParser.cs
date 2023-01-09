using lab9_WebDriver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace lab9_WebDriver.Utils
{
    public static class JsonParser
    {
        private static string defaultFile = Environment.CurrentDirectory + @"\defaultEnviroment.json";
        private static string administatorFile = Environment.CurrentDirectory + @"\administatorEnviroment.json";


        public static ApplicationUser AddDefaultUser(ApplicationUser user)
        {
            JsonSerializer.Serialize<ApplicationUser>(new FileStream(defaultFile, FileMode.OpenOrCreate), user);

            return user;
        }

        public static ApplicationUser AddAdministatorUser(ApplicationUser user)
        {
            JsonSerializer.Serialize<ApplicationUser>(new FileStream(administatorFile, FileMode.OpenOrCreate), user);

            return user;
        }

        public static ApplicationUser GetDefaultUser()
        {
            return JsonSerializer.Deserialize<ApplicationUser>(defaultFile);
        }

        public static ApplicationUser GetAdministatorUser()
        {
            return JsonSerializer.Deserialize<ApplicationUser>(administatorFile);
        }

        
    }
}
