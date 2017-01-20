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
            List booksList = null;
            if (!root.ListExists("Books"))
            {
                booksList = root.CreateList(ListTemplateType.GenericList, "Books", false, true, "lists/books", true);
            }
            else
            {
                booksList = root.GetListByTitle("Books");
            }

            // if you need to enable content types
            //List booksList = root.GetListByTitle("Books");
            //booksList.ContentTypesEnabled = true;
            //booksList.Update();
            //ctx.ExecuteQuery();

            if (!booksList.ContentTypeExistsByName("Book"))
            {
                booksList.AddContentTypeToListByName("Book", true);
                booksList.RemoveContentTypeByName("Item");

                View view = booksList.DefaultView;
                ctx.Load(view.ViewFields);
                ctx.ExecuteQuery();

                view.ViewFields.Add("OD1_BookType"); // internal name of field. 
                view.ViewFields.Add("OD1_Author");
                view.ViewFields.Add("OD2_ReleaseDate");
                view.ViewFields.Add("OD1_Description");

                view.Update();
                ctx.ExecuteQuery();

            }
            
        }
    }
}
