using WebSpecs.Support;

namespace WebSpecs.Pages.Google
{
    public abstract class BasePage : Page
    {
        protected BasePage(PageSession session, string path)
            : base(session, "www.google.com", path, true, "www.google.ca")
        {
        }
    }
}