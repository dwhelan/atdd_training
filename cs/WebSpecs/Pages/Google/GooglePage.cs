using Coypu;
using WebSpecs.Steps;

namespace WebSpecs.Pages.Google
{
    public class GooglePage : Page
    {
        public static string AppHost
        {
            get { return "www.google.com"; }
        }

        public GooglePage(PageBrowserSession browserSession) : base(browserSession)
        {
            browserSession.Configuration.AppHost = "www.google.com";
        }
    }
}