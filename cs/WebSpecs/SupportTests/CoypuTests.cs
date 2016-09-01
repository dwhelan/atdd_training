using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Watin;
using NUnit.Framework;

namespace WebSpecs
{
    [TestFixture, Ignore]
    public class CoypuTests
    {
        private BrowserSession browser;
        private SessionConfiguration sessionConfiguration;

        [SetUp]
        public void CreateSessionConfiguration()
        {
            sessionConfiguration = new SessionConfiguration
            {
                AppHost = "google.com"
            };
        }

        [Test]
        public void Default()
        {
            TestGoogleSearch();
        }

        [Test]
        public void Firefox35()
        {
            sessionConfiguration.Browser = Browser.Firefox;
            TestGoogleSearch();
        }

        [Test]
        public void InernetExplorer()
        {
            sessionConfiguration.Browser = Browser.InternetExplorer;
            TestGoogleSearch();
        }

        [Test, RequiresSTA]
        public void InternetExplorer_with_WatiN()
        {
            sessionConfiguration.Driver = typeof(WatiNDriver);
            sessionConfiguration.Browser = Browser.InternetExplorer;
            TestGoogleSearch();
        }

        [Test]
        public void Chrome()
        {
            sessionConfiguration.Browser = Browser.Chrome;
            TestGoogleSearch();
        }

        [Test]
        public void Phantomjs()
        {
            sessionConfiguration.Browser = Browser.PhantomJS;
            TestGoogleSearch();
        }

        private void TestGoogleSearch()
        {
            browser = new BrowserSession(sessionConfiguration);
            browser.Visit("/");
            Assert.That(browser.Title, Is.EqualTo("Google"));
        }

        [TearDown]
        public void DisposeBrowser()
        {
            browser.Dispose();
        }
    }
}
