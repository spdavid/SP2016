using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSOMApp.CSOM
{
    public class BooksAssignment
    {

        public static void CreateContent(ClientContext ctx)
        {
            Web root = ctx.Site.RootWeb;
            string pathToXML = AppDomain.CurrentDomain.BaseDirectory + "BooksCtFields.xml";
            root.CreateFieldsFromXMLFile(pathToXML);
            root.CreateContentTypeFromXMLFile(pathToXML);

        }
    }
}
