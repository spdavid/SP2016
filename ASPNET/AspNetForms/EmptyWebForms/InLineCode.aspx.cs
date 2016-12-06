using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmptyWebForms
{
    public partial class InLineCode : System.Web.UI.Page
    {

        public string SomethingForThePage { get; set; }
        public List<string> listofstrings { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            SomethingForThePage = "Hello From Code Behind.";
            listofstrings = new List<string>();
            listofstrings.Add("test");
            listofstrings.Add("test2");
            listofstrings.Add("test3");
            listofstrings.Add("test4");
            listofstrings.Add("test5");
            listofstrings.Add("test6");

        }
    }
}