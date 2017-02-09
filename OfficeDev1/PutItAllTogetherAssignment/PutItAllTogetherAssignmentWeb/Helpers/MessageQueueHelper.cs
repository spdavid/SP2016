using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PutItAllTogetherAssignmentWeb.Helpers
{
    public class MessageQueueHelper
    {

        public static void AddInstallMessageToDavidQueue(string message)
        {
            AddMessageToQueue("davidinstalled", message);
        }

        public static void AddUnInstallMessageToDavidQueue(string message)
        {
            AddMessageToQueue("daviduninstalled", message);
        }


        private static void AddMessageToQueue(string queueName, string message)
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

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
