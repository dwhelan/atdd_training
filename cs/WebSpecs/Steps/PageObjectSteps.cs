using System;
using BoDi;
using Coypu;
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

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void RegisterSites()
        {
            SiteFactory.Instance.Register<GoogleSite>(GoogleSite.AppHost);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DisposeSites(GoogleSite.AppHost);           
        }

        private void DisposeSites(string appHost)
        {
            try
            {
                var page = objectContainer.Resolve<Site>(appHost);
                page.Dispose();
            }
            catch (ObjectContainerException)
            {
            }
        }
    }

    [Binding]
    public class PageObjectSteps
    {
        private readonly IObjectContainer objectContainer;

        private Site page;

        public PageObjectSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [Given(@"I browse to ""(.*)""")]
        public void GivenIBrowseTo(string url)
        {
            var uri = new Uri(url);

            CreatePage(uri);

            page.Visit(uri.PathAndQuery);
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string title)
        {
            Assert.That(page.Title, Is.EqualTo(title));
        }

        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string search)
        {
            page.ClickButton(search);
        }

        [When(@"I click the ""(.*)"" link")]
        public void WhenIClickTheLink(string name)
        {
            page.ClickLink(name);
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string text)
        {
            Assert.That(page.Browser, Shows.Content(text));
        }

        private void CreatePage(Uri uri)
        {
            var configuration = new SessionConfiguration
            {
                AppHost = uri.Host,
                Port = uri.Port
            };

            try
            {
                page = objectContainer.Resolve<Site>(uri.Host);
            }
            catch (ObjectContainerException)
            {
                page = SiteFactory.Instance.CreateSite(uri.Host, configuration);
                objectContainer.RegisterInstanceAs<Site>(page, uri.Host);
            }
        }
    }
}
