using IaSiViziteazaAutomation.BusinessObject;
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
    public class LoginPage
    {
        public IWebDriver driver;
        public LoginPage()
        {
            driver = Browser.Browser.instance;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.CssSelector, Using = "#exampleInputEmail1")]

        public IWebElement Username { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='password']")]

        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='submit']")]

        public IWebElement LoginBtn { get; set; }

        

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div")]

        public IWebElement FailedLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > p")]

        public IWebElement SignIn { get; set; }

        public void LoginApp(UserLoginBO userLoginBO)
        {
            Username.SendKeys(userLoginBO.Email);
            Password.SendKeys(userLoginBO.Password);
            LoginBtn.Click();
        }

        public bool CheckIfLoginIsFalse()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > div > div > div")));
            return FailedLogin.Enabled;
        }
        public bool CheckIfLoginIsApeard()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            By Success = By.CssSelector("body > div > p");
            IWebElement LblSuccess = driver.FindElement(Success);
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > p")));
            var x = LblSuccess.Text.Equals("Sign in");
            return x;
        }
    }
}
