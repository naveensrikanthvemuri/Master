using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Collections;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using ConsoleApp1.Infrastructure.Extensions;

namespace ConsoleApp1.PageObjectModels
{

    public class Tsrtc : PageObjectBase
    {

        //private IWebDriver Driver = new ChromeDriver();
        private const string Home = "//a[@title='Home']";
        private const string VajraBooking = "//a[@title='Vajra Booking']";
        private const string LinkTicket = "//a[@title='Link Ticket']";
        private const string BusOnContract = "//a[@title='Bus on Contract']";
        private const string MyTicket = "//a[@title='My Ticket']";
        private const string CancelTicket = "//a[@title='Cancel Tickets']";
        private const string CancelledService = "//a[@title='Cancelled Services']";
        private const string AboutUs = "//a[@class='selectedtabcopy']";
        private const string DriverInfo = "//a[@title='Driver Info']";
        private const string FromSuggestionBox = "//ul[@id='ui-id-1']//li";
        private const string ToSuggestionBox = "//ul[@id='ui-id-2']//li";
        private const string From = "//input[@id='fromPlaceName']";
        private const string To = "//input[@id='toPlaceName']";
        private const string PrevMonth = "//a[@title='Prev']//following-sibling::div/span[@class='ui-datepicker-month']";
        private const string NextMonth = "//a[@title='Next']//following-sibling::div//span[@class='ui-datepicker-month']";
        private const string PrevYear = "//a[@title='Prev']//following-sibling::div//span[@class='ui-datepicker-year']";
        private const string NextYear= "//a[@title='Next']//following-sibling::div//span[@class='ui-datepicker-year']";
        private const string PrevDays = "//div[@class='ui-datepicker-group ui-datepicker-group-first']//tr";
        private const string FeatureDays = "//div[@class='ui-datepicker-group ui-datepicker-group-last']//tr";
        private const string Depart = "//input[@value='Depart On']";
        private const string ConfirmPoupAlerts = "//*[@id='content']/p[8]/button";
        private const string ConfirmPromptAlert = "//button[contains(text(),'Prompt Pop up')]";

        [FindsBy(How = How.XPath, Using = Home)]
        private readonly IWebElement _HomeLink;

        public bool TsrtcHomepage()
        {
            
            IWebElement VJ = Driver.FindElement(By.XPath(VajraBooking));
            IWebElement LT = Driver.FindElement(By.XPath(LinkTicket));
            IWebElement BC = Driver.FindElement(By.XPath(BusOnContract));
            IWebElement MT = Driver.FindElement(By.XPath(MyTicket));
            IWebElement CT = Driver.FindElement(By.XPath(CancelTicket));
            IWebElement CD = Driver.FindElement(By.XPath(CancelledService));
            IWebElement AU = Driver.FindElement(By.XPath(AboutUs));
            
            IWebElement DI = Driver.FindElement(By.XPath(DriverInfo));

            return _HomeLink.Displayed &&
                        VJ.Displayed &&
                        LT.Displayed &&
                        BC.Displayed &&
                        MT.Displayed &&
                        CT.Displayed &&
                        CD.Displayed &&
                        AU.Displayed &&
                        DI.Displayed;
        }

        public void EnterUrl(string URL)
        {
            Driver.Navigate().GoToUrl(URL);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        public void LaunchBrowser()
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Manage().Window.Maximize();

        }
 
          public void  TsrtcVajraBooking()
          {
                
                IWebElement VajraBooking = Driver.FindElement(By.XPath("//a[@title='Vajra Booking']"));
                    VajraBooking.Click();
      
          }

        public void FromSelection(string _From, string _FromSuggestion)
        {
            IWebElement from = Driver.FindElement(By.XPath(From));
            from.SendKeys(_From);
            Thread.Sleep(1000);
            IList<IWebElement> fromSuggestionbox = Driver.FindElements(By.XPath(FromSuggestionBox));
            for (int i=0;i< fromSuggestionbox.Count; i++)
            {
                var Expected=fromSuggestionbox[i].Text;
                if (Expected.Equals(_FromSuggestion, StringComparison.OrdinalIgnoreCase))
                {
                    fromSuggestionbox[i].Click();
                    break;
                }
                
            }
        }

