using Coypu;

namespace WebSpecs.Pages.Google
{
    public class HomePage : Page
    {
        public static readonly string AppHost = "www.google.com";

        public HomePage(SessionConfiguration configuration) : base(configuration, AppHost)
        {
        }
    }
}