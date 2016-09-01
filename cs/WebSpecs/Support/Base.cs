using System.Collections.Generic;
using System.Linq;
using BoDi;

namespace WebSpecs.Support
{
    public abstract class Base
    {
        protected readonly IObjectContainer ObjectContainer;
        protected readonly PageBrowserSession Browser;
        private readonly List<Page> pages = new List<Page>();

        protected Page Page
        {
            get { return pages[0]; }
            set { pages.Clear(); pages.Add(value); }
        }

        protected Base(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
            Browser = objectContainer.Resolve<PageBrowserSession>();
            pages = objectContainer.Resolve<List<Page>>();
        }

        protected Page PageFor(string pageName)
        {
            return Page = PageFactory.Instance.Create(pageName, Browser);
        }
    }
}