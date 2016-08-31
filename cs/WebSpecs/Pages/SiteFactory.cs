using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Coypu;

namespace WebSpecs.Pages
{
    public class SiteFactory
    {
        public static SiteFactory Instance { get { return instance; } }

        private static readonly SiteFactory instance = new SiteFactory();

        private readonly List<Type> SiteClasses = new List<Type>();

        private SiteFactory()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var siteClass in assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Site))))
                {
                    Add(siteClass);
                }
            }
        }

        internal void Add(Type siteClass)
        {
            SiteClasses.Add(siteClass);
        }

        internal void Remove(Type siteClass)
        {
            SiteClasses.Remove(siteClass);
        }

        public Site Create(string siteName, SessionConfiguration configuration)
        {
            return (Site) Activator.CreateInstance(Find(siteName), configuration);
        }

        public Type Find(string siteName)
        {
            var matches = SiteClasses.Where(type => NamesMatch(siteName, type)).ToList();
            if (matches.Count == 0)
            {
                throw new ArgumentException(string.Format("could not find site for '{0}'", siteName));
            }
            return matches.First();
        }

        private static bool NamesMatch(string siteName, Type type)
        {
            return RemovePunctuation(type.FullName).EndsWith(RemovePunctuation(siteName));
        }

        private static string RemovePunctuation(string name1)
        {
            return Regex.Replace(name1, "\\W", "");
        }

        // Delete stuff below here
        static Dictionary<string, Type> registeredPages = new Dictionary<string, Type>();
        public void Register<T>(string appHost)
        {
            var pageClass = typeof(T);
            if (pageClass.IsAbstract || pageClass.IsInterface)
                throw new ArgumentException("Cannot create instance of interface or abstract class");

            registeredPages.Add(appHost, pageClass);
        }

        public Site CreateSite(string appHost, SessionConfiguration configuration)
        {
            Type type;

            if (!registeredPages.TryGetValue(appHost, out type))
                throw new ArgumentException("no page class registered for {0}", appHost);

            return (Site) Activator.CreateInstance(type, configuration);
        }

        public void UnRegister(string appHost)
        {
            registeredPages.Remove(appHost); ;
        }

    }
}
