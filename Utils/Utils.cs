using lab9_WebDriver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9_WebDriver.Utils
{
    public static class Utils
    {
        public static string pathToDriver => @"C:\\software\\drivers";

        static Utils()
        {
            new Workspace(pathToDriver);
        }
        public static bool CheckExpectedUrl(string url)
        {
            if (Workspace.driver.Url == url) return true;
            else return false;
        }

    }
}
