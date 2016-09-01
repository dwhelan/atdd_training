using System.Collections.Generic;
using System.Linq;

namespace WebSpecs.Support
{
    public abstract class Page
    {
        public string Host { get; private set; }
        public List<string> HostAliases { get; }
        public string Path { get; }
        public bool SSL { get; }

        protected readonly PageBrowserSession Browser;

        protected Page(PageBrowserSession browser, string host, string path, bool ssl=false, params string[] hostAliases)
        {
            Host = host;
            HostAliases = hostAliases.ToList();
            HostAliases.Add(host);
            Path = path;
            SSL = ssl;

            if (browser != null)
            {
                Browser = browser;
                Browser.Configuration.AppHost = host;
                Browser.Configuration.SSL = SSL;
            }
        }

        public void Visit()
        {
            Browser.Visit(Path);
        }

        public string Title
        {
            get { return Browser.Title; }
        }
    }
}