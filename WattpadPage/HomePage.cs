using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using lab9_WebDriver.Data;
using lab9_WebDriver.WattpadPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;


namespace lab9_WebDriver.Page
{
    public class HomePage : BasePage
    {
        protected override string? Url => "https://www.wattpad.com/home";
        private string bookName;

        public HomePage() : base() { OpenBase(); }

        public HomePage ClickOnTheBook(string Bookname)
        {
            bookName = Bookname;
            findElement($"driver.find_elements_by_xpath('//*[contains(text(), '{bookName}')]')");
            return this;
        }
        public BasePage ClickOnTheTitleBook()
        {
            findElement("//a[@class='title']").Click();
            return this;
        }
        public BasePage StartReadingBook()
        {
            
            findElement("//button[@class='read btn-primary']").Click();
            var expectedResult = bookName;
            var actualResult = findElement("//h2").Text;



            if (expectedResult.Contains(actualResult) || actualResult.Contains(expectedResult))
                Assert.IsTrue(true);
            else 
                Assert.IsTrue(false);


            Assert.That(expectedResult, Contains.Value(actualResult));
            return this;
        }

        

        public void ClickFirstFreeBook()
        {
            var items = driver.FindElements(By.XPath("//ul[@class='slider-list']/li"));
            items.First().FindElements(By.TagName("img")).FirstOrDefault().Click();
            bookName = findElement("//div[@class='title']").Text;

            //return bookname;
        }



        public void AddBookToReaadingList(string readingListName = "My Library (Private)")
        {
            findElement("//button[@class='btn-primary add-to-library-btn']").Click();
            var parentElement = findElement($"//span[text()='{readingListName}']/parent::button[@class='react-popover-item__btn']");
            parentElement.Click();

            var expectedResult = CheckAddBookToReaadingList();

            Assert.IsTrue(expectedResult);

        }
        public bool CheckAddBookToReaadingList(string readingListName = "My Library (Private)")
        {
            var parentElement = findElement($"//span[text()='{readingListName}']/parent::button[@class='react-popover-item__btn']");
            if (parentElement.FindElements(By.TagName("svg")).FirstOrDefault() == null)
                return false;
            return true;

        }

        public void SearchByInput(string BookName = "")
        {
            if (BookName == "") bookName = BookName;
            Thread.Sleep(1000);
            var searchInput = findElement("//input[@id='search-query']");
            searchInput.Click();
            searchInput.SendKeys(BookName);
            searchInput.SendKeys(Keys.Enter);

            var expectedResult = TryFindSearchBook(bookName);

            Assert.IsTrue(expectedResult);
        }




        public BasePage MatureContentOn()
        {
            findElement(By.ClassName("content-settings-label")).Click(); 
            findElement(By.ClassName("block-on")).Click();
            findElement("//button[text()=\"Apply Changes\"]").Click();
            return this;
        }

        public void MatureContentOff()
        {
            findElement(By.ClassName("content-settings-label")).Click();
            Thread.Sleep(3000);

            try
            {
                driver.FindElement(By.XPath("//div[@class='toggle off']"));
                findElement(By.ClassName("block-off")).Click();
            }
            catch { }

            
            findElement("//button[text()=\"Apply Changes\"]").Click();


            if (findElement("//button[text()=\"Got it\"]") != null)
                findElement("//button[text()=\"Got it\"]").Click();


            var expectedResult = !ThereIsMatureContent();

            Assert.IsTrue(expectedResult);

        }

        public void WriteCleartStory()
        {
            var titleName = "Мой заголовок";
            var inputText = "Мой рассказ";


            findElement("//button[text()='Write ']").Click();
            findElement("//a[@href='/myworks/new']").Click();
            Thread.Sleep(3000);
            findElement("//span[text()='Skip']").Click();

            try { 
            
                findElement(By.ClassName("btn on-okay btn-purplefinish-tooltip-ok")).Click();
            }
            catch { }


            Thread.Sleep(3000);

            var title = findElement(By.Id("story-title"));


            title.Click();
            title.SendKeys(Keys.Control + "a");
            title.SendKeys(titleName);

            //var input = findElement("//div[@class='story-editor medium-editor-element']").FindElements(By.TagName("p")).FirstOrDefault();



            /////////////////////////////////////////////////////////////////////
            try
            {

                

                var i = findElement("//div[@class='story-editor medium-editor-element medium-editor-placeholder']/p[1]");
                i.Click();
                i.SendKeys(inputText);
            }
            catch {}
            

            findElement("//button[@class='btn btn-grey on-save-only']").Click();
            Thread.Sleep(1000);
            var actualResult = findElement("//span[@class='save-indicator small']").Text;
            var expectedResult = "Saved.";

            Assert.AreEqual(actualResult, expectedResult);
        }



        public bool ThereIsMatureContent()
        {
            string[] blockTags = new string[] { "mature", "sex" };
            try
            {
                foreach(var tag in blockTags)
                {
                    if (findElement($"//a[text()='{tag}'") != null)
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;


        }
  



        public BasePage LogIn(string login, string password)
        {
            Thread.Sleep(1000);
            findElement("//button[@class='btn btn-sm']").Click();

            Thread.Sleep(1000);
            findElement("//button[@class='btn-block btn-primary']").Click();

            Thread.Sleep(5000);
            var logIn = findElement(By.Id("login-username"));
            logIn.SendKeys(login);
            var pswd = findElement(By.Id("login-password"));
            pswd.SendKeys(password);

            findElement("//input[@value='Вход']").Click();
            Thread.Sleep(5000);


            return this;
            
        }

        public BasePage LogIn(ApplicationUser user)
        {
            Thread.Sleep(1000);
            findElement("//button[@class='btn btn-sm']").Click();

            Thread.Sleep(1000);
            findElement("//button[@class='btn-block btn-primary']").Click();

            Thread.Sleep(5000);
            var logIn = findElement(By.Id("login-username"));
            logIn.SendKeys(user.Login);
            var pswd = findElement(By.Id("login-password"));
            pswd.SendKeys(user.Password);

            findElement("//input[@value='Вход']").Click();
            Thread.Sleep(5000);


            return this;

        }



        public bool TryFindSearchBook(string bookName = "")
        {

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
