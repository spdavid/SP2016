using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFunctions.Helpers
{
    public class TokenHelper
    {

        public static string GetGraphAccessToken()
        {


            string clientId = ConfigurationManager.AppSettings["ClientId"];
            string clientSecret = ConfigurationManager.AppSettings["clientSecret"];


            AuthenticationContext authContext = new AuthenticationContext("https://login.windows.net/folkuniversitetetsp2016.onmicrosoft.com/oauth2/token");

            ClientCredential creds = new ClientCredential(clientId, clientSecret);

            AuthenticationResult authResult = authContext.AcquireTokenAsync("https://graph.microsoft.com/", creds).Result;

            return authResult.AccessToken;

        }
    }
}
