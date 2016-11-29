using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApplication.Models
{
    public class StoreFront
    {
        public StoreFront()
        {
            CurrentSelectedStore = null;
            CurrentSelectedCategory = null;
            Stores = new List<Store>();
            Categories = new List<ProductCategory>();
            Products = new List<Product>();
        }

        public ProductCategory CurrentSelectedCategory { get; set; }
        public Store CurrentSelectedStore { get; set; }
        public List<Store> Stores { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public List<Product> Products { get; set; }

    }
}