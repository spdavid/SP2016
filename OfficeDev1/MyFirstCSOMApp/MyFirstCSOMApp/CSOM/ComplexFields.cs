using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.SharePoint.Client.Taxonomy;
using System.Windows.Forms;

namespace MyFirstCSOMApp.CSOM
{
   public class ComplexFields
    {

        public static void setupComplexListFields(ClientContext ctx)
        {
            Web root = ctx.Site.RootWeb;

            /////////////////////////////////////
            ////////// using xml ///////////////
            ////////////////////////////////////

            string pathToXML = AppDomain.CurrentDomain.BaseDirectory + "complexFields.xml";

            XDocument doc = XDocument.Load(pathToXML);

            List<XElement> LookupElements = doc.Root.Elements("Field").Where(e => e.Attribute("Type").Value == "Lookup").ToList();
            foreach (XElement element in LookupElements)
            {
                string listUrl = element.Attribute("List").Value;
                List list = ctx.Web.GetListByUrl(listUrl);
                element.Attribute("List").Value = list.Id.ToString();
            }
            root.CreateFieldsFromXMLString(doc.ToString());

            /////////////////////////////////////
            ////////// Using code ///////////////
            ////////////////////////////////////

            FieldCreationInformation fieldINfo = new FieldCreationInformation(FieldType.Lookup);

            fieldINfo.Id = "{CC5820F0-60C9-4B9E-9CE9-C739AED70357}".ToGuid();
            fieldINfo.InternalName = "OD1_TryGoodBook2";
            fieldINfo.DisplayName = "Good book 2";
            fieldINfo.Group = "Custom Columns";

            FieldLookup lookupField = root.CreateField<FieldLookup>(fieldINfo);
            lookupField.LookupList = root.GetListByUrl("lists/books").Id.ToString();
            lookupField.Update();

            ctx.ExecuteQuery();




        }


        public static void setupTaxonomyFields(ClientContext ctx)
        {

            Web root = ctx.Site.RootWeb;

            /////////////////////////////////////
            ////////// using xml ///////////////
            ////////////////////////////////////

            //string pathToXML = AppDomain.CurrentDomain.BaseDirectory + "complexFields.xml";
            //root.CreateFieldsFromXMLFile(pathToXML);

            /////////////////////////////////////
            ////////// Using code ///////////////
            ////////////////////////////////////


            TaxonomyFieldCreationInformation taxInfo = new TaxonomyFieldCreationInformation();
            taxInfo.Id = "{FB53E9CD-CC30-432C-95F1-E64CE1B4F2A1}".ToGuid();
            taxInfo.InternalName = "OD1_TaxCode";
            taxInfo.DisplayName = "Book Cat Code";
            taxInfo.TaxonomyItem = getTermSet(ctx);
            root.CreateTaxonomyField(taxInfo);

        }

        private static TaxonomyItem getTermSet(ClientContext ctx)
        {
           return ctx.Site.GetTermSetsByName("BookCategories").FirstOrDefault();
        }


        public static void SettingAndGettingFieldValues(ClientContext ctx)
        {
           List list =  ctx.Web.GetListByUrl("lists/books");
           ListItem item =  list.GetItemById(1);
            ctx.Load(item);
            ctx.ExecuteQuery();


            Console.WriteLine(item["OD1_TaxCode"].ToString());
            Console.WriteLine(item["OD1_Book"].ToString());


            ///////////////////
            //// setting /////
            //////////////////


            // lookup field

            ListItem lookUpItem = list.GetItemById(4);
            ctx.Load(lookUpItem);
            ctx.ExecuteQuery();

            item["OD1_Book"] = lookUpItem.Id;
            item.Update();
            ctx.ExecuteQuery();

            // tax field

            Term term = ctx.Site.GetTermByName("02806e1e-aeb7-4542-bf7e-0d1a3fdbc9d3".ToGuid(), "Romance");
            item.SetTaxonomyFieldValue("{FB53E9CD-CC30-432C-95F1-E64CE1B4F2A1}".ToGuid(), term.GetDefaultLabel(1033).Value, term.Id);
            
            ///////////////////
            //// getting /////
            //////////////////


            // lookup field

            FieldLookupValue lookupval = item["OD1_Book"] as FieldLookupValue;
            Console.WriteLine(lookupval.LookupValue);
            Console.WriteLine(lookupval.LookupId);


            TaxonomyFieldValue taxval = item["OD1_TaxCode"] as TaxonomyFieldValue;
            Console.WriteLine(taxval.Label);
            Console.WriteLine(taxval.TermGuid.ToString());



            // alternate way of setting taxonomy item. 
            //TaxonomyField taxField = list.Fields.GetById("{FB53E9CD-CC30-432C-95F1-E64CE1B4F2A1}".ToGuid()) as TaxonomyField;
            //taxField.SetFieldValueByTerm(item, term, 1033);





        }

       
        public static void GetFieldXml(ClientContext ctx, string InternalName = "xmultiline")
        {
          Field field =  ctx.Web.Fields.GetFieldByInternalName(InternalName);
            Console.WriteLine(field.SchemaXml);
         
        }


        public static void HiddenReadOnlyFieldTest(ClientContext ctx)
        {

            ctx.Web.CreateField(@"<Field ID='{C856197C-044E-473A-BA9A-260BE311CA63}' 
         StaticName='READONLYPNP' 
         Name='READONLYPNP' 
         Type='Text' 
         DisplayName='READONLYPNP' 
         Required='FALSE' 
         EnforceUniqueValues='FALSE' 
         Indexed='FALSE' 
         MaxLength='255' 
            ReadOnly='True'
         Group='PNPTEST' />");


            ctx.Web.CreateField(@"<Field ID='{12E64ABE-5A10-4C9A-A38C-A207214F36F0}' 
         StaticName='HiddenPNP' 
         Name='HiddenPNP' 
         Type='Text' 
         DisplayName='HiddenPNP' 
         Required='FALSE' 
         EnforceUniqueValues='FALSE' 
         Indexed='FALSE' 
         MaxLength='255' 
            Hidden='True'
         Group='PNPTEST' />");


            ctx.Web.CreateField(@"<Field ID='{8B68573E-6607-46A6-B818-F02F5379953D}' 
         StaticName='ShowInEditForm' 
         Name='ShowInEditForm' 
         Type='Text' 
         DisplayName='ShowInEditForm' 
         Required='FALSE' 
         EnforceUniqueValues='FALSE' 
         Indexed='FALSE' 
         MaxLength='255' 
         ShowInEditForm='FALSE'
         Group='PNPTEST' />");

        }
    }
}
