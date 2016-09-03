using System;
using NUnit.Framework;
using WebSpecs.Support;

namespace WebSpecs.SupportTests
{
    public abstract class AbstractTestPage : Page
    {
        protected AbstractTestPage(PageBrowserSession browserSession, string path) : base(browserSession, "test.com", path, false)
        {
        }
    }

    public class TestPage : AbstractTestPage
    {
        public TestPage(PageBrowserSession browserSession) : base(browserSession, "path")
        {
        }
    }


    [TestFixture]
    public class PageFactoryTests
    {
        [Test]
        public void Should_auto_register_sites()
        {
            Assert.That(PageFactory.Instance.PageClassFor("TestPage"), Is.EqualTo(typeof(TestPage)));
        }

        [Test]
        public void Should_not_load_abstract_site_classes()
        {
            Assert.That(PageFactory.Instance.Contains(typeof(AbstractTestPage)), Is.False);
        }

        [Test]
        public void Find_should_throw_if_site_class_cannot_be_found()
        {
            Assert.Throws<ArgumentException>(() => PageFactory.Instance.PageClassFor("There should be no site with this name"));
        }

        [TestCase("TestPage")]
        [TestCase("Test Page")]
        [TestCase("SupportTests.TestPage")]
        [TestCase("WebSpecs.SupportTests.TestPage")]
        public void Find_should_locate_with_partial_or_full_class_name_match(string siteName)
        {
            Assert.That(PageFactory.Instance.PageClassFor(siteName), Is.EqualTo(typeof(TestPage)));
        }

        [TestCase("SupportTestsTestPage")]
        [TestCase("WebSpecsSupportTestsTestPage")]
        public void Find_remove_punctuation_from_site_names(string siteName)
        {
            Assert.That(PageFactory.Instance.PageClassFor(siteName), Is.EqualTo(typeof(TestPage)));
        }
    }
}
