using System;
using System.ComponentModel;
using System.Net;


namespace ConsoleApp1.WebClients
{
    [DesignerCategory("Code")]
   public  class CookieAwareWebClient:WebClient
    {
        private readonly bool _autoRedirect;
        private readonly CookieContainer _cookieContainer;
        private CookieAwareWebClient(CookieContainer cookies = null,bool autoRedirect = true)
        {
            _autoRedirect = autoRedirect;
            _cookieContainer = cookies ?? new CookieContainer();
        }
        public static CookieAwareWebClient CreateWebClient(CookieContainer cookieContainer = null) => new CookieAwareWebClient(cookieContainer, true);
        protected WebRequest GetWebRequest(Uri address,Action<HttpWebRequest> setup)
        {
            var request = base.GetWebRequest(address);
            if (!(request is HttpWebRequest httpRequest)) return request;
            httpRequest.AllowAutoRedirect = _autoRedirect;
            httpRequest.CookieContainer = _cookieContainer;
            httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            setup?.Invoke(httpRequest);

            return request;
        }
        protected override WebRequest GetWebRequest(Uri address) => GetWebRequest(address, null);
        
    }
}
