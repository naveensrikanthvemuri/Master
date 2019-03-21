using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Credentials
    {
        private Credentials()
        {

        }

        public string Password { get; private set; }
        public string UserName { get; private set; }

        public static Credentials Create(string userName,string password)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentException(nameof(userName));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException(nameof(password));
            return new Credentials
            {
                UserName = userName,
                Password = password
            };
        }
    }
}
