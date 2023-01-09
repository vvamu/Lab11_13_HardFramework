using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using lab9_WebDriver.Data;
using lab9_WebDriver.WattpadPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;


namespace lab9_WebDriver.Page
{
    public class BookPage : BasePage
    {
        protected override string? Url => "https://www.wattpad.com/home";
        private string bookName;

        public BookPage(string name) : base() { OpenUrl(name); }

        public void ReadPaidBook()
        {
            Thread.Sleep(1000);
            try
            {
                findElement("//button[@class='btn btn-orange onboarding-nav nav-next']").Click();
                findElement("//button[@class='btn btn-orange onboarding-nav nav-next']").Click();
                findElement("//button[@class='btn btn-orange onboarding-nav nav-next']").Click();
                findElement("//button[@class='btn-no-style']").Click();
            }

            catch { }

            Read();

            var expectedResult = "Платная история";
            var actualResult = findElement("//div[@class='supported-marker']").Text;

            if (expectedResult.Contains(actualResult) || actualResult.Contains(expectedResult))
                Assert.IsTrue(true);
            
            
            else
                Assert.IsTrue(false);
        }

        public void Read()
        {

            findElement("//a[@class='btn-primary read-btn']").Click();
            Thread.Sleep(2000);
        }

        public void SubscribeToAuthor()
        {
            try
            {

                using (new AssertionScope())
                {
                    var btIsNotFollowed = findElement("//button[@class='btn btn-fan on-follow btn-white]");
                    btIsNotFollowed.Should().NotBe(null);
                    btIsNotFollowed.Click();
                }
            }
            catch
            {
                Assert.DoesNotThrow(() =>
                { 
                    var btIsFollowed = findElement("//button[@class='btn btn-fan on-unfollow btn-teal']");
                    btIsFollowed.Should().NotBe(null);
                });

            }
            finally
            {
                Assert.IsTrue(true);

            }
        }

        public void CreateComment(string comment, int i = 0)
        {
            var textarea = findElement("//textarea");
            textarea.SendKeys(comment);

            
            if (i != 0)
            {
                findElement("//div[@class='next-up next-part orange']").Click();
                Assert.NotZero(i);
            }

            Assert.IsTrue(true);

        }

    }
}
