using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using RemoteEventRecieversCalculator.Comon;
using RemoteEventRecieversCalculator.Comon.Models;
using Newtonsoft.Json;
using RemoteEventRecieversCalculator.Comon.Helpers;

namespace RemoteEventRecieversCalculator.WebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void InstallApp([QueueTrigger(Constants.INSTALL_QUEUE_NAME)] string message, TextWriter log)
        {
            Console.WriteLine(message);
            InstallInfo info = JsonConvert.DeserializeObject<InstallInfo>(message);

            CalculatorHelper.SetUpCalculator(info);


            

        }

        public static void UnInstallApp([QueueTrigger(Constants.UNINSTALL_QUEUE_NAME)] string message, TextWriter log)
        {
            Console.WriteLine(message);
        }


        public static void CalculationAdded([QueueTrigger(Constants.ITEMADDED_QUEUE_NAME)] string message, TextWriter log)
        {
            Console.WriteLine(message);
            ItemEventInfo info = JsonConvert.DeserializeObject<ItemEventInfo>(message);

            CalculatorHelper.DoCalculation(info);

        }
    }
}
