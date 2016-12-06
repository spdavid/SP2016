using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetForms.UserControls
{
    public partial class HelloFolkis : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lb.Text = "Hello folkuniversitetet";
        }
    }
}