
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace lab9_WebDriver;


public class BringItOn : TestsClass
{
    //protected override string? Url =>  "https://pastebin.com";

    private string nameValue = "how to gain dominance among developers";
    private string codeValue = "git config --global user.name  'New Sheriff in Town' \ngit reset $(git commit-tree HEAD^{tree} -m 'Legacy code')\ngit push origin master --force";


    [Test]
    public void Test1()
    {
       
        var codeInput = findElement(By.Id("postform-text"));
        codeInput.SendKeys(codeValue);

        findElement(By.Id("select2-postform-format-container")).Click();
        findElement(By.XPath("//li[text()='Bash']")).Click();

        findElement(By.Id("select2-postform-expiration-container")).Click();
        findElement(By.XPath("//li[text()='10 Minutes']")).Click();

        var nameInput = findElement(By.Id("postform-name"));
        nameInput.SendKeys(nameValue);
        findElement(By.XPath("//button[@class='btn -big']")).Click();


        Thread.Sleep(2000);
        var selectedFormat = findElement("//a[@class='btn -small h_800']").Text;


        Assert.IsTrue(selectedFormat == "Bash");

        

    }

}