using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Collections;


namespace ConsoleApp1.PageObjectModels
{
    
    public class Program: PageObjectBase
    {
       
        
         //  String Gender = "Male";
       
        public void Main()
        {

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.flipkart.com/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            IWebElement email = Driver.FindElement(By.XPath("//span[contains(text(),'Enter Email/Mobile number')]//ancestor::div[@class='_39M2dM']//input"));
            Thread.Sleep(1000);
            email.SendKeys("naveenchowdaryvemuri@gmail.com");
            Thread.Sleep(1000);
            try
            {
                IWebElement password = Driver.FindElement(By.XPath("//input[@type='password']"));
                Thread.Sleep(1000);
                password.SendKeys("Naveen@143");
                IWebElement Login = Driver.FindElement(By.XPath("//span[contains(text(),'Login')]//ancestor::div[@class='_1avdGP']//button"));
                Login.Click();
            }
            catch
            {
                IWebElement Continue = Driver.FindElement(By.XPath("//span[contains(text(),'CONTINUE')]"));
                Continue.Click();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                Driver.FindElement(By.XPath("//button[contains(text(),'Login with Password')]")).Click();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                IWebElement password = Driver.FindElement(By.XPath("//input[@type='password']"));
                Thread.Sleep(1000);
                password.SendKeys("Naveen@143");
                IWebElement Login = Driver.FindElement(By.XPath("//span[contains(text(),'Login')]//ancestor::div[@class='_1avdGP']//button"));
                Login.Click();
            }
           
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            IWebElement MyAccount = Driver.FindElement(By.XPath("//div[contains(text(),'My Account')]"));
            Actions Mouseover = new Actions(Driver);
            Mouseover.MoveToElement(MyAccount).Perform();
            IWebElement MyProfile = Driver.FindElement(By.XPath("//div[contains(text(),'My Profile')]"));
            Actions MyProfileMousehover = new Actions(Driver);
            Thread.Sleep(2000);
            MyProfileMousehover.MoveToElement(MyProfile).Perform();
            
            //Driver.Quit();


        }
      
        public void FaceBok()
        {
            //IWebDriver Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Navigate().GoToUrl("https://www.facebook.com/");
            Thread.Sleep(2000);
            IWebElement Day = Driver.FindElement(By.XPath("//select[@aria-label='Day']"));
            SelectElement day = new SelectElement(Day);
            var value= day.Options;
            Console.WriteLine(value.Count);
            day.SelectByText("23");
            IWebElement Month = Driver.FindElement(By.XPath("//select[@title='Month']"));
            SelectElement month = new SelectElement(Month);
            month.SelectByText("Dec");
            IWebElement Year = Driver.FindElement(By.XPath("//select[@title='Year']"));
            SelectElement year = new SelectElement(Year);
            year.SelectByText("1999");
            Driver.Quit();
        }
        
       public void WebTablesEx()
        {
            //IWebDriver Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
            Driver.Navigate().GoToUrl("https://www.w3schools.com/html/html_tables.asp");
            Thread.Sleep(1000);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
            IList<IWebElement> rows = Driver.FindElements(By.XPath("//table[@id='customers']/tbody/tr"));
            //foreach(IWebElement row in rows)
            //{

            //}
            List<string> mycollection = new List<string>();

            for (int i = 1; i < rows.Count; i++)
            {

                IWebElement column1value = Driver.FindElement(By.XPath("//table[@id='customers']/tbody/tr" + "[" + (i + 1) + "]" + "/td[1]"));
                mycollection.Add(column1value.Text);
                IWebElement column2value = Driver.FindElement(By.XPath("//table[@id='customers']/tbody/tr" + "[" + (i + 1) + "]" + "/td[2]"));
                mycollection.Add(column2value.Text);
                IWebElement column3value = Driver.FindElement(By.XPath("//table[@id='customers']/tbody/tr" + "[" + (i + 1) + "]" + "/td[3]"));
                mycollection.Add(column3value.Text);

            }
            for (int i = 0; i < mycollection.Count; i++)
            {
                Console.WriteLine(mycollection[i]);
            }
            Assert.AreEqual(mycollection[mycollection.Count - 1],"Italy");
            Driver.Quit();
        }
       
        public void ScreenShot()
        {
            //IWebDriver Driver = new ChromeDriver();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.goibibo.com/");
            
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Driver.FindElement(By.XPath("//i[contains(@class,'icon-flights db')]")).Click();
            Thread.Sleep(1000);
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

         
        }
        
