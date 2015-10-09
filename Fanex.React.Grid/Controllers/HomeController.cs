namespace Fanex.React.Grid.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// HOME CONTROLLER.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Overview.cshtml");
        }

        public ActionResult Overview()
        {
            return View();
        }

        public ActionResult GettingStarted()
        {
            return View();
        }
    }
}