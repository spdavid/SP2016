using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RemoteEventRecieversCalculatorWeb.Helpers
{
    public class CalculatorHelper
    {
    
        


        public static void SetUpCalculator(ClientContext ctx)
        {
            string ListName = "Calculator";
            List calculatorList = null;
            if (!ctx.Web.ListExists(ListName))
            {
                calculatorList = ctx.Web.CreateList(ListTemplateType.GenericList, ListName, false);
            }
            else
            {
                calculatorList = ctx.Web.GetListByTitle(ListName);
            }

            string pathToXML = AppDomain.CurrentDomain.BaseDirectory + @"\SPContent\Fields.xml";
            XDocument doc = XDocument.Load(pathToXML);

            ctx.Web.CreateFieldsFromXMLFile(pathToXML);
            ctx.Web.CreateContentTypeFromXMLFile(pathToXML);


        }

    }
}