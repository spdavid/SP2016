using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApplication.Models
{
    public class StoreFront
    {
        public List<ProductCategory> Categories { get; set; }
        public List<Product> Products { get; set; }

    }
}