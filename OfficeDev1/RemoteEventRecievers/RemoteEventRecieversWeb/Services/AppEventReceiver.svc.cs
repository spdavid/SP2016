using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.EventReceivers;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace RemoteEventRecieversWeb.Services
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

            using (ClientContext clientContext = TokenHelper.CreateAppEventClientContext(properties, useAppWeb: false))
            {
                if (clientContext != null)
                {
                    //OperationContext op = OperationContext.Current;
                    //Message msg = op.RequestContext.RequestMessage;
                    //Uri appUrl = msg.Headers.To;
                    //string rootAppUrl = appUrl.Scheme + "://" + appUrl.Authority;



                    clientContext.Load(clientContext.Web);
                    clientContext.ExecuteQuery();

                    // check if app installed 
                    if (properties.EventType == SPRemoteEventType.AppInstalled)
                    {
                        clientContext.Web.Title = "app installed at " + DateTime.Now.ToString();
                        clientContext.Web.Update();
                        clientContext.ExecuteQuery();
                    }

                    // check if app installed 
                    if (properties.EventType == SPRemoteEventType.AppUninstalling)
                    {
                        clientContext.Web.Title = "app un-installed at " + DateTime.Now.ToString();
                        clientContext.Web.Update();
                        clientContext.ExecuteQuery();
                    }



                }
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

    }
}
