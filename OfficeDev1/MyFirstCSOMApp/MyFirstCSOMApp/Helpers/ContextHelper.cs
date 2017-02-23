using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeDevPnP.Core;
using Newtonsoft.Json;

namespace MyFirstCSOMApp.Helpers
{
    [Serializable]
    struct ContextInfo
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class ContextHelper
    {
        public static ClientContext GetAppOnlyContext(string siteUrl)
        {
           // ContextInfo info = new ContextInfo();
           //     info.ClientId = "clientid";
           // info.ClientSecret = "asdf";
           //string str = JsonConvert.SerializeObject(info);


            string pathToJson = AppDomain.CurrentDomain.BaseDirectory + "creds.json";

            string readText = System.IO.File.ReadAllText(pathToJson);

            ContextInfo info = JsonConvert.DeserializeObject<ContextInfo>(readText);

            AuthenticationManager authManager = new AuthenticationManager();
            return authManager.GetAppOnlyAuthenticatedContext(siteUrl, info.ClientId, info.ClientSecret);


            //Uri siteUri = new Uri(siteUrl);
            //// Connect to a site using an app-only token.
            //string realm = TokenHelper.GetRealmFromTargetUrl(siteUri);
            //var token = TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal, siteUri.Authority, realm).AccessToken;
            //var ctx = TokenHelper.GetClientContextWithAccessToken(siteUrl.ToString(), token);
            //return ctx;

        }
    }
}
