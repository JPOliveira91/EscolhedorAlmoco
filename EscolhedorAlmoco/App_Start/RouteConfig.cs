using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EscolhedorAlmoco
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Início",
                url: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                "Editar",
                "Restaurante/Editar/{IdRestaurante}",
                defaults: new { controller = "Restaurante", action = "Editar", IdRestaurante = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Detalhe",
                "Restaurante/Detalhe/{IdRestaurante}",
                defaults: new { controller = "Restaurante", action = "Detalhe", IdRestaurante = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Incluir",
                "Restaurante/Incluir",
                defaults: new { controller = "Restaurante", action = "Incluir" }
            );

            routes.MapRoute(
                "Restaurantes",
                "Restaurante/Index",
                defaults: new { controller = "Restaurante", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
