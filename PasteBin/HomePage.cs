using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab9_WebDriver.WattpadPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;


namespace lab9_WebDriver.Page
{
    public class PasteBinHomePage : BasePage
    {
        protected override string? Url => "https://pastebin.com";

        public PasteBinHomePage() : base() { }

        public PasteBinHomePage CreateNewPaste()
        {
            Thread.Sleep(1000);
            findElement("//span[@id='select2-postform-expiration-container']").Click();
            Thread.Sleep(1000);
            return this;
        }
        public PasteBinHomePage EnterDefaultValues(string time,string title)
        {
            findElement(By.XPath(($"//li[text()='10 Minutes']"))).Click();
            //findElement(By.XPath(("//input[@id='postform-name']"))).SendKeys(titleValue);
            //findElement(By.XPath(("//textarea"))).SendKeys(codeValue);
            return this;
        }

       

    }
}
