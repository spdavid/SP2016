using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSOMApp.CSOM
{
    public class ContentTypes
    {
        public static void MyFirstContentType(ClientContext ctx)
        {

           Web root = ctx.Site.RootWeb;

            string outofboxAnnouncementCtId = "0x0104";
            string seperator = "00";
            string newGuid = "251AC5249AA044CB84583885D2750C72"; // example {DCDE4E19-7860-4BDA-968D-0D20C78FB160} with chars removed = DCDE4E1978604BDA968D0D20C78FB160

            string newCtid = outofboxAnnouncementCtId + seperator + newGuid;


            if (!root.ContentTypeExistsById(newCtid))
            {
                ContentTypeCreationInformation ctInfo = new ContentTypeCreationInformation();
                ctInfo.Name = "myFirstContentType";
                ctInfo.Group = "Custom Content Type";
                ctInfo.Description = "some stuff you want to say";
                ctInfo.Id = newCtid;
                root.ContentTypes.Add(ctInfo);
                ctx.ExecuteQuery();
            }


            ContentType myNewContentType = root.GetContentTypeById(newCtid);

            myNewContentType.AddFieldById(new Guid("{388F3ECA-394F-4257-802C-92A4427D0EF0}"), true, false);
            myNewContentType.AddFieldById(new Guid("{D443E51B-1609-4CE6-96BD-9FCEA3FDE329}"), false, false);


            //root.CreateContentType("AnotherCT", "0x010067DAF351B3314A4DB1391A903CBC82F8", "Custom Content Type");

            string pathToXML = AppDomain.CurrentDomain.BaseDirectory + "fields.xml";
            root.CreateContentTypeFromXMLFile(pathToXML);

        }



    }
}
