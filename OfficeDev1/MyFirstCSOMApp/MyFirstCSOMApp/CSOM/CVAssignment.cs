using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSOMApp.CSOM
{
    public class CVAssignment
    {
        public static void SetUp(ClientContext ctx)
        {
            Web root = ctx.Site.RootWeb;
            string pathToXML = AppDomain.CurrentDomain.BaseDirectory + "CVContentType.xml";
            root.CreateFieldsFromXMLFile(pathToXML);
            root.CreateContentTypeFromXMLFile(pathToXML);

            List CVs = null;

            if (root.ListExists("CV's"))
            {
                CVs = root.GetListByTitle("CV's");
            }
            else
            {
                CVs = root.CreateList(ListTemplateType.DocumentLibrary, "CV's", true, true, "CVS", true);
            }

            CVs.AddContentTypeToListByName("CV", true);
            CVs.RemoveContentTypeByName("Document");

            FieldText titleField = CVs.GetFieldById<FieldText>("{fa564e0f-0c70-4ab9-b863-0177e6ddd247}".ToGuid());
            titleField.Title = "CV Description";
            titleField.Update();
            ctx.ExecuteQuery();

            AddViewFields(ctx, CVs);



            string query = @"<OrderBy>
            <FieldRef Name='Modified' Ascending='FALSE' />
                </OrderBy>
                <Where>
                    <And>
                        <Eq>
                            <FieldRef Name='CV_bool' />
                            <Value Type='Boolean' >1</Value>
                        </Eq>
                        <Gt>
                            <FieldRef Name='Created' />
                            <Value Type='DateTime' >2017-01-01T00:00:00Z</Value>
                        </Gt>
                    </And>
                </Where>
                    ";

            CVs.CreateView("Active CV's 2", ViewType.Html, new string[] { "Title", "CV_Picture", "CV_Person" }, 10, false, query);

        }

        private static void AddViewFields(ClientContext ctx, List CVs)
        {
            ctx.Load(CVs.DefaultView);
            ctx.Load(CVs.DefaultView.ViewFields);

            ctx.ExecuteQueryRetry();
            AddViewFieldIfNotExists(CVs.DefaultView, "CV_Picture");
            AddViewFieldIfNotExists(CVs.DefaultView, "CV_Person");
            AddViewFieldIfNotExists(CVs.DefaultView, "CV_bool");
            CVs.DefaultView.Update();
            ctx.ExecuteQueryRetry();

        }

        private static void AddViewFieldIfNotExists(View view, string FieldName)
        {
            if (!view.ViewFields.Contains(FieldName))
            {
                view.ViewFields.Add(FieldName);
            }

        }

    }
}
