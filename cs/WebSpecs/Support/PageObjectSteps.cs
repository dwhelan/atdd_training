using BoDi;
using Coypu.NUnit.Matchers;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WebSpecs.Support
{
    [Binding]
    public class PageObjectSteps : Base
    {
        public PageObjectSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        [Given(@"I browse to the ""(.*)""")]
        public void GivenIBrowseToThe(string pageName)
        {
            PageFor(pageName);
            Page.Visit("/");
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string title)
        {
            Assert.That(Page.Title, Is.EqualTo(title));
        }

        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string search)
        {
            browser.ClickButton(search);
        }

        [When(@"I click the ""(.*)"" link")]
        public void WhenIClickTheLink(string name)
        {
            browser.ClickLink(name);
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string text)
        {
            Assert.That(browser, Shows.Content(text));
        }
    }
}
