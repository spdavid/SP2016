using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetForms
{
    public partial class Simple : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the first time the page loads IsPostback == False
            if (Page.IsPostBack == false)
            {
                lbSomeText.Text = "Hello from Label";
                lbSomeText.ForeColor = System.Drawing.Color.Red;
                SomeDiv.InnerText = "hello from div";

                ddlColors.Items.Add(new ListItem("Red"));
                ddlColors.Items.Add(new ListItem("Blue"));
                ddlColors.Items.Add(new ListItem("Green"));
                ddlColors.Items.Add(new ListItem("Pink"));
                ddlColors.Items.Add(new ListItem("HotPink"));

                //ddlColors.DataSource = Helpers.ColorHelper.GetColors();
                //ddlColors.DataTextField = "Name";
                //ddlColors.DataValueField = "Id";
                //ddlColors.DataBind();
            }


        }

        protected void btnButton_Click(object sender, EventArgs e)
        {
            lbSomeText.ForeColor = System.Drawing.Color.HotPink;
            lbResult.Text = "you just typed " + txtSomeText.Text;
        }
    }
}