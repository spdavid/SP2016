using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace PutItAllTogetherWebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessInstalled([QueueTrigger("davidinstalled")] string message, TextWriter log)
        {
            Console.WriteLine(message);
            Helpers.InstallHelper.Install(message);
        }

        
        public static void ProcessUnInstalled([QueueTrigger("daviduninstalled")] string message, TextWriter log)
        {
            Console.WriteLine(message);
            Helpers.InstallHelper.UnInstall(message);


        }
    }
}
