using System.Collections.Generic;
using System.Linq;

namespace WebSpecs.Support
{
    public abstract class Page
    {
        public List<string> HostAliases { get; private set; }
        public readonly PageBrowserSession Browser;
        public string Host { get; private set; }

        protected Page(PageBrowserSession browser, string host, params string[] hostAliases)
        {
            Host = host;
            HostAliases = hostAliases.ToList();
            HostAliases.Add(host);

            if (browser != null)
            {
                Browser = browser;
                Browser.Configuration.AppHost = host;
            }
        }

        public void Visit(string url)
        {
            Browser.Visit(url);
        }

        public string Title
        {
            get { return Browser.Title; }
        }
    }
}