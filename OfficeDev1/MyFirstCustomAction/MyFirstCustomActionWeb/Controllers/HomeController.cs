using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstCustomActionWeb.Controllers
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


                    Helpers.CustomActionHelper.AddAddBirthdayAction(clientContext);


               

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


        [SharePointContextFilter]
        public ActionResult HaveBirthday(string SPHostUrl, string ListId, int? ItemId)
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {
                if (ctx != null)
                {
                  List list =  ctx.Web.Lists.GetById(ListId.ToGuid());
                  ListItem item =  list.GetItemById(ItemId.Value);

                    ctx.Load(item, i => i["CUSTOM_AGE"]);
                    ctx.Load(list, l => l.DefaultViewUrl);
                    ctx.ExecuteQuery();

                    if (item["CUSTOM_AGE"] != null)
                    {
                        int currentAge = int.Parse(item["CUSTOM_AGE"].ToString());

                        currentAge++;

                        item["CUSTOM_AGE"] = currentAge;
                        item.SystemUpdate();
                        ctx.ExecuteQuery();

                    }

                    Uri url = new Uri(SPHostUrl);

                    string finalurl = url.Scheme + "://" + url.Authority;

                    Response.Redirect(finalurl + list.DefaultViewUrl);

                }
            }

                    return View();
        }

    }
}
