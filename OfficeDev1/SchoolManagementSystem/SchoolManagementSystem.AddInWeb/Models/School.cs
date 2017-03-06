using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.AddInWeb.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string PicUrl { get; set; }
        public string PicDescription { get; set; }
        public int NrStudents { get; set; }

        public List<Student> students { get; set; }







    }
}