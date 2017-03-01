using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteEventRecieversCalculator.Comon.Helpers
{
    public class ContextHelper
    {
        public static ClientContext GetAppOnlyContext(string siteUrl)
        {
            string clientId = ConfigurationManager.AppSettings["ClientId"];
            string clientSecret = ConfigurationManager.AppSettings["ClientSecret"];


            AuthenticationManager authManager = new AuthenticationManager();
            return authManager.GetAppOnlyAuthenticatedContext(siteUrl, clientId, clientSecret);
        }
    }
}
