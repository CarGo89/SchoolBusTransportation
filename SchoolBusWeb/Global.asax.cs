using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using SchoolBusWeb.Models.Mappings;

namespace SchoolBusWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg => cfg.AddProfile<ModelMapperProfile>());
        }
    }
}