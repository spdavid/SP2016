using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApplication.Models
{
    public class InventoryPage
    {
        public List<Store> Stores { get; set; }
        public List<InventoryProduct> InventoryProducts { get; set; }
        public Store CurrentSelectedStore { get; set; }
        public InventoryPage()
        {
            CurrentSelectedStore = null;
            Stores = new List<Store>();
            InventoryProducts = new List<InventoryProduct>();
        }

        

    }
}