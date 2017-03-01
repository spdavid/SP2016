using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.EventReceivers;
using RemoteEventRecieversCalculator.Comon.Helpers;
using RemoteEventRecieversCalculator.Comon.Models;

namespace RemoteEventRecieversCalculatorWeb.Services
{
    public class AppEventReceiver : IRemoteEventService
    {
        /// <summary>
        /// Handles app events that occur after the app is installed or upgraded, or when app is being uninstalled.
        /// </summary>
        /// <param name="properties">Holds information about the app event.</param>
        /// <returns>Holds information returned from the app event.</returns>
        public SPRemoteEventResult ProcessEvent(SPRemoteEventProperties properties)
        {
            SPRemoteEventResult result = new SPRemoteEventResult();

            switch (properties.EventType)
            {
                case SPRemoteEventType.ItemAdded:
                    ItemAdded(properties);
                    break;
                case SPRemoteEventType.AppInstalled:
                    Install(properties);
                    break;
                case SPRemoteEventType.AppUninstalling:
                    UnInstall(properties);
                    break;
                default:
                    break;
            }


            return result;
        }

        /// <summary>
        /// This method is a required placeholder, but is not used by app events.
        /// </summary>
        /// <param name="properties">Unused.</param>
        public void ProcessOneWayEvent(SPRemoteEventProperties properties)
        {
            throw new NotImplementedException();
        }


        static void Install(SPRemoteEventProperties properties)
        {
            InstallInfo info;
            info.HostUrl = properties.AppEventProperties.HostWebFullUrl.ToString();
            info.AppUrlServiceEndPoint = CalculatorHelper.GetWebServiceUrl();

            QueueHelper.AddToInstallQueue(info);


            //CreateAppEventClientContext used for install and uninstall events

            //using (ClientContext clientContext = TokenHelper.CreateAppEventClientContext(properties, useAppWeb: false))
            //{
            //    if (clientContext != null)
            //    {

            //        CalculatorHelper.SetUpCalculator(clientContext);
            //        CalculatorHelper.SetUpRemoteEventReciver(clientContext);
            //    }
            //}
        }

        static void UnInstall(SPRemoteEventProperties properties)
        {

            QueueHelper.AddToUnInstallQueue(properties.AppEventProperties.HostWebFullUrl.ToString());
            //CreateAppEventClientContext used for install and uninstall events

            //using (ClientContext clientContext = TokenHelper.CreateAppEventClientContext(properties, useAppWeb: false))
            //{
            //    if (clientContext != null)
            //    {
            //        // Helpers.CalculatorHelper.RemoveCalculator(clientContext);
            //        CalculatorHelper.RemoveRemoteEventReciver(clientContext);
            //    }
            //}
        }

        static void ItemAdded(SPRemoteEventProperties properties)
        {
            ItemEventInfo info = new ItemEventInfo();
            info.ItemId = properties.ItemEventProperties.ListItemId;
            info.WebUrl = properties.ItemEventProperties.WebUrl;

            QueueHelper.AddToItemAddedQueueu(info);


            // CreateRemoteEventReceiverClientContext used for everything else except appinstalled and uninstalled events
            //using (ClientContext clientContext = TokenHelper.CreateRemoteEventReceiverClientContext(properties))
            //{
            //    if (clientContext != null)
            //    {
            //        CalculatorHelper.DoCalculation(clientContext, properties.ItemEventProperties.ListItemId);
            //    }
            //}
        }


    }
}
