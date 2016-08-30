using System;
using System.Collections.Generic;
using Coypu;

namespace WebSpecs.Pages
{
    public class PageFactory
    {
        public static PageFactory Instance { get { return instance; } }

        private static readonly PageFactory instance = new PageFactory();

        private PageFactory() { }

        static Dictionary<string, Type> registeredPages = new Dictionary<string, Type>();

        public void Register<T>(string appHost)
        {
            var pageClass = typeof(T);
            if (pageClass.IsAbstract || pageClass.IsInterface)
                throw new ArgumentException("Cannot create instance of interface or abstract class");

            registeredPages.Add(appHost, pageClass);
        }

        public Page CreatePage(string appHost, SessionConfiguration configuration)
        {
            Type type;

            if (!registeredPages.TryGetValue(appHost, out type))
                throw new ArgumentException("no page class registered for {0}", appHost);

            return (Page) Activator.CreateInstance(type, configuration);
        }

        public void UnRegister(string appHost)
        {
            registeredPages.Remove(appHost); ;
        }
    }
}
