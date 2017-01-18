
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSOMApp.CSOM
{
    public class Fields
    {
        public static void CreateField(ClientContext ctx)
        {
            Web web = ctx.Site.RootWeb;

            // sharepoint client object model way
            //string fieldXml = @"<Field Type='DateTime' 
            //                            DisplayName='Important Date2' 
            //                            Required='TRUE' 
            //                            EnforceUniqueValues='FALSE' 
            //                            Indexed='FALSE' 
            //                            Format='DateTime' 
            //                            Group='Custom Columns' 
            //                            ID='{C8DDEC78-F94E-4822-AB10-63FCDCA4AFEB}' 
            //                            StaticName='Important_Date2' 
            //                            Name='Important_Date2'  >
            //                        <Default>
            //                            [today]
            //                        </Default>
            //                    </Field>";

            //web.Fields.AddFieldAsXml(fieldXml, false, AddFieldOptions.DefaultValue);
            // ctx.ExecuteQuery();


            /// PNP way
            //FieldCreationInformation fieldinfo = new FieldCreationInformation(FieldType.DateTime);
            //fieldinfo.Group = "Custom Columns";
            //fieldinfo.Id = new Guid("{81682584-4E54-4D73-9DF9-E0FE3688833D}");
            //fieldinfo.InternalName = "Important_Date3";
            //fieldinfo.DisplayName = "important date 3";

            //FieldDateTime datetimeField = web.CreateField<FieldDateTime>(fieldinfo);
            //datetimeField.DefaultValue = "[today]";
            //datetimeField.DisplayFormat = DateTimeFieldFormatType.DateTime;
            //datetimeField.UpdateAndPushChanges(true);

            //ctx.ExecuteQuery();


            FieldCreationInformation fieldinfo = new FieldCreationInformation(FieldType.DateTime);
            fieldinfo.Group = "Custom Columns";
            fieldinfo.Id = new Guid("{81682584-4E54-4D73-9DF9-E0FE3688833D}");
            fieldinfo.InternalName = "Important_Date3";
            fieldinfo.DisplayName = "important date 3";

            Field field = web.CreateField(fieldinfo);
            FieldDateTime datetimeField = ctx.CastTo<FieldDateTime>(field);
            datetimeField.DefaultValue = "[today]";
            datetimeField.DisplayFormat = DateTimeFieldFormatType.DateTime;
            datetimeField.UpdateAndPushChanges(true);

            ctx.ExecuteQuery();

            // DeleteFields(ctx);

            string pathToXML = AppDomain.CurrentDomain.BaseDirectory + "fields.xml";
            ctx.Web.CreateFieldsFromXMLFile(pathToXML);

        }

        public static void DeleteFields(ClientContext ctx)
        {
            ctx.Web.RemoveFieldByInternalName("Important_Person");
            ctx.Web.RemoveFieldByInternalName("Important_Choice");


        }
    }
}
