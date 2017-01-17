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
            string userName = "david@zalodev.com"; // user@company.onmicrosoft.com
            string password = GetPassword();

            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }


            using (ClientContext ctx = new ClientContext("https://zalodev.sharepoint.com"))
            {
                
                ctx.Credentials = new SharePointOnlineCredentials(userName, securePassword);

                Basics.WebOperations(ctx);
              
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }

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
