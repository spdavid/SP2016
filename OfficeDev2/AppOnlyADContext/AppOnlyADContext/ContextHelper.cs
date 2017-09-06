using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppOnlyADContext
{
    public class ContextHelper
    {

        public static string EncryptSecret { get; set; }

        //the method that will be provided to the KeyVaultClient
        public static async Task<string> GetToken(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(ConfigurationManager.AppSettings["ClientId"],
                        ConfigurationManager.AppSettings["ClientSecret"]);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");

            return result.AccessToken;
        }


        public static async Task<ClientContext> GetSPContext(string siteUrl)
        {
            // I put my GetToken method in a Utils class. Change for wherever you placed your method.
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(ContextHelper.GetToken));

            var sec = await kv.GetSecretAsync(ConfigurationManager.AppSettings["SecretUri"]);



            //I put a variable in a Utils class to hold the secret for general  application use.
            ContextHelper.EncryptSecret = sec.Value;


            var exportedCertCollection = new X509Certificate2Collection();
            exportedCertCollection.Import(Convert.FromBase64String(ContextHelper.EncryptSecret));
            var cert2 = exportedCertCollection.Cast<X509Certificate2>().Single(s => s.HasPrivateKey);


            AuthenticationManager authmanager = new AuthenticationManager();

            var ctx = authmanager.GetAzureADAppOnlyAuthenticatedContext(siteUrl, ConfigurationManager.AppSettings["ClientId"], ConfigurationManager.AppSettings["tenant"], cert2);
            return ctx;
        }
    }
}
