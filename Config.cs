using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Infrastructure.Configuration
{
   public  class Config:IConfig
   {
        private readonly NameValueCollection _appsettings = ConfigurationManager.AppSettings;

        public Uri Url => new Uri(_appsettings["Url"]);
        public Credentials Credentials => Credentials.Create(_appsettings["UserName"], _appsettings["Password"]);

   }

    public interface IConfig
    {
        Credentials Credentials { get; }

        Uri Url { get; }
    }
}
