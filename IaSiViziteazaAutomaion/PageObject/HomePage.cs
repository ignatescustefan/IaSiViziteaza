using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteazaAutomation.PageObject
{
    public class HomePage
    {
        public IWebDriver driver;
        public HomePage()
        {
            driver = Browser.Browser.instance;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }
        [FindsBy(How = How.CssSelector, Using = "#navbarSupportedContent > ul.navbar-nav.ml-auto > li:nth-child(3) > button")]

        public IWebElement LogoutBtn { get; set; }

        public By Logout = By.CssSelector("#navbarSupportedContent > ul.navbar-nav.ml-auto > li:nth-child(3) > button");

        public bool CheckIfHomePaceIsApeard()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(Logout));
            return LogoutBtn.Enabled;
        }

    }
}
