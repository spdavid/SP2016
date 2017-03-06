using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using SchoolManagementSystem.AddInWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}