namespace Fanex.React.Grid.Controllers
{
    using System.Web.Mvc;
    using Fanex.React.Grid.Services;

    /// <summary>
    /// Utility controller.
    /// </summary>
    public class UtilityController : Controller
    {        
        public ActionResult FreezeColumn()
        {
            return View();
        }

        public JsonResult FreezeColumnData(int numOfRow, int numOfFreeze)
        {
            var reactService = new UtilityService();
            var data = reactService.GetReactGridOptions(numOfRow);
            data.NumberOfFreezeColumn = numOfFreeze;
            var json = Json(data);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult RenderLink()
        {
            return View();
        }

        public JsonResult RenderLinkData(int numOfRow)
        {
            var reactService = new UtilityService();
            var data = reactService.GetReactWithLinkGridOptions(numOfRow);
            var json = Json(data);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult SortData()
        {
            return View();
        }

        public JsonResult SortDataData(int numOfRow)
        {
            var reactService = new UtilityService();
            var data = reactService.GetSortDataGridOptions(numOfRow);
            var json = Json(data);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult ShowHideColumn()
        {
            return View();
        }
    }
}