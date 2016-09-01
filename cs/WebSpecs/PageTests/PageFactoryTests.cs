using System;
using NUnit.Framework;
using WebSpecs.Pages;
using WebSpecs.Steps;

namespace WebSpecs.PageTests
{
    public abstract class AbstractTestPage : Page
    {
        protected AbstractTestPage(PageBrowserSession browserSession) : base(browserSession, "test.com")
        {
        }
    }

    public class TestPage : AbstractTestPage
    {
        public TestPage(PageBrowserSession browserSession) : base(browserSession)
        {
        }
    }


    [TestFixture]
    public class PageFactoryTests
    {
        [Test]
        public void Should_auto_register_sites()
        {
            Assert.That(PageFactory.Instance.Find("TestPage"), Is.EqualTo(typeof(TestPage)));
        }

        [Test]
        public void Should_not_load_abstract_site_classes()
        {
            Assert.That(PageFactory.Instance.Contains(typeof(AbstractTestPage)), Is.False);
        }

        [Test]
        public void Find_should_throw_if_site_class_cannot_be_found()
        {
            Assert.Throws<ArgumentException>(() => PageFactory.Instance.Find("There should be no site with this name"));
        }

        [TestCase("TestPage")]
        [TestCase("Test Page")]
        [TestCase("PageTests.TestPage")]
        [TestCase("WebSpecs.PageTests.TestPage")]
        public void Find_should_locate_with_partial_or_full_class_name_match(string siteName)
        {
            Assert.That(PageFactory.Instance.Find(siteName), Is.EqualTo(typeof(TestPage)));
        }

        [TestCase("PageTestsTestPage")]
        [TestCase("WebSpecsPageTestsTestPage")]
        public void Find_remove_punctuation_from_site_names(string siteName)
        {
            Assert.That(PageFactory.Instance.Find(siteName), Is.EqualTo(typeof(TestPage)));
        }
    }
}
