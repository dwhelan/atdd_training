using Coypu;

namespace WebSpecs.Pages
{
    public class Site
    {
        public readonly BrowserSession Browser;

        public Site(SessionConfiguration configuration, string appHost)
        {
            configuration.AppHost = appHost;
            Browser = new BrowserSession(configuration);
        }

        public void Visit(string url)
        {
            Browser.Visit(url);
        }

        public void Dispose()
        {
            Browser.Dispose();
        }

        public string Title
        {
            get { return Browser.Title; }
        }

        public void ClickButton(string locator)
        {
            Browser.ClickButton(locator);
        }

        public void ClickLink(string name)
        {
            Browser.ClickLink(name);
        }
    }
}