        public void rajufb()
        {
            //IWebDriver Driver = new ChromeDriver();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(80);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.facebook.com/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(80);
            IWebElement FirstName = Driver.FindElement(By.XPath("//input[@name='firstname']"));
            Thread.Sleep(1000);
            FirstName.SendKeys("Bellamkonda");
            Thread.Sleep(1000);
            IWebElement SurName = Driver.FindElement(By.XPath("//input[@name='lastname']"));
            Thread.Sleep(1000);
            SurName.SendKeys("NagarajuGoud");
            Thread.Sleep(1000);
            IWebElement email = Driver.FindElement(By.XPath("//input[@aria-label='Mobile number or email address']"));
            Thread.Sleep(1000);
            email.SendKeys("nagaraju.goudmca@gmail.com");
            IWebElement ReName = Driver.FindElement(By.XPath("//input[@name='reg_email_confirmation__']"));
            Thread.Sleep(1000);
            ReName.SendKeys("nagaraju.goudmca@gmail.com");
            Thread.Sleep(1000);
            IWebElement NewPassord = Driver.FindElement(By.XPath("//input[@autocomplete='new-password']"));
            Thread.Sleep(1000);
            NewPassord.SendKeys("naga4122");
            Thread.Sleep(2000);
            IWebElement Day = Driver.FindElement(By.XPath("//select[@title='Day']"));
            SelectElement day = new SelectElement(Day);
             var value = day.Options;
             Console.WriteLine(value.Count);
                day.SelectByText("6");
                Thread.Sleep(1000);
               IWebElement  Month = Driver.FindElement(By.XPath("//select[@title='Month']"));
                SelectElement month = new SelectElement(Month);
                month.SelectByText("Aug");
                IWebElement Year = Driver.FindElement(By.XPath("//select[@title='Year']"));
                SelectElement year = new SelectElement(Year);
                year.SelectByText("1989");
            IWebElement radio1 = Driver.FindElement(By.XPath("//input[@value='1']"));
            IWebElement radio2 = Driver.FindElement(By.XPath("//input[@value='2']"));
            radio1.Click();
            radio2.Click();
            IWebElement Signup = Driver.FindElement(By.XPath("//button[@id='u_0_11']"));
            Signup.Click();
           // Driver.Quit();
        }
     
      public void quicker()
        {
            //IWebDriver Driver = new ChromeDriver();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.quicker.com/");
            
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

       

        public void flip2()
        {
            //IWebDriver Driver = new ChromeDriver();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.flipkart.com/");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            //IWebElement Login = Driver.FindElement(By.XPath("//a[contains(text(),'Login & Signup')]"));
            Thread.Sleep(1000);
            IWebElement phoneNumber = Driver.FindElement(By.XPath("//input[@class='_2zrpKA']"));
            Thread.Sleep(1000);

            phoneNumber.SendKeys("9182616930");
            try
            {
                IWebElement password = Driver.FindElement(By.XPath("//input[@type='password']"));
                Thread.Sleep(1000);
                password.SendKeys("12345");
                IWebElement Button = Driver.FindElement(By.XPath("//button[@class='_2AkmmA _1LctnI _7UHT_c']"));
                Thread.Sleep(1000);
                Button.Click();
                IWebElement Men = Driver.FindElement(By.XPath("//span[contains(text(),'Men')]"));
                Thread.Sleep(1000);
            }
            catch
            {
                IWebElement Continue = Driver.FindElement(By.XPath("//span[contains(text(),'CONTINUE')]"));
                Continue.Click();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                Driver.FindElement(By.XPath("//button[contains(text(),'Login with Password')]")).Click();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                IWebElement password = Driver.FindElement(By.XPath("//input[@type='password']"));
                Thread.Sleep(1000);
                password.SendKeys("12345");
                IWebElement Login = Driver.FindElement(By.XPath("//span[contains(text(),'Login')]//ancestor::div[@class='_1avdGP']//button"));
                Login.Click();
            }
            IWebElement MyAccountse = Driver.FindElement(By.XPath("//div[contains(text(),'My Account')]"));
            Thread.Sleep(1000);
            Actions Mouseover = new Actions(Driver);
            Mouseover.MoveToElement(MyAccountse).Perform();
            IWebElement MyProfile = Driver.FindElement(By.XPath("//div[contains(text(),'My Profile')]"));
            Thread.Sleep(1000);
            MyProfile.Click();
            Thread.Sleep(1000);

            IWebElement Firstname = Driver.FindElement(By.XPath("//input[@tabindex='1']"));
            //if (!Firstname.Enabled)
            //{
            Assert.Fail("First Name was Editable With out clicking on Edit button");
            //Assert.IsTrue(!Firstname.Enabled);
            //}
            //else
            //{
            Driver.FindElement(By.XPath("//span[contains(text(),'Edit')]")).Click();
            Thread.Sleep(2000);
            Firstname.SendKeys("NAGA");
            IWebElement Lastname = Driver.FindElement(By.XPath("//input[@name='lastName']"));
            Thread.Sleep(1000);
            Lastname.SendKeys("RAJU");
            Thread.Sleep(1000);
            var result = GenderSelection("Male");
            Console.WriteLine(result);
            //if (Gender.Equals("Male"))
            //{
            //    IWebElement Male = Driver.FindElement(By.XPath("//input[@id='Male']//following-sibling::div[@class='_6ATDKp']"));
            //    Male.Click();
            //    Thread.Sleep(1000);
            //}
            //else
            //{
            //    IWebElement Female = Driver.FindElement(By.XPath("//input[@id='Female']//following-sibling::div[@class='_6ATDKp']"));
            //    Female.Click();
            //    Thread.Sleep(1000);
            //}


        //}
 
        }

        public  string GenderSelection(String Gender)
        {
            if (Gender.Equals("Male"))
            {
                IWebElement Male = Driver.FindElement(By.XPath("//input[@id='Male']//following-sibling::div[@class='_6ATDKp']"));
                Male.Click();
                Thread.Sleep(1000);
            }
            else
            {
                IWebElement Female = Driver.FindElement(By.XPath("//input[@id='Female']//following-sibling::div[@class='_6ATDKp']"));
                Female.Click();
                Thread.Sleep(1000);
            }
            return Gender; 
        }

        public void LaunchBrowser()
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Manage().Window.Maximize();
            
        }

