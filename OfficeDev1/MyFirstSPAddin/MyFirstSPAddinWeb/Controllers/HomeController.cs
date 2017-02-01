using Microsoft.SharePoint.Client;
using MyFirstSPAddinWeb.Helpers;
using MyFirstSPAddinWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstSPAddinWeb.Controllers
{
    public class HomeController : Controller
    {
        [SharePointContextFilter]
        public ActionResult Index()
        {
            User spUser = null;

            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {
                if (ctx != null)
                {
                    spUser = ctx.Web.CurrentUser;

                    ctx.Load(ctx.Web);
                    ctx.Load(spUser, user => user.Title);

                    ctx.ExecuteQuery();

                    ViewBag.Web = ctx.Web.Title;
                    ViewBag.UserName = spUser.Title;

                    TaskHelper.CreateTaskListIfNotExists(ctx);
                }
            }

            return View();
        }

        [SharePointContextFilter]
        public ActionResult AllTasks()
        {
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

        [SharePointContextFilter]
        public ActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTask(SPTask task, string SPHostUrl )
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {
                if (ctx != null)
                {
                    TaskHelper.Addtask(ctx, task);
                }
            }
            return RedirectToAction("Alltasks", new { SPHostUrl = SPHostUrl });
            
        }

        public ActionResult About()
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {
                if (ctx != null)
                {


                }
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
