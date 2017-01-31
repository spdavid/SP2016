using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyFirstCSOMApp.CSOM
{
    public class BiggerAssignment
    {
        public static void SetUpContent(ClientContext ctx)
        {
           List issueList = ctx.Web.CreateList(ListTemplateType.GenericList, "Important Issues", false, true, "lists/importantissues", true);

            string pathToXML = AppDomain.CurrentDomain.BaseDirectory + "Important Issue Content.xml";
            XDocument doc = XDocument.Load(pathToXML);
            List<XElement> LookupElements = doc.Root.Elements("Field").Where(e => e.Attribute("Type").Value == "Lookup").ToList();
            foreach (XElement element in LookupElements)
            {
                string listUrl = element.Attribute("List").Value;
                List list = ctx.Web.GetListByUrl(listUrl);
                element.Attribute("List").Value = list.Id.ToString();
            }
            ctx.Web.CreateFieldsFromXMLString(doc.ToString());

            ctx.Web.CreateContentTypeFromXMLString(doc.ToString());

            issueList.AddContentTypeToListById("0x01002312F6C11D9A41F3A3532FE936842C34", true);

            issueList.RemoveContentTypeByName("Item");
        }


        public static void ImportDocument(ClientContext ctx)
        {
            string pathToXML = AppDomain.CurrentDomain.BaseDirectory + "ImportantIssueImport.xml";
            XDocument doc = XDocument.Load(pathToXML);

            List<XElement> items = doc.Root.Elements("item").ToList();

            List importantIssueList = ctx.Web.GetListByUrl("lists/importantissues");
            TaxonomyField issueCatTaxField = importantIssueList.GetFieldById<TaxonomyField>("{ED88551E-8F2D-4A2E-8DB0-3D9616C012B3}".ToGuid());


            foreach(XElement item in items)
            {
                string title = item.Element("Title").Value;
                string date = item.Element("Date").Value;
                string responsible = item.Element("Responsible").Value;
                string relatedIssue = item.Element("RelatedIssue").Value;
                string issueCategory = item.Element("IssueCategory").Value;
                string notes = item.Element("Notes").Value;

                User userResponsible = ctx.Web.EnsureUser(responsible);
                ctx.Load(userResponsible, u => u.Id);
                ctx.ExecuteQuery();

                int? relatedIssueId = getRelatedIssues(ctx, relatedIssue, importantIssueList);
                Term termIssueCat = GetTermByName(ctx, issueCategory);

                ListItem newItem = importantIssueList.AddItem(new ListItemCreationInformation());

                newItem["Title"] = title;
                newItem["OD1_IssueDate"] = DateTime.Parse(date);
                newItem["OD1_Responsible"] = userResponsible.Id;
                if (relatedIssueId != null)
                {
                   // newItem["OD1_RelatedIssue"] = relatedIssueId.Value;
                }

                issueCatTaxField.SetFieldValueByTerm(newItem, termIssueCat, 1033);

                newItem["OD1_Notes"] = notes;

                newItem.Update();
                ctx.ExecuteQuery();

                // pnp does an execute query. screw up if above newitem.update()
                //if (termIssueCat != null)
                //{
                //    newItem.SetTaxonomyFieldValue("{ED88551E-8F2D-4A2E-8DB0-3D9616C012B3}".ToGuid(), termIssueCat.Name, termIssueCat.Id);
                //}


            }
        }

        private static Term GetTermByName(ClientContext ctx, string issueCategory)
        {
            TermStore store = ctx.Site.GetDefaultSiteCollectionTermStore();
            TermSet termSet = store.GetTermSet("{3D4C7DE0-3867-44C3-871A-C36DEC4E1970}".ToGuid());

            TermCollection terms = termSet.Terms;
            ctx.Load(terms);
            ctx.ExecuteQuery();

          Term term =  terms.Where(t => t.Name == issueCategory).FirstOrDefault();
            return term;
        }

        private static int? getRelatedIssues(ClientContext ctx, string relatedIssue, List list)
        {

            if (string.IsNullOrEmpty(relatedIssue))
            {
                return null;
            }

            CamlQuery query = new CamlQuery();
            query.ViewXml = @"<View>
                                <Query>
                                    <Where>
                                        <Eq>
                                            <FieldRef Name='Title' />
                                                <Value Type='Text'>" + relatedIssue + @"</Value>
                                        </Eq>
                                    </Where>
                                </Query>
                        <ViewFields><FieldRef Name='Title' />
                        <FieldRef Name='Id' />
                        </ViewFields> 
                            </View>";

           ListItemCollection items =  list.GetItems(query);
            ctx.Load(items);
            ctx.ExecuteQuery();

            if (items.Count > 0)
            {
                return items[0].Id;
            }

            return null;


        }
    }
}
