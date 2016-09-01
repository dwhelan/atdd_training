using Coypu;
using WebSpecs.Steps;

namespace WebSpecs.Pages.Google
{
    public class GoogleSite : Site
    {
        public static string AppHost
        {
            get { return "www.google.com"; }
        }

        public GoogleSite(SessionConfiguration configuration) : base(configuration, AppHost)
        {
        }
        public GoogleSite(PageBrowserSession browserSession) : base(browserSession)
        {
            browserSession.Configuration.AppHost = "www.google.com";
        }
    }
}