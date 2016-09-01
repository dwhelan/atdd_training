using System;
using Coypu;
using OpenQA.Selenium;
using WebSpecs.Support;

namespace WebSpecs.Pages.Google
{
    public class HomePage : BasePage
    {
        public ElementScope SearchText { get { return Browser.FindField("q"); } }
        public ElementScope ImFeelingLucky { get { return Browser.FindButton("I'm Feeling Lucky"); } }
        public ElementScope Privacy { get { return Browser.FindLink("Privacy"); } }

        public HomePage(PageBrowserSession browser) : base(browser, "/")
        {
        }

        public void Search(string text)
        {
            Browser.FillIn("q", new Options { Timeout = TimeSpan.FromSeconds(10) }).With(text + Keys.Return );  
        }
    }
}