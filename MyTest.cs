
using lab9_WebDriver.Data;
using lab9_WebDriver.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

[assembly:Parallelizable(ParallelScope.Fixtures)]
namespace lab9_WebDriver;


public class MyTest : TestsClass
{
    
    //protected override string? Url => "https://www.wattpad.com/home";

    private string bookName = "Остров Остов";

    [Test]
    public void SearchBook_Test4()
    {
        var home = new HomePage();
        home.SearchByInput(bookName);
           


    }
    [Test]
    public void AddBookToReadingList_Test6() //6. Добавить книгу в список для чтения
    {
        
        var home = new HomePage();

        home.LogIn(ApplicationUser.DefaultUser);

        home.ClickOnTheTitleBook();
        Thread.Sleep(5000);
        home.AddBookToReaadingList();
       

    }

    [Test]
    public void BlockMatureContent_Test1() 
    {

        var home = new HomePage();

        home.LogIn(ApplicationUser.DefaultUser);
        home.MatureContentOff();
        

    }

    [Test]
    public void WriteFastStory_Test2() //+
    {
        var home = new HomePage();
        home.LogIn(ApplicationUser.DefaultUser);

        home.WriteCleartStory();

    }

    [Test]
    public void StartReadFreeBook_Test3()
    {
        var home = new HomePage();
        home.LogIn(ApplicationUser.DefaultUser);
        //var freebook = home.FindFreeBook();
        home.ClickFirstFreeBook();
        home.StartReadingBook();

    }

    [Test]
    public void ReadTrialVersion_Test5()
    {
        var paidBookUrl = "https://www.wattpad.com/story/192343604-down-world-book-1-of-the-down-world-series";
        var bookPage = new BookPage(paidBookUrl);
        bookPage.ReadPaidBook();
    }


    [Test]
    public async Task CreateComment_Test7()
    {
        await Task.FromResult(true);
        var home = new HomePage();
        home.LogIn(ApplicationUser.DefaultUser);

        var freeBookUrl = "https://www.wattpad.com/story/278289731-%D0%BE%D1%81%D1%82%D1%80%D0%BE%D0%B2-%D0%BE%D1%81%D1%82%D0%BE%D0%B2";
        var comment = "Хорошая книга";
        var bookPage = new BookPage(freeBookUrl);
        bookPage.Read();

        bookPage.CreateComment(comment);


        


    }



    [Test]
    public async Task SubscribeToTheAuthor_Test8()
    {
        await Task.FromResult(true);
        var home = new HomePage();
        home.LogIn(ApplicationUser.DefaultUser);

        var freeBookUrl = "https://www.wattpad.com/story/278289731-%D0%BE%D1%81%D1%82%D1%80%D0%BE%D0%B2-%D0%BE%D1%81%D1%82%D0%BE%D0%B2";
        var bookPage = new BookPage(freeBookUrl);
        bookPage.Read();
        bookPage.SubscribeToAuthor();
        

    }

    [Test]
    public void CreateNewReadingList_Test9()
    {

    }

    [Test]
    public void AddComplaintToBook_Test10()
    {

    }

}