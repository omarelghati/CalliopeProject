using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Calliope
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "groupes",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Enseignant", action = "Groupe", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Profile",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Enseignant", action = "Profil", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Evaluations",
                url: "Enseignant/Evaluations/Details/{evalId}/{nivId}",
                defaults: new { controller = "Enseignant", action = "EvaluationDetails", id = UrlParameter.Optional }
            );
        }
    }
}
