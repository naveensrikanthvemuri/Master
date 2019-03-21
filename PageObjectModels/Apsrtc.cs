using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace ConsoleApp1.PageObjectModels
{
    public class Apsrtc : PageObjectBase
    {
            //private IWebDriver Driver = new ChromeDriver();
            private const string Home = "//a[@title='Home']";
            private const string LinkTicket = "//a[@title='Link Ticket']";
            private const string MyTicket = "//a[@title='My Ticket']";
            private const string CancelTicket = "//a[@title='Cancel Ticket']";
            private const string Gallery = "//a[@title='Gallery']";
            private const string Wallet = "//a[@title='Wallet']";
            private const string TimeTable = "//a[@title='TimeTable / Track']";

            public bool ApsrtcHomepage()
            {
                IWebElement HomeLink = Driver.FindElement(By.XPath(Home));
                IWebElement LT = Driver.FindElement(By.XPath(LinkTicket));
                IWebElement MT = Driver.FindElement(By.XPath(MyTicket));
                IWebElement CT = Driver.FindElement(By.XPath(CancelTicket));
                IWebElement Wall = Driver.FindElement(By.XPath(Wallet));
                IWebElement TT = Driver.FindElement(By.XPath(TimeTable));

                return HomeLink.Displayed &&
                        LT.Displayed &&
                        MT.Displayed &&
                        CT.Displayed &&
                        Wall.Displayed &&
                        TT.Displayed;

            }

            public void EnterUrl(string URL)
            {
                Driver.Navigate().GoToUrl(URL);

                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }

            public void LaunchBrowser()
            {
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                Driver.Manage().Window.Maximize();

            }
    }
}

