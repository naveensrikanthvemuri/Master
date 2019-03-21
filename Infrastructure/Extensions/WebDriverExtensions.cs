using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Cookie = OpenQA.Selenium.Cookie;
using ConsoleApp1.WebClients;
using System.Net;

namespace ConsoleApp1.Infrastructure.Extensions
{
    public static class WebDriverExtensions
    {
        public static string ExecuteScript(this IWebDriver driver, string script, params object[] args) => (driver as IJavaScriptExecutor).ExecuteScript(script, args).ToString();

        public static bool Exists(this By by) => WebdriverServiceLocator.Driver.FindElements(by).Count != 0;

        public static string GetInnerHtml(this IWebDriver driver, IWebElement element) => driver.ExecuteScript("return arguments[0].innerHTML;", element);

        public static WebClient GetWebClient(this IWebDriver webDriver) => CookieAwareWebClient.CreateWebClient(webDriver.ToCookieContainer());

        public static CookieContainer ToCookieContainer(this IWebDriver webDriver) => webDriver.Manage().Cookies.AllCookies.ToCookieContainer();

        private static CookieContainer ToCookieContainer(this IEnumerable<Cookie> from) => from.ToList().ToCookieContainer();

        private static CookieContainer ToCookieContainer(this List<Cookie> from)
        {
            var cookieContainer = new CookieContainer { PerDomainCapacity = 60 };
            foreach(var existingCookie in from)
            {
                var cookie = new System.Net.Cookie(existingCookie.Name, existingCookie.Value, existingCookie.Path, existingCookie.Domain ?? "dev01.commsec-it.cba");
                cookieContainer.Add(cookie);
            }
            return cookieContainer;
        }
    }
}
