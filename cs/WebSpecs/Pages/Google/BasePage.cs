using WebSpecs.Steps;

namespace WebSpecs.Pages.Google
{
    public abstract class BasePage : Page
    {
        protected BasePage(PageBrowserSession browserSession) : base(browserSession, "www.google.com")
        {
        }
    }
}