        public void ToSelection(string _To, string _ToSuggestion)
        {
            IWebElement to = Driver.FindElement(By.XPath(To));
            to.SendKeys(_To);
            Thread.Sleep(1000);
            IList<IWebElement> toSuggestionbox = Driver.FindElements(By.XPath(ToSuggestionBox));
            for (int i = 0; i < toSuggestionbox.Count; i++)
            {
                var Expected = toSuggestionbox[i].Text;
                if (Expected.Equals(_ToSuggestion, StringComparison.OrdinalIgnoreCase))
                {
                    toSuggestionbox[i].Click();
                    break;
                }

              
            }
        }
        public void Dateselection(string FromDate)
        {
            int day1 = 0;
            IWebElement _depart = Driver.FindElement(By.XPath(Depart));
            _depart.Click();
            var currentDate = DateTime.Now;
            var _fromdate = DateTime.Parse(FromDate);
            var _day = _fromdate.Day;
            if (_fromdate.Month > currentDate.Month)
            {
                IWebElement FutureMonth = Driver.FindElement(By.XPath(NextMonth));
                Assert.IsTrue(FutureMonth.Displayed);
                IWebElement FutureYear = Driver.FindElement(By.XPath(NextYear));
                Assert.IsTrue(FutureYear.Displayed);
                IList<IWebElement> Rows = Driver.FindElements(By.XPath(FeatureDays));
                for (int i = 1; i < Rows.Count; i++)
                {
                    IList<IWebElement> Columns = Driver.FindElements(By.XPath($"//div[@class='ui-datepicker-group ui-datepicker-group-last']//tr[{i}]/td"));
                    {
                        for (int j = 0; j < Columns.Count; j++)
                        {

                            string day = Columns[j].Text;
                            if (!day.Equals(" ")) { day1 = int.Parse(day); }
                            if (day1 == _day)
                            {
                                Columns[j].Click();
                                break;
                            }
                        }
                        if (day1 == _day)
                        {

                            break;
                        }
                    }
                }
            }
            else
            {
                IWebElement currenteMonth = Driver.FindElement(By.XPath(PrevMonth));
                Assert.IsTrue(currenteMonth.Displayed);
                IWebElement currentYear = Driver.FindElement(By.XPath(PrevYear));
                Assert.IsTrue(currentYear.Displayed);
                IList<IWebElement> Rows = Driver.FindElements(By.XPath(PrevDays));
                for (int i = 1; i < Rows.Count; i++)
                {
                    IList<IWebElement> Columns = Driver.FindElements(By.XPath($"//div[@class='ui-datepicker-group ui-datepicker-group-first']//tr[{i}]/td"));
                    for (int j = 0; j < Columns.Count; j++)
                    {
                       
                        string day = Columns[j].Text;
                        if(!day.Equals(" ")) {day1 = int.Parse(day); }
                        if (day1==_day)
                        {
                            Columns[j].Click();
                            break;
                        }
                    }
                    if (day1 == _day)
                    {

                        break;
                    }
                }
            }
        }

        public void StingConcepts()
        {
            
            string CustmerName = "Nagaraju";
            var length = CustmerName.Length;
            Console.WriteLine("length is"+length);
            Console.WriteLine(CustmerName.GetType());
            Console.WriteLine(CustmerName.GetTypeCode());
            Console.WriteLine(CustmerName.GetHashCode());
            var IndexOf = CustmerName.IndexOf("r");
            Console.WriteLine("IndexOf is"+ IndexOf);
            var ToLower = CustmerName.ToLower();
            Console.WriteLine("ToLower is"+ ToLower);
            var ToUpper = CustmerName.ToUpper();
            Console.WriteLine("ToUpper is"+ ToUpper);
            var Insert = CustmerName.Insert(0, "Hello");
            Console.WriteLine("Insert is"+ Insert);
            var IsNormalized = CustmerName.IsNormalized();
            Console.WriteLine("IsNormalized is"+ IsNormalized);
            var LastIndexOf = CustmerName.LastIndexOf("u");
            Console.WriteLine("LastIndexOf is"+ LastIndexOf);
            var Remove = CustmerName.Remove(5);
            Console.WriteLine("Remove is"+ Remove);
            var Replace = CustmerName.Replace('r', 'g');
            Console.WriteLine("Replace is"+ Replace);
            string[] Split = CustmerName.Split(new char[] {'a' });
            Console.WriteLine(Split[0]);
            Console.WriteLine(Split[1]);
            Console.WriteLine(Split[2]);
            Console.WriteLine(Split[3]);
            var StartsWith = CustmerName.StartsWith("N");
            Console.WriteLine("StartsWith is"+ StartsWith);
            var Substring = CustmerName.Substring(2, 5);
            Console.WriteLine("Substring is"+ Substring);
            var ToCharArray = CustmerName.ToCharArray();
            Console.WriteLine("ToCharArray is"+ ToCharArray);
            var Trim = CustmerName.Trim();
            Console.WriteLine("Trim is"+ Trim);
            string Name = "Rajugoud:(MCA@4122-2019)";
            var Start = Name.IndexOf('C');
            var EndIndex = Name.LastIndexOf(')');
            Console.WriteLine(Name.Substring(Start, EndIndex - Start));
            


        }



        public void ConfirmPopupAlert()
        {
            IWebElement Confirm = Driver.FindElement(By.XPath(ConfirmPoupAlerts));
            Thread.Sleep(1000);
            Confirm.Click();
            //Thread.Sleep(3000);
           
        }

            
        public bool ConfirmPopupAlerts()
        {
                IWebElement Confirm = Driver.FindElement(By.XPath(ConfirmPoupAlerts));
            return Confirm.Displayed;


        }

       public void AlertPopupOk()
        {
            //IAlert alert=Driver.SwitchTo().Alert();
            //string text = alert.Text;
            //alert.Accept();
            Driver.SwitchTo().Alert().Accept();
               
        }
        public void PromTopAlert()
        {

            IWebElement Promtop = Driver.FindElement(By.XPath(ConfirmPromptAlert));
            Thread.Sleep(2000);
            Console.WriteLine(Promtop.Text);
            Promtop.Click();
            Driver.SwitchTo().Alert().Accept();

        }
        public bool PromTopAlerts()
        {
            IWebElement Promtop = Driver.FindElement(By.XPath(ConfirmPromptAlert));
            return Promtop.Displayed;
        }
    }

}
