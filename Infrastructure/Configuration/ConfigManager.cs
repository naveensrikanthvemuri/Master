using System.Collections.Specialized;
using System.Configuration;
namespace ConsoleApp1
{
    public class ConfigManager : IconfigManager
    {

        private readonly NameValueCollection _settings;

        public ConfigManager():this(ConfigurationManager.AppSettings)
        {
        }

        public ConfigManager(NameValueCollection settings) => _settings= settings;
        public string Environment => _settings["Environment"];
        public string ApplicationBaseUrl => _settings["ApplicationBaseUrl"];
        public string userName => _settings["userName"];
        public string Password => _settings["Password"];
        public string MarketDataBaseUrl => _settings["MarketDataBaseUrl"];
        public string ApplicationErrorUrl => _settings["ApplicationErrorUrl"];
        public string HttpProxy => _settings["HttpProxy"];

    }

        public interface IconfigManager
        {
            string ApplicationBaseUrl { get; }
            string ApplicationErrorUrl { get; }
            string Environment { get; }
            string HttpProxy { get; }
            string MarketDataBaseUrl { get; }
            string Password { get; }
            string userName { get; }
        }

        
 }

