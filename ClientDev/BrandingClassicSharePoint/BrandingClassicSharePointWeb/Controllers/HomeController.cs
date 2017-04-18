using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandingClassicSharePointWeb.Controllers
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


                   Uri appUrl = Request.Url;
                    string appRootUrl = "https://" + appUrl.Authority;

                    //clientContext.Web.AddJsLink("customjs", appRootUrl + "/scripts/main.js");
                    clientContext.Site.AddJsLink("customjs", appRootUrl + "/scripts/main.js");
                  

                    clientContext.Web.AlternateCssUrl = appRootUrl + "/Content/main.css";
                    clientContext.Web.Update();
                    clientContext.ExecuteQuery();

                }
            }

            return View();
        }

        public ActionResult About()
        {
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
