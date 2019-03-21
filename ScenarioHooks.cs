using System.Diagnostics;
using System.IO;
using System.Reflection;
using ConsoleApp1.Infrastructure.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using TechTalk.SpecFlow;
using ConsoleApp1.Drivers;
using ConsoleApp1.Infrastructure.Configuration;

namespace ConsoleApp1
{
    [Binding]
    public class ScenarioHooks
    {
        private static readonly Config Config = new Config();
        [BeforeScenario(Order = 1)]
        public static void Main() => WebdriverServiceLocator.GlobalDriver =
                                                WebdriverServiceLocator.GlobalDriver ?? CreateDriver();
        
        private static ChromeDriverPortable CreateDriver()
        {
            var driver = new ChromeDriverPortable();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);
            return driver;
        }
    }
}
