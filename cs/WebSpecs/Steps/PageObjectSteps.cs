using BoDi;
using Coypu;
using Coypu.Drivers;
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
    public abstract class BrowserSteps
    {
        protected readonly IObjectContainer objectContainer;
        protected readonly PageBrowserSession browser;
        protected Page Page { get { return objectContainer.Resolve<Page>(); } }

        protected BrowserSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
            browser = objectContainer.Resolve<PageBrowserSession>();
        }

        protected void PageFor(string pageName)
        {
            var page = PageFactory.Instance.Create(pageName, browser);
            objectContainer.RegisterInstanceAs(page, typeof(Page));
        }
    }

    [Binding]
    public class PageObjectSteps : BrowserSteps
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

    [Binding]
    public class GoogleHomePageSteps : BrowserSteps
    {
        private HomePage HomePage { get { return (HomePage) base.Page; } }

        public GoogleHomePageSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        [When(@"I click on Privacy")]
        public void WhenIClickOnPrivacy()
        {
            HomePage.Privacy.Click();
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
}
