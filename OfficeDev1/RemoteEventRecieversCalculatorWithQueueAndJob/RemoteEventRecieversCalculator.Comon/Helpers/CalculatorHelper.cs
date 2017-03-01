using Microsoft.SharePoint.Client;
using RemoteEventRecieversCalculator.Comon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RemoteEventRecieversCalculator.Comon.Helpers
{
    public class CalculatorHelper
    {
    
        public static void SetUpCalculator(InstallInfo info)
        {
            using (ClientContext ctx = ContextHelper.GetAppOnlyContext(info.HostUrl))
            {
                Console.WriteLine("Connected to sharepoint");
                string ListName = "Calculator";
                List calculatorList = null;

                Console.WriteLine("Creating LIst if not exists");

                if (!ctx.Web.ListExists(ListName))
                {
                    calculatorList = ctx.Web.CreateList(ListTemplateType.GenericList, ListName, false);
                }
                else
                {
                    calculatorList = ctx.Web.GetListByTitle(ListName);
                }

                Console.WriteLine("Setting up fields and content types");

                string pathToXML = AppDomain.CurrentDomain.BaseDirectory + @"\SPContent\Fields.xml";

                ctx.Site.RootWeb.CreateFieldsFromXMLFile(pathToXML);
                ctx.Site.RootWeb.CreateContentTypeFromXMLFile(pathToXML);

                if (!calculatorList.ContentTypeExistsByName("Calculator"))
                {
                    calculatorList.AddContentTypeToListById("0x01002B999C32793148858FE620188A8353AC", true, true);
                    calculatorList.RemoveContentTypeByName("Item");
                }

                SetUpRemoteEventReciver(ctx, info.AppUrlServiceEndPoint);
            }
        }

        public static void RemoveCalculator(ClientContext ctx)
        {
            ctx.Web.GetListByTitle("Calculator").DeleteObject();
            ctx.ExecuteQuery();

            ctx.Site.RootWeb.GetContentTypeByName("Calculator").DeleteObject();
            ctx.ExecuteQuery();

            ctx.Site.RootWeb.GetFieldById("{56862B15-43DB-4CB6-AD22-201571D6901E}".ToGuid()).DeleteObject();
            ctx.Site.RootWeb.GetFieldById("{27D65E4C-DE0D-478C-9118-4ED6413953E1}".ToGuid()).DeleteObject();
            ctx.Site.RootWeb.GetFieldById("{C0E840D8-6D38-4E1E-A6E1-1931D5E303D4}".ToGuid()).DeleteObject();
            ctx.Site.RootWeb.GetFieldById("{9DB9A3B6-75C9-44EE-BF24-F2CD7A897CB8}".ToGuid()).DeleteObject();
            ctx.ExecuteQuery();

        }
        
        public static void SetUpRemoteEventReciver(ClientContext ctx, string webserviceUrl)
        {
            Console.WriteLine("Setting up RER");

            string urlToWebService = webserviceUrl;
            List list = ctx.Web.GetListByTitle("Calculator");
            list.AddRemoteEventReceiver("Added355", urlToWebService, EventReceiverType.ItemAdded, EventReceiverSynchronization.Synchronous, true);

        }

        public static void RemoveRemoteEventReciver(ClientContext ctx)
        {
          
            List list = ctx.Web.GetListByTitle("Calculator");
            list.GetEventReceiverByName("Added355").DeleteObject();
            ctx.ExecuteQuery();

        }


        public static void DoCalculation(ItemEventInfo info)
        {
            using (ClientContext ctx = ContextHelper.GetAppOnlyContext(info.WebUrl))
            {
                List list = ctx.Web.Lists.GetByTitle("Calculator");

                ListItem item = list.GetItemById(info.ItemId);
                ctx.Load(item);
                ctx.ExecuteQuery();

                int Amount1 = int.Parse(item["OD1_Amount1"].ToString());
                int Amount2 = int.Parse(item["OD1_Amount2"].ToString());
                string operation = item["OD1_MathOperator"].ToString();

                int result = 0;
                if (operation == "Plus")
                {
                    result = Amount1 + Amount2;
                }
                else
                {
                    result = Amount1 - Amount2;
                }

                item["OD1_Result"] = result;
                item.SystemUpdate();
                ctx.ExecuteQuery();

            }
        }


        public static string GetWebServiceUrl()
        {
            System.ServiceModel.OperationContext op = System.ServiceModel.OperationContext.Current;
            System.ServiceModel.Channels.Message msg = op.RequestContext.RequestMessage;
            Uri url = msg.Headers.To;
            return url.ToString();
        }
    }
}