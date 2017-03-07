using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnotherProviderHostedAddInAssignementWeb.Controllers
{
    public class HomeController : Controller
    {
        [SharePointContextFilter]
        public ActionResult Index(string SPHostUrl)
        {
            ViewBag.SPHostUrl = SPHostUrl;
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
        public ActionResult CreateList(string SPHostUrl, string ListName)
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {
                if (ctx != null)
                {
                    if (!ctx.Web.ListExists(ListName))
                    {
                        ctx.Web.CreateList(ListTemplateType.GenericList, ListName, false);
                    }
                }
            }
            return RedirectToAction("Index", new { SPHostUrl = SPHostUrl });

        }

        [SharePointContextFilter]
        public ActionResult ShowAllLists(string SPHostUrl)
        {
            Uri url = new Uri(SPHostUrl);

            ViewBag.SPHostUrl = "https://" + url.Authority;
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {
                if (ctx != null)
                {
                    ctx.Load(ctx.Web.Lists);
                    ctx.Load(ctx.Web.Lists, lsts=>lsts.Include(l=>l.DefaultViewUrl));

                    ctx.ExecuteQuery();
                    List<List> allLists = ctx.Web.Lists.Where(l => l.Hidden == false).ToList();
                    return View(allLists);

                }
            }

            return View();
        }
    }
}
