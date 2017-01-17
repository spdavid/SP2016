using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSOMApp.CSOM
{
   public class Basics
    {
        public static void WebOperations(ClientContext ctx)
        {
            // the web object based on the site we used when we connected to our client context
            Web web = ctx.Web;
            // making an order
            ctx.Load(web);

            // the waiter is getting or me
            ctx.ExecuteQuery();// takes about 3 seconds
                               //  RunOperation(ctx, "Getting web", "ctx.Load(web);");


            ctx.Load(web, w => w.Title, w => w.Url, w => w.SiteLogoUrl); // im only gettin the title object
            ctx.ExecuteQuery();// takes about 0.2 seconds

            //RunOperation(ctx, "Getting web", " ctx.Load(web, w => w.Title)");


            Console.WriteLine(web.Title);
            Console.WriteLine(web.Url);
            Console.WriteLine(web.SiteLogoUrl);
        }

        public static void UpdateWeb(ClientContext ctx)
        {


        }

    }
}
