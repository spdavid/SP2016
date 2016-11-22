using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstEntityFramework.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}