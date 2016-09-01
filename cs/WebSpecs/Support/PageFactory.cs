using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebSpecs.Support
{
    public class PageFactory
    {
        public static PageFactory Instance { get { return instance; } }

        private static readonly PageFactory instance = new PageFactory();

        private readonly List<Type> pageClasses = new List<Type>();

        private PageFactory()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var siteClass in assembly.GetTypes().Where(IsValidPageClass))
                {
                    Add(siteClass);
                }
            }
        }

        internal void Add(Type pageClass)
        {
            pageClasses.Add(pageClass);
        }

        internal void Remove(Type pageClass)
        {
            pageClasses.Remove(pageClass);
        }

        internal bool Contains(Type siteClass)
        {
            return pageClasses.Contains(siteClass);
        }

        public Page Create(string pageName, PageBrowserSession browser)
        {
            return (Page) Activator.CreateInstance(Find(pageName), browser);
        }

        internal Type Find(string pageName)
        {
            var matches = pageClasses.Where(type => PageNameMatchesPageClass(pageName, type)).ToList();
            if (matches.Count == 0)
            {
                throw new ArgumentException(string.Format("could not find site for '{0}'", pageName));
            }
            return matches.First();
        }

        private static bool IsValidPageClass(Type type)
        {
            return type.IsSubclassOf(typeof(Page)) && !type.IsAbstract;
        }

        private static bool PageNameMatchesPageClass(string pageName, Type type)
        {
            return RemovePunctuation(type.FullName).EndsWith(RemovePunctuation(pageName));
        }

        private static string RemovePunctuation(string name1)
        {
            return Regex.Replace(name1, "\\W", "");
        }
    }
}
