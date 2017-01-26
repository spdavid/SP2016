using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Security;
using MyFirstCSOMApp.CSOM;

namespace MyFirstCSOMApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //  using (ClientContext ctx = LogInAsUser())
              using (ClientContext ctx = LogInAsApp())
            {
                //Fields.CreateField(ctx);
                //ContentTypes.MyFirstContentType(ctx);
                //Basics.WebOperations(ctx);
                //Basics.GetAllContentTypes(ctx);
                //ClassAssignments.CreateList(ctx);
                //BooksAssignment.CreateContent(ctx);
                //CVAssignment.SetUp(ctx);
                //   UpdatingListItems.UpdateFirstCV(ctx);
                ComplexFields.SettingAndGettingFieldValues(ctx);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }

        }

        static ClientContext LogInAsUser()
        {
            string userName = "david@zalodev.com"; // user@company.onmicrosoft.com
            string password = GetPassword();

            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            ClientContext ctx = new ClientContext("https://zalodev.sharepoint.com/sites/OD1");
            ctx.Credentials = new SharePointOnlineCredentials(userName, securePassword);

            return ctx;
        }
        static ClientContext LogInAsApp()
        {
            return Helpers.ContextHelper.GetAppOnlyContext("https://zalodev.sharepoint.com/sites/OD1");

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


        static void RunOperation(ClientContext ctx, string Description, string Expression, long ellapsedTime = -1)
        {

            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine(Expression);

            if (ellapsedTime == -1)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                ctx.ExecuteQuery();

                watch.Stop();
                ellapsedTime = watch.ElapsedMilliseconds;
            }
            Console.Write("Total Time to execute:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ellapsedTime);
            Console.ResetColor();




        }


    }
}
