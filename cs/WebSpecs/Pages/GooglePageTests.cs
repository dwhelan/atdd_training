using Coypu;
using NUnit.Framework;

namespace WebSpecs.Pages
{
    [TestFixture]
    public class GooglePageTests
    {
        private GooglePage page;

        [TestFixtureSetUp]
        public void CreatePage()
        {
            page = new GooglePage(new SessionConfiguration());
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
