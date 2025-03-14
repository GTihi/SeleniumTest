using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

public class LoginTest
{
    [Fact]
    public void LoginToWebsite()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://seleniumtests.scienceontheweb.net/wp-admin");

        driver.FindElement(By.Id("user_login")).SendKeys("testuser");
        driver.FindElement(By.Id("user_pass")).SendKeys("Tests3cret!");
        driver.FindElement(By.Id("wp-submit")).Click();

        Assert.Contains("Dashboard", driver.PageSource);
        driver.Quit();
    }
}