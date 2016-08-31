using Coypu;

namespace WebSpecs.Pages.Google
{
    public class GoogleSite : Site
    {
        public static readonly string AppHost = "www.google.com";

        public GoogleSite(SessionConfiguration configuration) : base(configuration, AppHost)
        {
        }
    }
}