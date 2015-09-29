namespace Fanex.React.Grid.Controllers
{
    using System.Web.Mvc;
    using Fanex.React.Grid.Services;

    /// <summary>
    /// DEMO CONTROLLER.
    /// </summary>
    public class DemoController : Controller
    {
        public ActionResult FirstGrid()
        {            
            return View();
        }

        public JsonResult FirstPage(int numOfRow)
        {
            var reactService = new FirstPageService();
            var data = reactService.GetReactGridOptions(numOfRow);
            var json = Json(data);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult ShowTitle()
        {
            return View();
        }

        public ActionResult ShowFooter()
        {
            return View();
        }

        public ActionResult GroupHeader()
        {
            return View();
        }

        public ActionResult OddEven()
        {
            return View();
        }

        public ActionResult HighlightHover()
        {
            return View();
        }

        public ActionResult HighlightColumn()
        {
            return View();
        }

        public ActionResult ClientPaging()
        {
            return View();
        }

        public ActionResult ServerPaging()
        {
            return View();
        }

        public JsonResult ServerPagingData(int numOfRow, int pageIndex = 0, int pageSize = 100)
        {
            var reactService = new FirstPageService();
            var data = reactService.GetPagingGridOptions(numOfRow, pageIndex, pageSize);
            var json = Json(data);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult MergeColumn()
        {
            return View();
        }

        public JsonResult MergeColumnData(int numOfRow)
        {
            var reactService = new FirstPageService();
            var data = reactService.GetMergeColumnGridOptions(numOfRow);
            var json = Json(data);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult LargeData()
        {
            return View();
        }

        public JsonResult GetLargeData(int numOfRow, int startIndex = 0, int endIndex = 100)
        {
            var reactService = new FirstPageService();
            var data = reactService.GetLargeGridOptions(numOfRow, startIndex, endIndex);
            var json = Json(data);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult GetData(int numOfRow)
        {
            var reactService = new FirstPageService();
            var data = reactService.GetReactGridOptions(numOfRow);
            var json = Json(data);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
    }
}