using BoDi;
using Coypu;
using Coypu.Drivers;
using TechTalk.SpecFlow;

namespace WebSpecs.Support
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private BrowserSession browser;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Before()
        {
            var configuration = new SessionConfiguration
            {
                // Uncomment the Browser you want
                //Browser = Browser.Firefox,
                //Browser = Browser.Chrome,
                //Browser = Browser.InternetExplorer,
                Browser = Browser.PhantomJS,
            };
            browser = new PageBrowserSession(configuration);
            objectContainer.RegisterInstanceAs(browser);
        }

        [AfterScenario]
        public void DisposeSites()
        {
            browser.Dispose();
        }
    }
}