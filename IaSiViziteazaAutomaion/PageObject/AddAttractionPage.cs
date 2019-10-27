using IaSiViziteazaAutomation.BusinessObject;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteazaAutomation.PageObject
{
    public class AddAttractionPage
    {
        public IWebDriver driver;
        public AddAttractionPage()
        {
            driver = Browser.Browser.instance;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.CssSelector, Using = "#ControlSelect")]

        public IWebElement Title { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#attractionname")]

        public IWebElement Name { get; set; }


        [FindsBy(How = How.CssSelector, Using = "[type='submit']")]

        public IWebElement SaveBtn { get; set; }

        public void AddNewAttraction(AddAttractionBO addAttractionBO)
        {
            Title.SendKeys(addAttractionBO.Title);
            Name.SendKeys(addAttractionBO.Description);
            SaveBtn.Click();
        }
    }
}
