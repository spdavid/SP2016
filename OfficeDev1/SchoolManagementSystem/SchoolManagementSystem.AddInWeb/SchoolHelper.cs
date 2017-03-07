using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using SchoolManagementSystem.AddInWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.AddInWeb
{
    public class SchoolHelper
    {
        public static School GetSchoolFromItem(ClientContext ctx, int ItemId)
        {
          List list=  ctx.Web.GetListByTitle("Schools");
            ListItem item = list.GetItemById(ItemId);
            ctx.Load(item);
            ctx.ExecuteQuery();

            School school = new School();
            school.Title = item["Title"].ToString();
            school.NrStudents = int.Parse(item["School_StudAmt"].ToString());
            school.Address = "";
            if (item["School_Address"] != null)
            {
                school.Address = item["School_Address"].ToString();
            }
            school.PicDescription = "";
            school.PicUrl = "";
            if (item["School_Picture"] != null)
            {
                FieldUrlValue urlval = item["School_Picture"] as FieldUrlValue;
                school.PicDescription = urlval.Description;
                school.PicUrl = urlval.Url;
            }

            school.students = StudentsFromSchoolId(ctx, ItemId);

            return school;

        }

        public static List<Student> StudentsFromSchoolId(ClientContext ctx, int schoolId)
        {
            List list = ctx.Web.GetListByTitle("Students");
            CamlQuery query = new CamlQuery();
            query.ViewXml =
                  @"<View>  
                        <Query> 
                           <Where><Eq><FieldRef Name='School_School' LookupId='True' /><Value Type='Lookup'>" + schoolId.ToString() + @"</Value></Eq></Where> 
                        </Query> 
                  </View>";
            ListItemCollection items = list.GetItems(query);
            ctx.Load(items);
            ctx.ExecuteQuery();

            List<Student> students = new List<Student>();
            foreach (ListItem item in items)
            {
                Student student = new Student();
                student.Title = item["Title"].ToString();
                student.Address = "";
                if (item["School_Address"] != null)
                {
                    student.Address = item["School_Address"].ToString();
                }
                student.FavColor = "";
                if (item["School_FavColor"] != null)
                {
                    TaxonomyFieldValue color = item["School_FavColor"] as TaxonomyFieldValue;
                      student.FavColor = color.Label;
                }

                students.Add(student);
            }

            return students;
        }

        internal static void UpdateAmountOfStudents(ClientContext ctx, int schoolId)
        {
            List list = ctx.Web.GetListByTitle("Students");
            List schoolList = ctx.Web.GetListByTitle("Schools");
            ListItem school = schoolList.GetItemById(schoolId);

            CamlQuery query = new CamlQuery();
            query.ViewXml =
                  @"<View>  
                        <Query> 
                           <Where><Eq><FieldRef Name='School_School' LookupId='True' /><Value Type='Lookup'>" + schoolId.ToString() + @"</Value></Eq></Where> 
                        </Query> 
                  </View>";
            // TODO get only the title viewfield as i only want the count. 
            ListItemCollection items = list.GetItems(query);
            ctx.Load(items);
            ctx.Load(school);
            ctx.ExecuteQuery();

            int amountOfStudents = items.Count();
            school["School_StudAmt"] = amountOfStudents;
            school.SystemUpdate();
            ctx.ExecuteQuery();



        }

        internal static void SaveStudent(ClientContext ctx, Student student)
        {
          TermStore store =  ctx.Site.GetDefaultKeywordsTermStore();
           Term term =  store.GetTerm(student.FavColorid.ToGuid());
            ctx.Load(term);
            ctx.ExecuteQuery();

          List list =  ctx.Web.GetListByTitle("Students");
          TaxonomyField field =  list.GetFieldById<TaxonomyField>("{6D9CF114-04FB-4C91-BF6E-C45770B48A2A}".ToGuid());
          ListItem item =  list.AddItem(new ListItemCreationInformation());
            //item.SetTaxonomyFieldValue("{6D9CF114-04FB-4C91-BF6E-C45770B48A2A}".ToGuid(), term.Name, term.Id);
            item["Title"] = student.Title;
            item["School_Address"] = student.Address;
            item["School_School"] = student.SchoolId;
            field.SetFieldValueByTerm(item, term, 1033);
            item.Update();
            ctx.ExecuteQuery();



        }

        internal static List<SelectListItem> getTaxItems(ClientContext ctx)
        {
            List<SelectListItem> items = new List<SelectListItem>();

          TermStore store =  ctx.Site.GetDefaultKeywordsTermStore();
           TermSet tset = store.GetTermSet("{3D4C7DE0-3867-44C3-871A-C36DEC4E1970}".ToGuid());
            TermCollection terms = tset.Terms;
            ctx.Load(terms);
           ctx.Load(terms, tms => tms.Include(l=> l.Labels));

            ctx.ExecuteQuery();

            foreach (Term t in terms)
            {
                SelectListItem item = new SelectListItem();

                item.Value = t.Id.ToString();
                item.Text = t.Labels.Where(l => l.Language == 1033).FirstOrDefault().Value;
                items.Add(item);
            }


            return items;
         
        }
    }
}