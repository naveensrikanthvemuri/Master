using System;
using TechTalk.SpecFlow;
using ConsoleApp1.PageObjectModels;
namespace ConsoleApp1.BDD


{
    [Binding]
    public class TSRTCSteps
    {
        private readonly Tsrtc Tg = new Tsrtc();
        [Then(@"click on the prompttoup button")]
        public void ThenClickOnThePrompttoupButton()
        {
            Tg.PromTopAlert();
        }                   

        [Then(@"click on Ok button of the Alert")]
        public void ThenClickOnOkButtonOfTheAlert()
        {
            Tg.PromTopAlerts();
        }
    }
}
