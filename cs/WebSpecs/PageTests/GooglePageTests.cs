using Coypu;
using NUnit.Framework;
using WebSpecs.Pages.Google;

namespace WebSpecs.PageTests
{
    [TestFixture]
    public class GooglePageTests
    {
        private GoogleSite site;

        [TestFixtureSetUp]
        public void CreateSite()
        {
            site = new GoogleSite(new SessionConfiguration());
        }

        [Test]
        public void Should_be_able_to_create_a_page_object()
        {
            site.Visit("/");
            Assert.That(site.Title, Is.EqualTo("Google"));
        }

        [TestFixtureTearDown]
        public void DisposeSite()
        {
            site.Dispose();
        }
    }
}
