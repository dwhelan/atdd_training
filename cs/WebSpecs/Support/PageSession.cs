using Coypu;

namespace WebSpecs.Support
{
    public class PageSession : BrowserSession
    {
        public Page Page { get; set; }

        public PageSession(SessionConfiguration sessionConfiguration) : base(sessionConfiguration)
        {
        }

        public SessionConfiguration Configuration { get { return base.SessionConfiguration; } }
    }
}