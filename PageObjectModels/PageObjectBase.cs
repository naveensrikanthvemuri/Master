using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ConsoleApp1.PageObjectModels
{
    public class PageObjectBase
    {
        protected const string DateOnlyFormat = "DD/MM/YYYY";
        private readonly IJavaScriptExecutor javaScriptExecutor;
        private readonly INavigation navigator;
        protected readonly IWebDriver Driver;

        public PageObjectBase() : this(WebdriverServiceLocator.Driver)
        {

        }

        public PageObjectBase(IWebDriver driver)
        {
            Driver = driver;
            navigator = driver.Navigate();
            javaScriptExecutor = (IJavaScriptExecutor)driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(500)));
        }

        protected void ExecuteScript(string script)
        {
            javaScriptExecutor.ExecuteAsyncScript(script);
        }
    }
}
