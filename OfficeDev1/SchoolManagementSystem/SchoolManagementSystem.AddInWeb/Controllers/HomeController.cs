using Microsoft.SharePoint.Client;
using SchoolManagementSystem.AddInWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.AddInWeb.Controllers
{
    public class HomeController : Controller
    {
        [SharePointContextFilter]
        public ActionResult Index()
        {
            User spUser = null;

            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                if (clientContext != null)
                {
                    spUser = clientContext.Web.CurrentUser;

                    clientContext.Load(spUser, user => user.Title);

                    clientContext.ExecuteQuery();

                    ViewBag.UserName = spUser.Title;
                }
            }

            return View();
        }

        [SharePointContextFilter]
        public ActionResult School(string SPHostUrl, int itemId)
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                if (clientContext != null)
                {
                    ViewBag.SPHostUrl = SPHostUrl;
                    ViewBag.SchoolId = itemId;
                    School school = SchoolHelper.GetSchoolFromItem(clientContext,itemId);
                    return View(school);
                }
            }
                    return View();
        }

        public ActionResult NewStudent(string SPHostUrl, int SchoolId)
        {
          ViewBag.TaxItems = SchoolHelper.getTaxItems()

            return View();
        }
    }
}
