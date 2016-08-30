using System;
using BoDi;
using Coypu;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebSpecs.Pages;

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

    [Binding]
    public class PageObjectSteps
    {
        private readonly IObjectContainer objectContainer;

        private GooglePage page;

        public PageObjectSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [Given(@"I browse to ""(.*)""")]
        public void GivenIBrowseTo(string url)
        {
            var uri = new Uri(url);

            var configuration = new SessionConfiguration
            {
                AppHost = uri.Host,
                Port = uri.Port
            };

            page = new GooglePage(configuration);
            page.Visit(uri.PathAndQuery);
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string title)
        {
            Assert.That(page.Title, Is.EqualTo(title));
        }
    }
}
