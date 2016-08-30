using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coypu;

namespace WebSpecs.Pages
{
    public class Factory
    {
        public static Factory Instance { get { return instance; } }

        private static readonly Factory instance = new Factory();

        private Factory() { }

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
