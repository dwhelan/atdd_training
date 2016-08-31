using Coypu;
using NUnit.Framework;
using WebSpecs.Pages;

namespace WebSpecs.PageTests
{
    public class TestSite : Site
    {
        internal static readonly string AppHost = "test.com";

        public TestSite(SessionConfiguration configuration) : base(configuration, AppHost)
        {
        }
    }

    [TestFixture]
    public class SiteFactoryTests
    {
        private Site site;

        [Test]
        public void Should_register_sites()
        {
            SiteFactory.Instance.Register<TestSite>(TestSite.AppHost);
            try
            {
                site = SiteFactory.Instance.CreateSite("test.com", new SessionConfiguration());
                Assert.That(site, Is.InstanceOf(typeof(TestSite)));
            }
            finally
            {
                site.Dispose();
                SiteFactory.Instance.UnRegister(TestSite.AppHost);
            }
        }
    }
}
