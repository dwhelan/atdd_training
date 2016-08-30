using Coypu;
using NUnit.Framework;

using BoDi;
using TechTalk.SpecFlow;

namespace WebSpecs
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
            browser = new BrowserSession(new SessionConfiguration { AppHost = "google.com" });
            objectContainer.RegisterInstanceAs(browser);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            browser.Dispose();
        }
    }

    [TestFixture]
    public class PageObjectTests
    {
        private BrowserSession browser;

        [Test]
        public void Should_be_able_to_create_a_page_object()
        {
            browser = new BrowserSession(new SessionConfiguration {AppHost = "google.com"});
            var page = new GooglePage(browser);
            page.Visit("/");
            Assert.That(page.Title, Is.EqualTo("Google"));
        }
    }

    public class GooglePage
    {
        private readonly BrowserSession browser;

        public GooglePage(BrowserSession browser)
        {
            this.browser = browser;
        }

        public string Title
        {
            get { return browser.Title; }
        }

        public void Visit(string url)
        {
            browser.Visit(url);
        }
    }
}
