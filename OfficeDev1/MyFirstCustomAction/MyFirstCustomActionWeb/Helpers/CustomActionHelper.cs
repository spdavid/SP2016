using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstCustomActionWeb.Helpers
{
    public class CustomActionHelper
    {

        private static void DelectCustomAction(ClientContext ctx, string name)
        {

            var customActions = ctx.Web.UserCustomActions;
            ctx.Load(customActions);
            ctx.ExecuteQuery();

            //todo.. loop backwards
            foreach (UserCustomAction ca in customActions)
            {
                if (ca.Name == "clickmeAction")
                {
                    ctx.Web.DeleteCustomAction(ca.Id);
                }
            }
        }

        private static void DelectCustomActionFromList(ClientContext ctx, string name, List list)
        {

            var customActions = list.UserCustomActions;
            ctx.Load(customActions);
            ctx.ExecuteQuery();

            //todo.. loop backwards
            foreach (UserCustomAction ca in customActions)
            {
                if (ca.Name == "clickmeAction")
                {
                    ctx.Web.DeleteCustomAction(ca.Id);
                }
            }
        }


        public static void AddCustomActionToGearMenu(ClientContext ctx)
        {

            CustomActionEntity caSiteActions = new CustomActionEntity();
            // see https://msdn.microsoft.com/en-us/library/office/bb802730.aspx for locations and groups
            caSiteActions.Location = "Microsoft.SharePoint.StandardMenu";
            caSiteActions.Group = "SiteActions";
            caSiteActions.Title = "Press me";
            caSiteActions.Url = "javascript:alert('yo')";
            // caSiteActions.ScriptBlock = "<script>alert('yo')</script>";
            caSiteActions.Sequence = 50;
            caSiteActions.Name = "clickmeAction";
            BasePermissions bp = new BasePermissions();
            bp.Set(PermissionKind.ManageWeb); // user can admin site
            caSiteActions.Rights = bp;

            ctx.Web.AddCustomAction(caSiteActions);
        }


        public static void AddCustomActionToListItem(ClientContext ctx)
        {
            if (!ctx.Web.ListExists("FakeList"))
            {
                ctx.Web.CreateList(ListTemplateType.GenericList, "FakeList", false);
            }

            List list = ctx.Web.GetListByTitle("FakeList");

            DelectCustomActionFromList(ctx, "FakeCustomAction", list);

            ctx.Load(ctx.Web, w => w.Url);
            ctx.ExecuteQuery();

           UserCustomAction userAction =  list.UserCustomActions.Add();
            userAction.Name = "FakeCustomAction";
            userAction.Location = "EditControlBlock";
            userAction.Title = "Fake Custom Action";
            userAction.Url = "https://localhost:44363/home/about?SPHostUrl=" + ctx.Web.Url + "&listId={ListId}&itemid={ItemId}";
            userAction.Update();
            ctx.ExecuteQuery();



        }




    }
}