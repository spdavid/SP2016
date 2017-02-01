using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFirstSPAddinWeb.Models;

namespace MyFirstSPAddinWeb.Helpers
{
    public class TaskHelper
    {
        public static void CreateTaskListIfNotExists(ClientContext ctx)
        {
            string taskListName = "AddinTasks";

            if (!ctx.Web.ListExists(taskListName))
            {
                ctx.Web.CreateList(ListTemplateType.Tasks, taskListName, false);
            }


        }

       public static List<SPTask> GetTasksFromSharePoint(ClientContext ctx)
        {
            string taskListName = "AddinTasks";
            List list = ctx.Web.Lists.GetByTitle("AddinTasks");

            //TODO: Make query use viewfields so its better
            ListItemCollection items = list.GetItems(CamlQuery.CreateAllItemsQuery());
            ctx.Load(items);
            ctx.ExecuteQuery();

            List<SPTask> tasks = new List<SPTask>();

            foreach (ListItem item in items)
            {
                SPTask task = new SPTask();
                task.Title = item["Title"].ToString();
                if (item["DueDate"] != null)
                {
                    task.TaskDueDate = DateTime.Parse(item["DueDate"].ToString());
                }
                if (item["AssignedTo"] != null)
                {
                    FieldUserValue value = item["AssignedTo"] as FieldUserValue;
                    task.AssigedTo = value.LookupValue;
                }

                tasks.Add(task);
            }

            return tasks;


        }

        public static void Addtask(ClientContext ctx, SPTask task)
        {
            string taskListName = "AddinTasks";
            List list = ctx.Web.Lists.GetByTitle(taskListName);

            User user = ctx.Web.EnsureUser(task.AssigedTo);
            ctx.Load(user, u => u.Id);
            ctx.ExecuteQuery();

            ListItem item = list.AddItem(new ListItemCreationInformation());
            item["Title"] = task.Title;
            item["DueDate"] = task.TaskDueDate;
            item["AssignedTo"] = user.Id;

            item.Update();
            ctx.ExecuteQuery();
        }
    }
}