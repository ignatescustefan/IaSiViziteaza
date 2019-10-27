using IaSiViziteazaAutomation.BusinessObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteazaAutomation.PageObject
{
    public class RegisterPage
    {
        public IWebDriver driver;
        public RegisterPage()
        {
            driver = Browser.Browser.instance;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }
        [FindsBy(How = How.CssSelector, Using = "#exampleInputEmail1")]

        public IWebElement Email { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > input:nth-child(4)")]

        public IWebElement Name { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > input:nth-child(6)")]

        public IWebElement Surname { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > input:nth-child(8)")]

        public IWebElement PhoneNUmber { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > input:nth-child(10)")]

        public IWebElement Password { get; set; }

        By RegBtnPat = By.CssSelector("body > div > div > button");
        public IWebElement RegisterBtn =>
            driver.FindElement(RegBtnPat);


        public void RegisteNewUser(UserRegisterBO userRegisterBO)
        {
            Email.SendKeys(userRegisterBO.Email);
            Name.SendKeys(userRegisterBO.Name);
            Surname.SendKeys(userRegisterBO.Surname);
            PhoneNUmber.SendKeys(userRegisterBO.PhoneNumber);
            Password.SendKeys(userRegisterBO.Password);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(RegBtnPat));

            driver.FindElement(RegBtnPat).Click();
        }

    }
}
