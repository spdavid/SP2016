using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.EventReceivers;

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
            //CreateAppEventClientContext used for install and uninstall events

            using (ClientContext clientContext = TokenHelper.CreateAppEventClientContext(properties, useAppWeb: false))
            {
                if (clientContext != null)
                {
                    Helpers.CalculatorHelper.SetUpCalculator(clientContext);
                    Helpers.CalculatorHelper.SetUpRemoteEventReciver(clientContext);
                }
            }
        }

        static void UnInstall(SPRemoteEventProperties properties)
        {
            //CreateAppEventClientContext used for install and uninstall events

            using (ClientContext clientContext = TokenHelper.CreateAppEventClientContext(properties, useAppWeb: false))
            {
                if (clientContext != null)
                {
                    // Helpers.CalculatorHelper.RemoveCalculator(clientContext);
                    Helpers.CalculatorHelper.RemoveRemoteEventReciver(clientContext);
                }
            }
        }

        static void ItemAdded(SPRemoteEventProperties properties)
        {
            // CreateRemoteEventReceiverClientContext used for everything else except appinstalled and uninstalled events
            using (ClientContext clientContext = TokenHelper.CreateRemoteEventReceiverClientContext(properties))
            {
                if (clientContext != null)
                {
                    Helpers.CalculatorHelper.DoCalculation(clientContext, properties.ItemEventProperties.ListItemId);
                }
            }
        }


    }
}
