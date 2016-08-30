using System;
using BoDi;
using Coypu;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebSpecs.Pages;

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
        public static void RegisterPages()
        {
            PageFactory.Instance.Register<GooglePage>(GooglePage.AppHost);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DisposePage(GooglePage.AppHost);           
        }

        private void DisposePage(string appHost)
        {
            try
            {
                var page = objectContainer.Resolve<Page>(appHost);
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

        private Page page;

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

        private void CreatePage(Uri uri)
        {
            var configuration = new SessionConfiguration
            {
                AppHost = uri.Host,
                Port = uri.Port
            };

            try
            {
                page = objectContainer.Resolve<Page>(uri.Host);
            }
            catch (ObjectContainerException)
            {
                page = PageFactory.Instance.CreatePage(uri.Host, configuration);
                objectContainer.RegisterInstanceAs<Page>(page, uri.Host);
            }
        }

    }
}
