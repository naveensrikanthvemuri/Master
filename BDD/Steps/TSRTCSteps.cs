using System;
using TechTalk.SpecFlow;
using ConsoleApp1.PageObjectModels;
namespace ConsoleApp1.BDD.Steps
{
    [Binding]
    public class TSRTCSteps 
    {
        private readonly Tsrtc Tg = new Tsrtc();
       

        [Then(@"Click on VajraBooking")]
        public void ThenClickOnVajraBooking()
        {
            Tg.TsrtcVajraBooking();
        }

        

        [Then(@"Enter From field based on requirment '(.*)' and '(.*)'")]
        public void ThenEnterFromFieldBasedOnRequirmentAnd(string From, string FromSuggestion)
        {
            Tg.FromSelection(From, FromSuggestion);
        }

        [Then(@"Enter To Field based on requirment '(.*)' and '(.*)'")]
        public void ThenEnterToFieldBasedOnRequirmentAnd(string To, string ToSuggestion)
        {
            Tg.ToSelection(To, ToSuggestion);
        }
        [Then(@"Select Date Based on '(.*)'")]
        public void ThenSelectDateBasedOn(string Date)
        {
            Tg.Dateselection(Date);
        }

        [Then(@"Verify Tsrtc  Should be Diplayed On The Home Page")]
        public void ThenVerifyTsrtcShouldBeDiplayedOnTheHomePage()
        {
            Tg.TsrtcHomepage();
        }

        [Given(@"Navigate To '(.*)'")]
        public void GivenNavigateTo(string Url)
        {
            Tg.EnterUrl(Url);
            
        }



    }
}
