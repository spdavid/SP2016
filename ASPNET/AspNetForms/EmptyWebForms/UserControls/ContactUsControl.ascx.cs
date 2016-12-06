using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmptyWebForms.UserControls
{
    public partial class ContactUsControl : System.Web.UI.UserControl
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            nameDiv.InnerText = Title;
            addressDiv.InnerText = Address;
            phondDiv.InnerText = Phone;

        }
    }
}