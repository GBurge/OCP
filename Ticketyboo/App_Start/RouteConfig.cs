using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace OCP
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute("", "Home", "~/Default.aspx");
            //routes.MapPageRoute("", "TeamAdmin", "~/Views/Admin/TeamAdmin.aspx");
            //routes.MapPageRoute("EditTeam", "TeamAdmin/id={Id}", "~/Views/Admin/TeamAdmin.aspx");
        }
    }
}
