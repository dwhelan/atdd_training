using System;
using BoDi;
using TechTalk.SpecFlow;
using WebSpecs.Pages.Google;
using WebSpecs.Support;

namespace WebSpecs.Steps.Google
{
    [Binding]
    public class PrivacyPolicySteps : Base
    {
        private PrivacyPolicyPage MyPage { get { return (PrivacyPolicyPage)base.Page; } }

        public PrivacyPolicySteps(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        [When(@"I click on Overview")]
        public void WhenIClickOnOverview()
        {
            MyPage.Overview.Click();
        }
    }
}
