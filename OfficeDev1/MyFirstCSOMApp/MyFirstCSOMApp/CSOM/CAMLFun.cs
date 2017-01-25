using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSOMApp.CSOM
{
    public class CAMLFun
    {
        public static ListItemCollection GetAllFantasyBooks(ClientContext ctx)
        {
           List booksList =  ctx.Web.GetListByUrl("Lists/books");

            // gets all items in the list
            // CamlQuery query = CamlQuery.CreateAllItemsQuery();
            CamlQuery query = new CamlQuery();
            query.ViewXml =
              @"<View>  
                    <Query> 
                       <Where>
                            <Eq>
                                <FieldRef Name='OD1_BookType' />
                                    <Value Type='MultiChoice'>Fantasy</Value>
                            </Eq>
                        </Where>
                        <OrderBy>   
                            <FieldRef Name='Created' Ascending='FALSE' />
                        </OrderBy> 
                    </Query> 
                     <ViewFields><FieldRef Name='Title' />
                        <FieldRef Name='Author' />
                        <FieldRef Name='OD1_BookType' />
                        <FieldRef Name='OD2_ReleaseDate' />
                        <FieldRef Name='OD1_Description' />
                        <FieldRef Name='OD1_Author' />
                    </ViewFields> 
                    <RowLimit>10</RowLimit> 
              </View>";


            ListItemCollection items =  booksList.GetItems(query);

            //ctx.Load(items, itms => itms.Include(i=>i["Title"], i=>i["Author"])); // ca 2 seconds
            ctx.Load(items); // ca 4 seconds
            ctx.ExecuteQueryRetry();

            foreach (ListItem item in items)
            {
                Console.WriteLine(item["Title"]);
            }

            return items;

        }

        public static void GetSpecificBookType(ClientContext ctx)
        {
            List booksList = ctx.Web.GetListByUrl("Lists/books");

            // gets all items in the list
            // CamlQuery query = CamlQuery.CreateAllItemsQuery();
            CamlQuery query = new CamlQuery();
            query.ViewXml =
              @"<View>
    <ViewFields>
        <FieldRef Name='Title' />
        <FieldRef Name='OD1_Author' />
    </ViewFields>
    <Query>
        <Where>
            <And>
                <Eq>
                    <FieldRef Name='OD1_Author' />
                    <Value Type='Text'>Jenny</Value>
                </Eq>
                <And>
                    <Gt>
                        <FieldRef Name='OD2_ReleaseDate' />
                        <Value Type='DateTime'>2017-01-01</Value>
                    </Gt>
                    <Or>
                        <Eq>
                            <FieldRef Name='OD1_BookType' />
                            <Value Type='Text'>Sci-fi</Value>
                        </Eq>
                        <Eq>
                            <FieldRef Name='OD1_BookType' />
                            <Value Type='Text'>Fantasy</Value>
                        </Eq>
                    </Or>
                </And>
            </And>
        </Where>
    </Query>
</View>";


            ListItemCollection items = booksList.GetItems(query);

            //ctx.Load(items, itms => itms.Include(i=>i["Title"], i=>i["Author"])); // ca 2 seconds
            ctx.Load(items); // ca 4 seconds
            ctx.ExecuteQueryRetry();

            foreach (ListItem item in items)
            {
                Console.WriteLine(item["Title"]);
            }

        }

    }
}
