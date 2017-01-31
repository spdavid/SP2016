using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSOMApp.CSOM
{
    public class TaxonomyFun
    {
        public static void CreateIssueCategoryTermSet(ClientContext ctx)
        {
            //TaxonomySession taxSession = TaxonomySession.GetTaxonomySession(ctx);
            //TermStore store = taxSession.TermStores[0];
            TermStore store = ctx.Site.GetDefaultSiteCollectionTermStore();

            TermGroup group = store.GetTermGroupByName("OD1Test");
            if (group == null)
            {
                group = store.CreateTermGroup("OD1Test", "{13E6924A-196D-4313-A1B4-3A21AF3958CF}".ToGuid(), "description");
            }
            TermSet termSet = group.EnsureTermSet("Issue Category", "{3D4C7DE0-3867-44C3-871A-C36DEC4E1970}".ToGuid(), 1033);


            Term term = store.GetTerm("{1BB08D14-4464-410C-A27C-BA2EB8EFE9DE}".ToGuid());
            ctx.Load(term);
            ctx.ExecuteQuery();
            
            if (term == null)
            {
                termSet.CreateTerm("Just Right", 1033, "{1BB08D14-4464-410C-A27C-BA2EB8EFE9DE}".ToGuid());
                termSet.CreateTerm("Low Priority", 1033, "{E96EF7E0-7F9B-4F66-BA1A-C2DBCC73DD78}".ToGuid());
                termSet.CreateTerm("Urgent", 1033, "{13E22744-483D-49D2-B92D-6BD2E0C10D9C}".ToGuid());

                ctx.ExecuteQuery();
            }

            
        }


    }
}
