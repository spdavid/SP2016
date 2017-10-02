using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System;

namespace GraphFunctions
{
    public static class ShowEmail
    {
        [FunctionName("ShowEmail")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            string accessToken = Helpers.TokenHelper.GetGraphAccessToken();
            string emailUrl = "https://graph.microsoft.com/v1.0/users/David@folkuniversitetetsp2016.onmicrosoft.com/messages";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, emailUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                    };

                }
                else
                {
                    // Something went wrong...
                    throw new Exception(await response.Content.ReadAsStringAsync());

                }
            }



            //log.Info("C# HTTP trigger function processed a request.");

            //var myObj = new { name = "thomas", location = "Denver" };
            //var jsonToReturn = JsonConvert.SerializeObject(myObj);

            //return new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            //};
        }
    }
}
