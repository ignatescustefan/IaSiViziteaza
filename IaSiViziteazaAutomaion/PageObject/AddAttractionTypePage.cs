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
    public class AddAttractionTypePage
    {
        public IWebDriver driver;
        public AddAttractionTypePage()
        {
            driver = Browser.Browser.instance;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.CssSelector, Using = "#attractiontitle")]

        public IWebElement Title { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.form > div > input:nth-child(4)")]

        public IWebElement Description { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.form > div > div")]

        public IWebElement Image { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.form > div > button")]

        public IWebElement SaveBtn { get; set; }
        
        public void AddNewAttractionType(AddAttractionTypeBO addAttractionTypeBO)
        {
            Title.SendKeys(addAttractionTypeBO.Title);
            Description.SendKeys(addAttractionTypeBO.Description);
            SaveBtn.Click();
        }
    }
}
