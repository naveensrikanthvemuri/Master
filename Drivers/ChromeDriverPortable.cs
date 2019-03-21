using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.Specialized;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using ConsoleApp1.Infrastructure.Extensions;

namespace ConsoleApp1.Drivers
{
    public class ChromeDriverPortable:ChromeDriver
    {
        private static readonly List<string> Arguments = new List<string>
        {
            "--test-type",
            "--disable-extensions",
            "--start-maximized",
            "-ignore-certificate-errors"
        };

        private static readonly string HttpProxyAppSetting = ConfigurationManager.AppSettings["HttpProxy"];
        private static readonly bool ProxyIsConfigured = !string.IsNullOrEmpty(HttpProxyAppSetting);
        private static readonly bool ProxyIsRequired = ProxyIsConfigured && EnvironmentSettings.IsRunningOnTeamCityAgent;
        public ChromeDriverPortable():base(ChromeOptions)
        {
            

        }
        private static ChromeOptions ChromeOptions => ChromeOptionExtensions.AddArguments(new ChromeOptions
        {
            LeaveBrowserRunning = false,
            AcceptInsecureCertificates = true
        }, Arguments.ToArray()).ConfigureChromeExecutablePath();
    }

}
