using System;
using Coypu;
using OpenQA.Selenium;
using WebSpecs.Support;

namespace WebSpecs.Pages.Google
{
    public class HomePage : BasePage
    {
        public ElementScope SearchText     => Browser.FindField("q");
        public ElementScope ImFeelingLucky => Browser.FindButton("I'm Feeling Lucky");
        public ElementScope Privacy        => Browser.FindLink("Privacy");

        public HomePage(PageSession browser) : base(browser, "/")
        {
        }

        public void Search(string text)
        {
            Browser.FillIn("q", new Options { Timeout = TimeSpan.FromSeconds(10) }).With(text + Keys.Return );  
        }
    }
}