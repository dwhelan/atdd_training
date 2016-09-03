using WebSpecs.Support;

namespace WebSpecs.Pages.Google
{
    public abstract class BasePage : Page
    {
        protected BasePage(PageBrowserSession browserSession, string path)
            : base(browserSession, "www.google.com", path, true, "www.google.ca")
        {
        }
    }
}