using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeDevPnP.Core;
using System.Configuration;
using Microsoft.SharePoint.Client;

namespace PutItAllTogetherWebJob.Helpers
{
   public class InstallHelper
    {

        public static void Install(string WebUrl)
        {
            AddItemToLog(WebUrl, "App Installed event fired off " + DateTime.Now.ToString());
        }


        public static void UnInstall(string WebUrl)
        {
            AddItemToLog(WebUrl, "App uninstalled event fired off " + DateTime.Now.ToString());

        }

        private static void AddItemToLog(string webUrl, string message)
        {
            AuthenticationManager authManager = new AuthenticationManager();
            // reads from the App.Config AppSettings Section
            string AppId = ConfigurationManager.AppSettings["ClientId"];
            string AppSecret = ConfigurationManager.AppSettings["ClientSecret"];

            using (ClientContext ctx = authManager.GetAppOnlyAuthenticatedContext(webUrl, AppId, AppSecret))
            {
                List InstallLog = null;
                if (ctx.Web.ListExists("installLog"))
                {
                    InstallLog = ctx.Web.GetListByTitle("installLog");
                }
                else
                {
                    InstallLog = ctx.Web.CreateList(ListTemplateType.GenericList, "installLog", false);
                }

                string itemValue = message;

                ListItem item = InstallLog.AddItem(new ListItemCreationInformation());

                item["Title"] = itemValue;
                item.Update();
                ctx.ExecuteQuery();

            }
        }
    }
}
