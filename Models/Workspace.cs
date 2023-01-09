using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace lab9_WebDriver.Models;

public class Workspace
{
    public static IWebDriver? driver { get; set; }


    public Workspace(string pathToDriver)
    {
        if (driver == null)
        {

            var driverPath = new DriverManager().SetUpDriver(new ChromeConfig());
            //driver = new OpenQA.Selenium.Chrome.ChromeDriver(pathToDriver);
            driver = new ChromeDriver(driverPath);


            
        }
    }

    public void OpenBrowserWithUrl(string url)
    {
        driver.Navigate().GoToUrl(url);
        driver.Manage().Window.Maximize();
    }

    public void CloseBrowser()
    {
        driver.Quit();
        driver.Dispose();
    }

    public IWebElement findElementByXPath(string path) => driver.FindElements(By.XPath(path)).FirstOrDefault();

}

