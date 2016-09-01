using System;
using BoDi;
using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using Coypu.NUnit.Matchers;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebSpecs.Pages;
using WebSpecs.Pages.Google;

namespace WebSpecs.Steps
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private BrowserSession browser;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Before()
        {
            var configuration = new SessionConfiguration
            {
                // Uncomment the Browser you want
                Browser = Browser.Firefox,
                //Browser = Browser.Chrome,
                //Browser = Browser.InternetExplorer,
                //Browser = Browser.PhantomJS,
            };
            browser = new PageBrowserSession(configuration);
            objectContainer.RegisterInstanceAs(browser);
        }

        [AfterScenario]
        public void DisposeSites()
        {
            browser.Dispose();
        }
    }

    public class PageBrowserSession : BrowserSession
    {
        public PageBrowserSession(SessionConfiguration sessionConfiguration) : base(sessionConfiguration)
        {
        }

        public SessionConfiguration Configuration { get { return SessionConfiguration; } }
    }

    [Binding]
    public class PageObjectSteps
    {
        private readonly PageBrowserSession browser;

        public PageObjectSteps(PageBrowserSession browser)
        {
            this.browser = browser;
        }

        [Given(@"I browse to the ""(.*)""")]
        public void GivenIBrowseToThe(string pageName)
        {
            PageFor(pageName).Visit("/");
        }

        [Given(@"I browse to ""(.*)""")]
        public void GivenIBrowseTo(string url)
        {
            browser.Visit(url);
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string title)
        {
            Assert.That(browser.Title, Is.EqualTo(title));
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

        private Page PageFor(string pageName)
        {
            return PageFactory.Instance.Create(pageName, browser);
        }
    }
}
