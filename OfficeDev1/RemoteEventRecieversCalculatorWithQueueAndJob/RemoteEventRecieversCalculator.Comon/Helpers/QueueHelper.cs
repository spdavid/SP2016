using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteEventRecieversCalculator.Comon.Helpers
{
    public class QueueHelper
    {

        public static void AddToInstallQueue(Models.InstallInfo info)
        {
            string message = Newtonsoft.Json.JsonConvert.SerializeObject(info);

            AddMessageToQueue(Constants.INSTALL_QUEUE_NAME, message);
        }

        public static void AddToUnInstallQueue(string spHostUrl)
        {
            AddMessageToQueue(Constants.UNINSTALL_QUEUE_NAME, spHostUrl);
        }

        public static void AddToItemAddedQueueu(Models.ItemEventInfo info)
        {
            string message = Newtonsoft.Json.JsonConvert.SerializeObject(info);

            AddMessageToQueue(Constants.ITEMADDED_QUEUE_NAME, message);
        }


        private static void AddMessageToQueue(string queueName, string message)
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                System.Configuration.ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            CloudQueueMessage cloudMessage = new CloudQueueMessage(message);

            queue.AddMessage(cloudMessage);
        }
    }
}
