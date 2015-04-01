namespace Fanex.React.Grid
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// ROUTE CONFIG.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// REGISTER ROUTE.
        /// </summary>
        /// <param name="routes">ROUTE VALUE.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Comments",
                url: "comments",
                defaults: new { controller = "Home", action = "Comments" });

            routes.MapRoute(
                name: "CurrencyList",
                url: "currencyList",
                defaults: new { controller = "Report", action = "CurrencyList" });

            routes.MapRoute(
                name: "BaseCurrencyList",
                url: "baseCurrencyList",
                defaults: new { controller = "Report", action = "BaseCurrencyList" });

            routes.MapRoute(
                name: "ProductList",
                url: "productList",
                defaults: new { controller = "Report", action = "ProductList" });
            routes.MapRoute(
                name: "GetDataList",
                url: "getDataList",
                defaults: new { controller = "Report", action = "GetDataList" });
            routes.MapRoute(
                name: "NewComment",
                url: "comments/new",
                defaults: new { controller = "Home", action = "AddComment" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}