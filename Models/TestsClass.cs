


using lab9_WebDriver.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace lab9_WebDriver;

public abstract class TestsClass
{
    //protected virtual string? Url => "https://pastebin.com";

    protected Workspace _ws;
    protected Workspace workspace => _ws ?? new Workspace(Utils.Utils.pathToDriver); 
    protected static IWebDriver? driver => Workspace.driver;

    [SetUp]
    public virtual void Setup()
    {
        //workspace = new Workspace(pathToDriver);
    }

    [TearDown]
    public void TearDown()
    {
        workspace.CloseBrowser();
    }


    protected IWebElement findElement(string path)
    {
        var elem = workspace.findElementByXPath(path);
        MoveToElement(elem);
        return elem;
    }
    protected IWebElement findElement(By XPath)
    {
        var elem = driver.FindElements(XPath).FirstOrDefault();
        MoveToElement(elem);
        return elem;
    }


    public TestsClass MoveToElement(IWebElement element)
    {
        try
        {

            String scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                                           + "var elementTop = arguments[0].getBoundingClientRect().top;"
                                           + "window.scrollBy(0, elementTop-(viewPortHeight/2));";

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript(scrollElementIntoMiddle, element);
       
        }
        catch
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(element);
                actions.Perform();

            }
            catch
            {

            }

        }

        return this;


    }
    public TestsClass ClickToElement(IWebElement element)
    {

        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        return this;
    }


}