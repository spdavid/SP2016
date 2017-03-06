using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolManagementSystem.Helpers
{
   public  class SetupHelper
    {

        public static void SetUp(ClientContext ctx)
        {
            CreateLists(ctx);
            CreateFieldsandContentTypes(ctx);

        }

        public static void CreateLists(ClientContext ctx)
        {
            ctx.Web.CreateList(ListTemplateType.GenericList, "Schools", false);
            ctx.Web.CreateList(ListTemplateType.GenericList, "Students", false);


        }

        public static void CreateFieldsandContentTypes(ClientContext ctx)
        {
            Web root = ctx.Site.RootWeb;

            string pathToXML = AppDomain.CurrentDomain.BaseDirectory + @"SPContent\content.xml";

            XDocument doc = XDocument.Load(pathToXML);

            List<XElement> LookupElements = doc.Root.Elements("Field").Where(e => e.Attribute("Type").Value == "Lookup").ToList();
            foreach (XElement element in LookupElements)
            {
                string listUrl = element.Attribute("List").Value;
                List list = ctx.Web.GetListByUrl(listUrl);
                element.Attribute("List").Value = list.Id.ToString();
            }
            root.CreateFieldsFromXMLString(doc.ToString());
            root.CreateContentTypeFromXMLString(doc.ToString());

            List SchoolList = ctx.Web.GetListByTitle("Schools");
            List StudentsList = ctx.Web.GetListByTitle("Students");

            SchoolList.AddContentTypeToListByName("School", true);
            StudentsList.AddContentTypeToListByName("Student", true);



            SchoolList.RemoveContentTypeByName("Item");
            StudentsList.RemoveContentTypeByName("Item");

            View schoolView = SchoolList.DefaultView;
            View StudentView = StudentsList.DefaultView;

            ctx.Load(schoolView);
            ctx.Load(StudentView);
            ctx.ExecuteQuery();

            schoolView.ViewFields.Add("School_Address");
            schoolView.ViewFields.Add("School_Phone");
            schoolView.ViewFields.Add("School_StudAmt");
            schoolView.ViewFields.Add("School_Picture");
            schoolView.Update();
            ctx.ExecuteQuery();


            StudentView.ViewFields.Add("School_Address");
            StudentView.ViewFields.Add("School_FavColor");
            StudentView.ViewFields.Add("School_School");
            StudentView.Update();
            ctx.ExecuteQuery();





        }
    }
}
