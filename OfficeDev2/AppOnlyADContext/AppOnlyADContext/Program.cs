using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOnlyADContext
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientContext ctx = ContextHelper.GetSPContext("https://folkuniversitetetsp2016.sharepoint.com/").Result;


            List list = ctx.Web.GetListByTitle("CustomList");

            string currentChangeTokenstr = list.GetPropertyBagValueString("customlistchangetoken", null);
            ChangeToken currentChangeToken = null;
            if (currentChangeTokenstr != null)
            {
                currentChangeToken = new ChangeToken();

                currentChangeToken.StringValue = currentChangeTokenstr;
            }

            ChangeQuery q = new ChangeQuery(false, false);
            q.Update = true;
            q.Add = true;
            q.Item = true;
            q.DeleteObject = true;
            q.ChangeTokenStart = currentChangeToken;
            q.ChangeTokenEnd = list.CurrentChangeToken;

            ChangeCollection changes = list.GetChanges(q);
            ctx.Load(changes);
            ctx.ExecuteQueryRetry();

            foreach (var change in changes)
            {
                if (change.ChangeType == ChangeType.Add)
                {
                    ChangeItem itemChange = change as ChangeItem;
                    Console.WriteLine("Item was added id = " + itemChange.ItemId);

                }
                if (change.ChangeType == ChangeType.DeleteObject)
                {
                    ChangeItem itemChange = change as ChangeItem;
                    Console.WriteLine("Item was deleted id = " + itemChange.ItemId);
                }
                if (change.ChangeType == ChangeType.Update)
                {
                    ChangeItem itemChange = change as ChangeItem;
                    Console.WriteLine("Item was updated id = " + itemChange.ItemId);
                }
            }
            list.SetPropertyBagValue("customlistchangetoken", q.ChangeTokenEnd.StringValue);





            Console.WriteLine("done");
            Console.ReadLine();

        }
    }
}
