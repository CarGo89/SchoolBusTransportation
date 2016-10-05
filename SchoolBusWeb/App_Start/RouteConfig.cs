using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolBusWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SchoolYearRoute",
                url: "CicloEscolar/{action}/{id}",
                defaults: new { controller = "SchoolYear", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DriverRoute",
                url: "Chofer/{action}/{id}",
                defaults: new { controller = "Driver", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BusRoute",
                url: "Camion/{action}/{id}",
                defaults: new { controller = "Bus", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "StudentRoute",
                url: "Alumno/{action}/{id}",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TutorRoute",
                url: "Tutor/{action}/{id}",
                defaults: new { controller = "Tutor", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AddressRoute",
                url: "Domicilio/{action}/{id}",
                defaults: new { controller = "Address", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RelationshipTermRoute",
                url: "Parentezco/{action}/{id}",
                defaults: new { controller = "RelationshipTerm", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}