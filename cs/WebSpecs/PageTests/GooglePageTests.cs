using Coypu;
using NUnit.Framework;
using WebSpecs.Pages;
using WebSpecs.Pages.Google;

namespace WebSpecs.PageTests
{
    [TestFixture]
    public class GooglePageTests
    {
        private GoogleSite page;

        [TestFixtureSetUp]
        public void CreatePage()
        {
            page = new GoogleSite(new SessionConfiguration());
        }

        [Test]
        public void Should_be_able_to_create_a_page_object()
        {
            page.Visit("/");
            Assert.That(page.Title, Is.EqualTo("Google"));
        }

        [TestFixtureTearDown]
        public void DisposePage()
        {
            page.Dispose();
        }
    }
}
