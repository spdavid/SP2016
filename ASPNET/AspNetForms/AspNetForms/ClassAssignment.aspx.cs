using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetForms
{
    public partial class ClassAssignment : System.Web.UI.Page
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
            ListItem selectedItem = lbLeft.SelectedItem;
            if (selectedItem != null)
            {
                lbRighjt.Items.Add(selectedItem);
                lbRighjt.SelectedIndex = -1;

                lbLeft.Items.Remove(selectedItem);
            }
        }

        protected void btnMoveToLeft_Click(object sender, EventArgs e)
        {
            ListItem selectedItem = lbRighjt.SelectedItem;
            if (selectedItem != null)
            {
                lbLeft.Items.Add(selectedItem);
                lbLeft.SelectedIndex = -1;

                lbRighjt.Items.Remove(selectedItem);
            }
        }
    }
}