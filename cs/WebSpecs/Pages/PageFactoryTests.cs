using Coypu;
using NUnit.Framework;

namespace WebSpecs.Pages
{
    public class TestPage : Page
    {
        internal static readonly string AppHost = "test.com";

        public TestPage(SessionConfiguration configuration) : base(configuration, AppHost)
        {
        }
    }

    [TestFixture]
    public class PageFactoryTests
    {
        private Page page;

        [Test]
        public void Should_register_pages()
        {
            Factory.Instance.Register<TestPage>(TestPage.AppHost);
            try
            {
                page = Factory.Instance.CreatePage("test.com", new SessionConfiguration());
                Assert.That(page, Is.InstanceOf(typeof(TestPage)));
            }
            finally
            {
                page.Dispose();
                Factory.Instance.UnRegister(TestPage.AppHost);
            }
        }
    }
}
