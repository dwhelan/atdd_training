using System;
using System.Collections.Generic;
using System.Linq;
using BoDi;
using Coypu;
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

        [When(@"I click on Privacy")]
        public void WhenIClickOnPrivacy()
        {
            HomePage.Privacy.Click();
            Page = new PrivacyPolicyPage(Browser);
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string text)
        {
            HomePage.Search(text);
        }

        [Then(@"the search entry should be ""(.*)""")]
        public void ThenTheSearchEntryShouldBe(string text)
        {
            Assert.That(HomePage.SearchText.Value, Is.EqualTo(text));
        }
    }

    //public static class ExtensionOperation
    //{
    //    public static SessionConfiguration Configuration(this BrowserSession browser)
    //    {
    //        return browser.SessionConfiguration;
    //    }

    //    public static void Click<T>(this ElementScope element) where T : Page
    //    {
    //        element.Click();
    //        PageFactory.Instance.Create(typeof(T), (PageBrowserSession) element.Browser);
    //    }
    //}
}
