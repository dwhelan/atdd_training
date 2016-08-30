using Coypu;

namespace WebSpecs.Pages.Google
{
    public class PrivacyPolicyPage : Page
    {
        public static readonly string AppHost = "www.google.com";

        public PrivacyPolicyPage(SessionConfiguration configuration) : base(configuration, AppHost)
        {
        }
    }
}