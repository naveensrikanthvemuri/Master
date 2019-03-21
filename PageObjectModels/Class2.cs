using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.PageObjectModels
{
   public class Class2
    {
        private static IWebDriver driver = new ChromeDriver();
        public void MyAccount()
        {
            IWebElement MyAccounts = driver.FindElement(By.XPath("//div[contains(text(),'My Account')]"));
            Thread.Sleep(1000);
            Actions Mouseover = new Actions(driver);
            Mouseover.MoveToElement(MyAccounts).Perform();
        }
    }
}
