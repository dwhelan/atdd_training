using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebSpecs
{
    [TestFixture]
    public class FireFoxDriverTest
    {
        private FirefoxDriver driver;
        
        [Test]
        [Ignore]
        public void Firefox48()
        {
            driver = new FirefoxDriver(new FirefoxOptions());
            TestGoogleSearch();
        }

        [Test]
        public void Firefox35()
        {
            driver = new FirefoxDriver();
            TestGoogleSearch();
        }

        private void TestGoogleSearch()
        {
            driver.Navigate().GoToUrl("http://www.google.com.au");

            var query = driver.FindElement(By.Name("q"));
            query.SendKeys("Selenium");
            query.SendKeys(Keys.Return);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until((d) => d.Title.StartsWith("Selenium"));

            Assert.That(driver.Title, Is.EqualTo("Selenium - Google Search"));
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Dispose();
        }
    }
}
