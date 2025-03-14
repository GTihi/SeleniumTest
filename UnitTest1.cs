using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using Xunit;

public class SeleniumTest : IDisposable
{
    private readonly IWebDriver driver;

    public SeleniumTest()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://seleniumtests.scienceontheweb.net/");
        Thread.Sleep(2000);
    }

    [Fact]
    public void TestPageTitle()
    {
        string expectedTitle = "Selenium Webdriver Tests";
        Assert.Contains(expectedTitle, driver.Title);
    }

    [Fact]
    public void TestButtonClick()
    {

        IWebElement articleLink = driver.FindElement(By.CssSelector("article#post-14 h2.entry-title a"));
        articleLink.Click();
        Thread.Sleep(2000);
        Assert.Equal("Sincronizare în Selenium – gestionarea Wait-urilor – Selenium Webdriver Tests", driver.Title);

    }

    [Fact]
    public void TestButtonClickFail()
    {

        IWebElement articleLink = driver.FindElement(By.CssSelector("article#post-11 h2.entry-title a"));
        articleLink.Click();
        Thread.Sleep(2000);
        Assert.NotEqual("Sincronizare în Selenium – gestionarea Wait-urilor – Selenium Webdriver Tests", driver.Title);

    }

    [Fact]
    public void TestNextPostButtonClick()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement articleLink = driver.FindElement(By.CssSelector("article#post-11 h2.entry-title a"));
        articleLink.Click();
        IWebElement nextPostLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".nav-next a")));
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", nextPostLink);
        Thread.Sleep(2000);
        nextPostLink.Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        Assert.NotEqual("Interacțiunea cu elementele web în Selenium WebDriver – Selenium Webdriver Tests", driver.Title);

    }




    public void Dispose()
    {
        driver.Quit();
    }
}
