using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSOMApp.CSOM
{
    public class UpdatingListItems
    {
        public static void UpdateFantasyBook(ClientContext ctx)
        {
            // get items from last assignment
            ListItemCollection items = CAMLFun.GetAllFantasyBooks(ctx);

            foreach (ListItem item in items)
            {
                item["Title"] = item["Title"].ToString() + "custom ending";
                //Console.WriteLine(item["OD1_BookType"].ToString());

                // multichoice field
                List<string> choices = (item["OD1_BookType"] as string[]).ToList();
                choices.Add("foo");
                item["OD1_BookType"] = choices.ToArray();

                // datetime field
                DateTime releaseDate = (DateTime)item["OD2_ReleaseDate"];
                item["OD2_ReleaseDate"] = releaseDate.AddDays(2);


                item.Update();
                ctx.ExecuteQuery();

            }

        }

        public static void UpdateFirstCV(ClientContext ctx)
        {
            List list = ctx.Web.Lists.GetByTitle("CV's");

            ListItemCollection items = list.GetItems(CamlQuery.CreateAllItemsQuery(1));

            ctx.Load(items);
            ctx.ExecuteQueryRetry();

            ListItem item = items[0];

            // setting a picture or link field
            Console.WriteLine(item["CV_Picture"]);
            Console.WriteLine(item["CV_Picture"].ToString());

            FieldUrlValue pictureValue = item["CV_Picture"] as FieldUrlValue;
            Console.WriteLine(pictureValue.Description);
            Console.WriteLine(pictureValue.Url);

            pictureValue.Url = "https://s-media-cache-ak0.pinimg.com/originals/26/18/22/2618227f9e53768070739f89fb387fcf.gif";
            pictureValue.Description = "quack quack";
            item["CV_Picture"] = pictureValue;

            // setting the person field
            Console.WriteLine(item["CV_person"]);
            FieldUserValue userVal = item["CV_person"] as FieldUserValue;
            Console.WriteLine(userVal.Email);
            Console.WriteLine(userVal.LookupValue);
            Console.WriteLine(userVal.LookupId);

            User user = ctx.Web.EnsureUser("tu@zalodev.com");
            ctx.Load(user);
            ctx.ExecuteQueryRetry();
            item["CV_person"] = user.Id;
            item.Update();
            ctx.ExecuteQueryRetry();






        }
    }
}
