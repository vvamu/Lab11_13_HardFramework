
using lab9_WebDriver.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace lab9_WebDriver;


public class ICanWinTests : TestsClass
{
    //protected override string? Url =>  "https://pastebin.com";


    private By btCreateNewPaste = By.XPath("//button[text()='Create New Paste']");
    private By msgError = By.XPath("//div[@class='error-summary']");


    private string codeValue = "Hello from WebDriver";
    private string titleValue = "helloweb";


    [Test]
    public void Test1()
    {
        var home = new PasteBinHomePage();


        //home.CreateNewPaste().EnterDefaultValues();
        

        
       
        


        var btPaste = findElement(btCreateNewPaste);
        btPaste.Click();
        Thread.Sleep(2000);


        //var errorMsg = driver.FindElement(msgError);

        var currentUrl = driver.Url;
        //Assert.IsTrue(currentUrl != Url);
        

    }

}