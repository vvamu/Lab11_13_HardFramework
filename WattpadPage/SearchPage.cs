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
    public class SearchPage : BasePage
    {
        private string url;
        protected override string? Url => url ;
        private string _bookName;

        public SearchPage(string bookName) : base() 
        { 
            _bookName = bookName;
            url = $"https://www.wattpad.com/search/'{_bookName}'";
            OpenBase();

        }

        public BasePage ClickOnTheBook(string Bookname)
        {

            findElement($"driver.find_elements_by_xpath('//*[contains(text(), '{Bookname}')]')");
            return this;
        }


        public bool TryFindSearchBook(string bookName = "")
        {
            //if (bookName == "") bookName = _bookName;
            //var book = findElement($"driver.find_elements_by_xpath('//*[contains(text(), '{bookName}')]')");

            //return !(book == null);



            //string text = "";
            try
            {


                var elements = driver.FindElements(By.ClassName("title"));
                foreach (var eleme in elements)
                    if (eleme.Text == bookName)
                    {
                        //text = eleme.Text;
                        return true;
                    }

            }
            catch
            {
               return false;
            }

            return true;

        }
        



    }
}
