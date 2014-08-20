using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using DAF.Business;
using DAF.DataAccess;

namespace DAF.Web.Helpers
{
    public static class CacheManager
    {
        private static Cache Cache
        {
            get { return HttpContext.Current.Cache; }
        }

        private static Dictionary<string, TextContent> TextContents
        {
            set { Cache[Constants.CC_TextContents] = value; }
            get { return Cache[Constants.CC_TextContents] as Dictionary<string, TextContent>; }
        }

        public static TextContent GetTextContent(string controlName)
        {
            if (TextContents == null)
            {
                TextContents = new Dictionary<string, TextContent>();
            }
            if (!TextContents.ContainsKey(controlName) || TextContents[controlName] == null)
            {
                TextContents[controlName] = TextContentManager.GetTextContent(controlName);
            }
            return TextContents[controlName];
        }

        public static void RefreshTextContent(string controlName)
        {
            if (TextContents == null)
            {
                TextContents = new Dictionary<string, TextContent>();
            }
            if (TextContents.ContainsKey(controlName))
            {
                lock (TextContents)
                {
                    TextContents.Remove(controlName);
                }
            }
        }

        public static List<Feature> GetMainFeatures()
        {
            if (Cache[Constants.CC_Features] == null)
            {
                Cache[Constants.CC_Features] = FeaturesManager.GetFeatures(null);
            }
            return Cache[Constants.CC_Features] as List<Feature>;
        }

    }
}
