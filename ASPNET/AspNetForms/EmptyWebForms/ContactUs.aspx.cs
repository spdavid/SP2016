using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmptyWebForms
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContactUsControl.Title = "Steve";
            ContactUsControl.Address = "Stockhom";
            ContactUsControl.Phone = "345345345";

        }
    }
}