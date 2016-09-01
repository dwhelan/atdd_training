using WebSpecs.Support;

namespace WebSpecs.Pages.Google
{
    public abstract class BasePage : Page
    {
        protected BasePage(PageBrowserSession browserSession) : base(browserSession, "www.google.com", "www.google.ca")
        {
        }
    }
}