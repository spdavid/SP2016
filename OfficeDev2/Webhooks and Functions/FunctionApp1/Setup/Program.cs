using Common.Helpers;
using Microsoft.SharePoint.Client;
using Newtonsoft.Json;
using OfficeDevPnP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClientContext ctx = Common.Helpers.ContextHelper.GetSPContext("https://folkuniversitetetsp2016.sharepoint.com/sites/David/").Result;

            //ctx.Load(ctx.Web);
            //ctx.ExecuteQuery();

            //Console.WriteLine(ctx.Web.Title);


            //string webhookurl = "https://davidfa.azurewebsites.net/api/WebHookEndPoint?req=cw5TPHNRsc6iZe5Q0V3TzMXN4XgMxb6F/HP4XEcpPxhQI5AzPAZcwg==";


            //WebhookSubscription subscription = ctx.Web.GetListByTitle("CustomList").AddWebhookSubscription(webhookurl, DateTime.Now.AddMonths(5));



            var status = GroupHelper.CreateGroup("csharp","csharpdesc", "csharp").Result;
            var groups = GroupHelper.GetGroups().Result;

            // you may need to store the subscription id in the future in order to renew it when needed
            // Console.WriteLine("subscription = " + subscription.Id.ToString());
            Console.WriteLine("done");
            Console.ReadLine();

        }

        private static async Task<string> GetGroups()
        {
            string accessToken = ContextHelper.GetGraphAccessToken();

            string requestUrl = "https://graph.microsoft.com/v1.0/groups";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //request.Content = new StringContent(JsonConvert.SerializeObject(subscription),
            //    Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
                else
                {
                    // Something went wrong...
                    throw new Exception(await response.Content.ReadAsStringAsync());
                  
                }
            }
        }
    }
}
