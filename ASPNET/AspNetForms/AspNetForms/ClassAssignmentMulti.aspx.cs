using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetForms
{
    public partial class ClassAssignmentMulti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lbLeft.Items.Add(new ListItem("Item 1"));
                lbLeft.Items.Add(new ListItem("Item 2"));
                lbLeft.Items.Add(new ListItem("Item 3"));
                lbLeft.Items.Add(new ListItem("Item 4"));
            }
        }

        protected void btnMoveToRight_Click(object sender, EventArgs e)
        {
            for (int i = lbLeft.Items.Count -1 ; i >= 0 ; i--)
            {
                ListItem item = lbLeft.Items[i];
         
                if (item.Selected)
                {
                    lbRighjt.Items.Add(item);
                    lbLeft.Items.Remove(item);
                }
            }
              
            
        }

        protected void btnMoveToLeft_Click(object sender, EventArgs e)
        {
            for (int i = lbRighjt.Items.Count - 1; i >= 0; i--)
            {
                ListItem item = lbRighjt.Items[i];
                if (item.Selected)
                {
                    lbLeft.Items.Add(item);
                    lbRighjt.Items.Remove(item);
                }
            }
        }
    }
}