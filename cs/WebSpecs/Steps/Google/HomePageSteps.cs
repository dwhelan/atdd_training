using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebSpecs.Pages.Google;
using WebSpecs.Support;

namespace WebSpecs.Steps.Google
{
    [Binding]
    public class HomePageSteps : Base
    {
        private HomePage HomePage { get { return (HomePage) Page; } }

        public HomePageSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        [When(@"I select Privacy")]
        public void WhenIClickOnPrivacy()
        {
            HomePage.Privacy.Click();
        }

        [When(@"I select ""I'm Feeling Lucky""")]
        public void WhenISelectImFeelingLucky()
        {
            HomePage.ImFeelingLucky.Click();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string text)
        {
            HomePage.Search(text);
        }
    }
}
