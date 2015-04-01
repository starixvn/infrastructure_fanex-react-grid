namespace Fanex.React.Grid
{
    using System.Web.Mvc;

    /// <summary>
    /// Filter Configuration.
    /// </summary>
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}