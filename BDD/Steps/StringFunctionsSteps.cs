using ConsoleApp1.PageObjectModels;
using System;
using TechTalk.SpecFlow;

namespace ConsoleApp1.BDD.Steps
{
    [Binding]
    public class StringFunctionsSteps
    {
        private readonly Tsrtc Tg = new Tsrtc();

        [Given(@"Verify string functions")]
        public void GivenVerifyStringFunctions()
        {
            Tg.StingConcepts();
        }
    }
}
