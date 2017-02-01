using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstSPAddinWeb.Models
{
    public class SPTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TaskDueDate { get; set; }
        public string AssigedTo { get; set; }

    }
}