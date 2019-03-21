using System;
using TechTalk.SpecFlow;

namespace ConsoleApp1.Amazon Steps
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Then(@"Amazon Home Page Should be displayed")]
        public void ThenAmazonHomePageShouldBeDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
