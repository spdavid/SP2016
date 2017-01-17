using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ErrorHandling.Helpers
{
    public class LoggingHelper
    {

        public static void Log(string Message)
        {
            LogToFile(Message);
        }

        public static void LogException(string message, Exception ex)
        {

            LogToFile(message + " : " + ex.ToString());

        }


        private static void LogToFile(string fileMessage)
        {
          string pathOnServer =  HttpContext.Current.Server.MapPath("..");
            using (StreamWriter w = File.AppendText(pathOnServer + @"\App_Data\log.txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", fileMessage);
                w.WriteLine("-------------------------------");
            }

        }

       
    }
}