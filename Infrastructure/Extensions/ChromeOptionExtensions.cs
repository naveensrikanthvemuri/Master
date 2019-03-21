using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1.Infrastructure.Extensions
{
    public static class ChromeOptionExtensions
    {

        private static string AssemblyDirectory => typeof(ChromeOptionExtensions).Assembly.GetLocation();
        public static ChromeOptions AddArguments(this ChromeOptions options,string[] args)
        {
            options.AddArguments(args);
            //options.AddArgument("no-sandbox");
            return options;
        }

        public static ChromeOptions ConfigureChromeExecutablePath(this ChromeOptions options)
        {
            var ChromeExePath = $@"{AssemblyDirectory}\GoogleChromePortable_72\chromedriver.exe";
            if (!File.Exists(ChromeExePath))
            {
              
                var message = $@"Can't locate Chrome Portable @ '{ChromeExePath}' Current Executing Assembly Location is '{AssemblyDirectory}' ";
                throw new FileNotFoundException(message);
            }
            //options.BinaryLocation = ChromeExePath;
            
            //Handle faild to load extension from chrome issue
            options.AddAdditionalCapability("useAutomationExtension", false);
            return options;
        }
    }
}
