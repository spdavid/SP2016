using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeDevPnP.Core;
using System.Security;
using Microsoft.SharePoint.Client.Taxonomy;
using SchoolManagementSystem.Helpers;
using System.Xml.Linq;

namespace SchoolManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ClientContext ctx = LogInAsUser())
            {
                //TaxonomyHelper.CreateTaxonomyFavColor(ctx);
                //SetupHelper.SetUp(ctx);

                ctx.Load(ctx.Web, w => w.Url);
                ctx.ExecuteQuery();

                UserCustomAction action = ctx.Web.GetListByTitle("Schools").UserCustomActions.Add(); ;
                string url = "https://localhost:44358/";
                action.Location = "EditControlBlock";
                action.Sequence = 1;
                action.Name = "SchoolAction";
                action.Title = "school card";
                action.Url = "https://localhost:44358/Home/School?itemId={ItemId}&SPHostUrl=" + ctx.Web.Url;
                action.Update();
                ctx.ExecuteQuery();

            }

        }

        static ClientContext LogInAsUser()
        {
            string userName = "david@zalosolutions.com"; // user@company.onmicrosoft.com
            string password = GetPassword();

            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            ClientContext ctx = new ClientContext("https://zalo.sharepoint.com/sites/OD1");
            ctx.Credentials = new SharePointOnlineCredentials(userName, securePassword);

            return ctx;
        }


        public static string GetPassword()
        {
            string pass = "";
            Console.Write("Enter your password: ");
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    Console.Write("\b");
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);


            return pass.TrimEnd("\r".ToCharArray());
        }




    }
}
