using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Linq;

namespace ConsoleApp1
{
    public static class WebdriverServiceLocator
    { 
        private static readonly Func<bool> FeatureDriverIsAvailable = () => FeatureContext.Current!=null &&FeatureContext.Current.ContainsKey("Driver");
        private static readonly Func<bool> GlobalDriverIsAvailable = () => GlobalDriver != null;
        public static IWebDriver GlobalDriver;

        private static readonly Func<bool> ScenarioDriverIsAvailable=() => ScenarioContext.Current !=null && ScenarioContext.Current.ContainsKey("Driver");

        public static IWebDriver Driver =>
            ScenarioDriverIsAvailable() ? (IWebDriver)ScenarioContext.Current["Driver"]
            : FeatureDriverIsAvailable() ? (IWebDriver)FeatureContext.Current["Driver"]
            : GlobalDriverIsAvailable() ? GlobalDriver
            : throw new ArgumentException("Please initialize the webDriver from either your FeatureContext/Scenario context Hooks or Globally");

    }
}
