using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnotherProviderHostedAddInAssignementWeb.Controllers
{
    public class ChangeTitleController : Controller
    {
        [SharePointContextFilter]
        public ActionResult Index(string Title, string SPHostUrl)
        {
            ViewBag.SPHostUrl = SPHostUrl;
            if (!string.IsNullOrEmpty(Title))
            {
                var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

                using (var ctx = spContext.CreateUserClientContextForSPHost())
                {
                    if (ctx != null)
                    {
                        //ctx.Web.Title = Title;
                        //ctx.Web.Update();
                        //ctx.ExecuteQuery();

                        WebCreationInformation info = new WebCreationInformation();
                        info.Url = Title;
                        //TODO Remove äöå from title and spaces from url
                        info.Title = Title;
                        info.Language = 1033;
                        info.WebTemplate = "STS#0";
                        info.Description = "yo";
                        ctx.Web.Webs.Add(info);
                        ctx.ExecuteQuery();
                    }
                }

              
            }
            return View();
        }

    
    }
}
