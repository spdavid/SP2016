using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.AddInWeb.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string FavColor { get; set; }
        public string FavColorid { get; set; }
        public int SchoolId { get; set; }

    }
}