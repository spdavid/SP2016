using MyFirstSPAddinWeb.Helpers;
using MyFirstSPAddinWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstSPAddinWeb.Controllers
{
    public class TaskListController : Controller
    {
        public ActionResult Index(string SPHostUrl)
        {
            ViewBag.SPHostUrl = SPHostUrl;
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {
                if (ctx != null)
                {
                    List<SPTask> tasks = TaskHelper.GetTasksFromSharePoint(ctx);

                    return View(tasks);

                }
            }

            return View();
        }
    }
}
