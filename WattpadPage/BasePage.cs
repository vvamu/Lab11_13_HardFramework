using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9_WebDriver.WattpadPage
{
    public abstract class BasePage : TestsClass
    {
        protected abstract string? Url { get; }

        public BasePage() { }

        public void OpenBase()
        {
            workspace.OpenBrowserWithUrl(Url);

        }

        public void OpenUrl(string url)
        {
            workspace.OpenBrowserWithUrl(url);

        }






    }
}
