using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IaSiViziteazaAutomation.Browser;
using SeleniumExtras.PageObjects;
using IaSiViziteazaAutomation.PageObject;
using IaSiViziteazaAutomation.BusinessObject;

namespace IaSiViziteazaAutomation.Tests
{
    [TestFixture]
    public class IaSiViziteazaTest: Browser.Browser
    {
        private const string URL = "http://localhost:4200/";
        public LoginPage loginPage;
        public HomePage homePage;
        public RegisterPage registerPage;
        public AddAttractionTypePage addAttractionTypePage;
        public AddAttractionPage addAttractionPage;
        [OneTimeSetUp]
        public void Setup()
        {
            StarBrowser();
            instance.Navigate().GoToUrl(URL);
            PageFactory.InitElements(this, new RetryingElementLocator(instance, TimeSpan.FromSeconds(20)));
            loginPage = new LoginPage();
            homePage = new HomePage();
            registerPage = new RegisterPage();
            addAttractionTypePage = new AddAttractionTypePage();
            addAttractionPage = new AddAttractionPage();
        }
        [Test]
        public void LoginSuccesfully()
        {
            instance.Navigate().GoToUrl(URL + "/login");
            loginPage.LoginApp(new UserLoginBO());
            Assert.IsTrue(homePage.CheckIfHomePaceIsApeard());
        }
        [Test]
        public void LoginWithWrongPassword()
        {
            instance.Navigate().GoToUrl(URL+"/login");
            loginPage.LoginApp(new UserLoginBO()
            {
                Email = "somestring@mdas",
                Password = "dasdasdasdasd",
            });
            Assert.IsTrue(loginPage.CheckIfLoginIsFalse());
        }
        [Test]
        public void RegisterNewUserSuccesfully()
        {
            instance.Navigate().GoToUrl(URL + "/register");
            registerPage.RegisteNewUser(new UserRegisterBO());
            Assert.IsTrue(loginPage.CheckIfLoginIsApeard());
        }
        [Test]
        public void RegisterNewAttractionTypeSuccesfully()
        {
            instance.Navigate().GoToUrl(URL + "/login");
            loginPage.LoginApp(new UserLoginBO());
            instance.Navigate().GoToUrl(URL + "attrtype/add");
            addAttractionTypePage.AddNewAttractionType(new AddAttractionTypeBO());
            Assert.IsTrue(homePage.CheckIfHomePaceIsApeard());
        }
        [Test]
        public void RegisterNewAttractionSuccesfully()
        {
            instance.Navigate().GoToUrl(URL + "/login");
            loginPage.LoginApp(new UserLoginBO());
            instance.Navigate().GoToUrl(URL + "/attractions/add");
            addAttractionPage.AddNewAttraction(new AddAttractionBO());
            Assert.IsTrue(homePage.CheckIfHomePaceIsApeard());
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            instance.Quit();
        }
    }
}
