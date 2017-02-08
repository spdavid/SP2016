using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Queue; // Namespace for Queue storage types

namespace StorageQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            Helpers.MessageQueueHelper.AddMessageToDavidQueue("Hello again");

        }



    }
}
