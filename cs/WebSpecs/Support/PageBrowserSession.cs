using Coypu;

namespace WebSpecs.Support
{
    public class PageBrowserSession : BrowserSession
    {
        public PageBrowserSession(SessionConfiguration sessionConfiguration) : base(sessionConfiguration)
        {
        }

        public SessionConfiguration Configuration { get { return SessionConfiguration; } }
    }
}