        public void NavigateToUrl()
        {
            Driver.Navigate().GoToUrl("https://www.flipkart.com/");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        public bool HomePage()
        {
            IWebElement MyAccountse = Driver.FindElement(By.XPath("//div[contains(text(),'My Account')]"));
            return MyAccountse.Displayed;
        }

        public void MyAccount()
        {
            IWebElement MyAccounts = Driver.FindElement(By.XPath("//div[contains(text(),'My Account')]"));
            Thread.Sleep(1000);
            Actions Mouseover = new Actions(Driver);
            Mouseover.MoveToElement(MyAccounts).Perform();
        }

        public void Login()
        {
            IWebElement phoneNumber = Driver.FindElement(By.XPath("//input[@class='_2zrpKA']"));
            Thread.Sleep(1000);

            phoneNumber.SendKeys("9182616930");
            try
            {
                IWebElement password = Driver.FindElement(By.XPath("//input[@type='password']"));
                Thread.Sleep(1000);
                password.SendKeys("12345");
                IWebElement Button = Driver.FindElement(By.XPath("//button[@class='_2AkmmA _1LctnI _7UHT_c']"));
                Thread.Sleep(1000);
                Button.Click();
                IWebElement Men = Driver.FindElement(By.XPath("//span[contains(text(),'Men')]"));
                Thread.Sleep(1000);
            }
            catch
            {
                IWebElement Continue = Driver.FindElement(By.XPath("//span[contains(text(),'CONTINUE')]"));
                Continue.Click();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                Driver.FindElement(By.XPath("//button[contains(text(),'Login with Password')]")).Click();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                IWebElement password = Driver.FindElement(By.XPath("//input[@type='password']"));
                Thread.Sleep(1000);
                password.SendKeys("12345");
                IWebElement Login = Driver.FindElement(By.XPath("//span[contains(text(),'Login')]//ancestor::div[@class='_1avdGP']//button"));
                Login.Click();
            }
        }

        public void EnterUrl(string URL)
        {
            Driver.Navigate().GoToUrl(URL);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        public void Credentials(string UserName,String Password)
        {
            IWebElement phoneNumber = Driver.FindElement(By.XPath("//input[@class='_2zrpKA']"));
            Thread.Sleep(1000);

            phoneNumber.SendKeys(UserName);
            try
            {
                IWebElement password = Driver.FindElement(By.XPath("//input[@type='password']"));
                Thread.Sleep(1000);
                password.SendKeys(Password);
                IWebElement Button = Driver.FindElement(By.XPath("//button[@class='_2AkmmA _1LctnI _7UHT_c']"));
                Thread.Sleep(1000);
                Button.Click();
                IWebElement Men = Driver.FindElement(By.XPath("//span[contains(text(),'Men')]"));
                Thread.Sleep(1000);
            }
            catch
            {
                IWebElement Continue = Driver.FindElement(By.XPath("//span[contains(text(),'CONTINUE')]"));
                Continue.Click();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                Driver.FindElement(By.XPath("//button[contains(text(),'Login with Password')]")).Click();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                IWebElement password = Driver.FindElement(By.XPath("//input[@type='password']"));
                Thread.Sleep(1000);
                password.SendKeys(Password);
                IWebElement Login = Driver.FindElement(By.XPath("//span[contains(text(),'Login')]//ancestor::div[@class='_1avdGP']//button"));
                Login.Click();
            }
        }

    }

}
