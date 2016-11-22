using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstEntityFramework.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name="Band Name")]
        public string Name { get; set; }

    }
}