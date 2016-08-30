using Coypu;
using NUnit.Framework;

namespace WebSpecs
{
    [TestFixture]
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
            TestGoogleSearch(); ;
        }

        [Test]
        public void Firefox35()
        {
            sessionConfiguration.Browser = Coypu.Drivers.Browser.Firefox;
            TestGoogleSearch();
        }

        [Test]
        public void InernetExplorer()
        {
            sessionConfiguration.Browser = Coypu.Drivers.Browser.InternetExplorer;
            TestGoogleSearch();
        }

        [Test, RequiresSTA]
        public void InernetExplorer_with_WatiN()
        {
            sessionConfiguration.Driver = typeof(Coypu.Drivers.Watin.WatiNDriver);
            sessionConfiguration.Browser = Coypu.Drivers.Browser.InternetExplorer;
            TestGoogleSearch();
        }

        [Test]
        public void Chrome()
        {
            sessionConfiguration.Browser = Coypu.Drivers.Browser.Chrome;
            TestGoogleSearch();
        }

        [Test]
        public void Phantomjs()
        {
            sessionConfiguration.Browser = Coypu.Drivers.Browser.PhantomJS;
            TestGoogleSearch();
        }

        private void TestGoogleSearch()
        {
            browser = new BrowserSession(sessionConfiguration);
            browser.Visit("/");
        }

        [TearDown]
        public void DisposeBrowser()
        {
            browser.Dispose();
        }
    }
}
