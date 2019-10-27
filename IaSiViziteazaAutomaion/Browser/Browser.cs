using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaSiViziteazaAutomation.Browser
{
    public class Browser
    {
        public static IWebDriver instance;

        public static void StarBrowser()
        {
            instance = new ChromeDriver();
        }
    }
}
