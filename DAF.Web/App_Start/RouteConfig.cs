using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using DAF.Web.Helpers;
using Microsoft.AspNet.FriendlyUrls;

namespace DAF.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();
            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.MapPageRoute(Constants.RN_Application_View, string.Format("application/{{{0}}}", Constants.RQ_Application), "~/ApplicationView.aspx");
        }
    }
}
