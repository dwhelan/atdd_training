using Coypu;
using NUnit.Framework;
using WebSpecs.Pages;

namespace WebSpecs.PageTests
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
            PageFactory.Instance.Register<TestPage>(TestPage.AppHost);
            try
            {
                page = PageFactory.Instance.CreatePage("test.com", new SessionConfiguration());
                Assert.That(page, Is.InstanceOf(typeof(TestPage)));
            }
            finally
            {
                page.Dispose();
                PageFactory.Instance.UnRegister(TestPage.AppHost);
            }
        }
    }
}
