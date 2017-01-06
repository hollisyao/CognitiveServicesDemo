using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace IntelligentKioskSample
{
    public class AppResourcesHelper
    {
        private static ResourceLoader CurrentResourceLoader
        {
            get { return _loader ?? (_loader = ResourceLoader.GetForCurrentView("Resources")); }
        }

        private static ResourceLoader _loader;
        private static readonly Dictionary<string, string> ResourceCache = new Dictionary<string, string>();

        public static string GetString(string key)
        {
            string s;
            if (ResourceCache.TryGetValue(key, out s))
            {
                return s;
            }
            else
            {
                s = CurrentResourceLoader.GetString(key);
                ResourceCache[key] = s;
                return s;
            }
        }
    }
}
