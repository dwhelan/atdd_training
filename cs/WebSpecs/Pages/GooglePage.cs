using Coypu;

namespace WebSpecs.Pages
{
    public class GooglePage : Page
    {
        public static readonly string AppHost = "google.com";

        public GooglePage(SessionConfiguration configuration) : base(configuration, AppHost)
        {
        }
    }
}