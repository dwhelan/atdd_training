using Coypu;
using WebSpecs.Support;

namespace WebSpecs.Pages.Google
{
    public class PrivacyPolicyPage : BasePage
    {
        public ElementScope Overview { get { return Browser.FindLink("Overview"); } }

        public PrivacyPolicyPage(PageBrowserSession browser) : base(browser, "/intl/en/policies/privacy/")
        {
        }
    }
}