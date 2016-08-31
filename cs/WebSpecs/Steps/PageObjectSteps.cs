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
                var site = objectContainer.Resolve<Site>(appHost);
                site.Dispose();
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
        private Site site;

        public PageObjectSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [Given(@"I browse to the ""(.*)""")]
        public void GivenIBrowseToThe(string siteName)
        {
            CreateSite2(siteName);
            site.Visit("/");
        }

        [Given(@"I browse to ""(.*)""")]
        public void GivenIBrowseTo(string url)
        {
            var uri = new Uri(url);

            CreateSite(uri);

            site.Visit(uri.PathAndQuery);
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string title)
        {
            Assert.That(site.Title, Is.EqualTo(title));
        }

        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string search)
        {
            site.ClickButton(search);
        }

        [When(@"I click the ""(.*)"" link")]
        public void WhenIClickTheLink(string name)
        {
            site.ClickLink(name);
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string text)
        {
            Assert.That(site.Browser, Shows.Content(text));
        }

        private void CreateSite2(string siteName)
        {
            try
            {
                site = objectContainer.Resolve<Site>(siteName);
            }
            catch (ObjectContainerException)
            {
                var type = SiteFactory.Instance.Find(siteName);
                var configuration = new SessionConfiguration
                {
                    AppHost = "www.google.com"
                };
                site = (Site)Activator.CreateInstance(type, configuration);

                objectContainer.RegisterInstanceAs<Site>(site, siteName);
            }
        }

        private void CreateSite(Uri uri)
        {
            var configuration = new SessionConfiguration
            {
                AppHost = uri.Host,
                Port = uri.Port
            };

            try
            {
                site = objectContainer.Resolve<Site>(uri.Host);
            }
            catch (ObjectContainerException)
            {
                site = SiteFactory.Instance.CreateSite(uri.Host, configuration);
                objectContainer.RegisterInstanceAs<Site>(site, uri.Host);
            }
        }
    }
}
