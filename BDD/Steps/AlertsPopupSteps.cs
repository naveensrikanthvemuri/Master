using System;
using TechTalk.SpecFlow;
using ConsoleApp1.PageObjectModels;
namespace ConsoleApp1.BDD.Steps
{
    [Binding]
    public class AlertsPopupSteps
    {
        private readonly  Tsrtc Tg = new Tsrtc();
        [Then(@"Verify  Toolsqa  Should be Diplayed On The Home Page")]
        public void ThenVerifyToolsqaShouldBeDiplayedOnTheHomePage()
        {
            Tg.ConfirmPopupAlerts();
        }
        
        [Then(@"Click on the poup button")]
        public void ThenClickOnThePoupButton()
        {
            Tg.ConfirmPopupAlert();
        }
        [Then(@"Click on Alert popup")]
        public void ThenClickOnAlertPopup()
        {
            Tg.AlertPopupOk();
        }


    }
}
