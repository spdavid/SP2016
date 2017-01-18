using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSOMApp.CSOM
{
    public class ClassAssignments
    {
        ///. Change the title of the web to "Hello sir, Today is 2017-01-23"   -- Todays date
        public static void ChangeTitleofWeb(ClientContext ctx)
        {
            ctx.Web.Title = "Hello sir, Today is " + DateTime.Now.ToString("yyyy-MM-dd");
            ctx.Web.Update();
            ctx.ExecuteQuery();
        }

        //Get all lists that are not hidden and display them on the page.
        public static void GetAllNonHiddenLists(ClientContext ctx)
        {
            ListCollection lists = ctx.Web.Lists;
            ctx.Load(lists, lst => lst.Include(l => l.Title), lst => lst.Include(l => l.Hidden));
            ctx.ExecuteQuery();

            foreach (List list in lists)
            {
                
                if (!list.Hidden)
                {
                    Console.WriteLine(list.Title);
                }
            }
        }

        //Challenge - Display all the Columns from a content type of your choice.
        public static void GetColumnsFromContentType(ClientContext ctx, string ContentTypeName = "Image")
        {
            ContentType ct = ctx.Web.GetContentTypeByName(ContentTypeName);

            ctx.Load(ct.Fields, fields => fields.Include(fild => fild.Title));
            ctx.ExecuteQuery();

            foreach (Field f in ct.Fields)
            {
                Console.WriteLine(f.Title);
            }

        }

        public static void ShowAllItemTitlesInAList(ClientContext ctx, string ListName = "Documents")
        {
            List list = ctx.Web.GetListByTitle(ListName);

            ListItemCollection items = list.GetItems(CamlQuery.CreateAllItemsQuery());

            ctx.Load(items, its => its.Include(i => i["Title"]));
            ctx.ExecuteQuery();

            foreach (ListItem item in items)
            {
                string titleValue = item["Title"].ToString();
                Console.WriteLine(titleValue);
            }








        }


        public static void CreateSubSite(ClientContext ctx, string title, string Url)
        {

            // pnp Version
            //SiteEntity siteInfo = new SiteEntity();
            //siteInfo.Lcid = 1033;
            //siteInfo.Title = title;
            //siteInfo.Url = Url;

            //ctx.Web.CreateWeb(siteInfo, true, true);


            // sharepoint client object model version
            WebCreationInformation webInfo = new WebCreationInformation();
            webInfo.Language = 1033;
            webInfo.Title = title;
            webInfo.Url = Url;
            webInfo.UseSamePermissionsAsParentSite = true;
            webInfo.WebTemplate = "STS#0";
            ctx.Web.Webs.Add(webInfo);

            ctx.ExecuteQuery();


        }


        public static void ShowCurrentUser(ClientContext ctx)
        {
            User user = ctx.Web.CurrentUser;

            ctx.Load(user, u => u.Title);
            ctx.ExecuteQuery();


            Console.WriteLine(user.Title);


        }

        public static void SHowSubSites(ClientContext ctx)
        {
            ctx.Load(ctx.Web.Webs, webs => webs.Include(w => w.Title));
            ctx.ExecuteQuery();

            foreach (Web web in ctx.Web.Webs)
            {
                Console.WriteLine(web.Title);
            }
        }
        public static void ChangeMasterPage(ClientContext ctx)
        {
            ctx.Load(ctx.Web);
            ctx.Load(ctx.Site);
            ctx.ExecuteQuery();

            string newMasterUrl = "";
            
            if (ctx.Web.MasterUrl.Contains("oslo"))
            {
                newMasterUrl = ctx.Web.ServerRelativeUrl + "/_catalogs/masterpage/seattle.master";


            }
            else
            {
                newMasterUrl = ctx.Web.ServerRelativeUrl + "/_catalogs/masterpage/oslo.master";
                
            }

            ctx.Web.MasterUrl = newMasterUrl;
            ctx.Web.CustomMasterUrl = newMasterUrl;
            ctx.Web.Update();
            ctx.ExecuteQuery();

            
            Console.WriteLine();
            Console.WriteLine(ctx.Web.MasterUrl);
            Console.WriteLine(ctx.Web.CustomMasterUrl);
            
        }


    }
}
