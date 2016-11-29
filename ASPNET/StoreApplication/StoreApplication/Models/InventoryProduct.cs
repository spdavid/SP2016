using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApplication.Models
{
    public class InventoryProduct 
    {
       public Product Product { get; set; }
        public int AmountInStock { get; set; }

        public bool IsInStore { get; set; }

        public InventoryProduct(Product prod)
        {
            this.Product = prod;

        }

    }
}