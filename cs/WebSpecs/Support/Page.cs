namespace WebSpecs.Support
{
    public abstract class Page
    {
        public readonly PageBrowserSession Browser;

        protected Page(PageBrowserSession browser, string host)
        {
            Browser = browser;
            Browser.Configuration.AppHost = host;
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

        public bool HasContent(string text)
        {
            return Browser.HasContent(text);
        }
    }
}