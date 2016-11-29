using StoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApplication.Helpers
{
    public class StoreFrontHelper
    {
        public static StoreFront GetStoreFront(int? StoreId, int? CategoryId)
        {
            StoreEntities db = new StoreEntities();

            StoreFront front = new StoreFront();

            front.Stores = db.Stores.ToList();
            front.Categories = db.ProductCategories.ToList();

            if (StoreId != null)
            {
                front.CurrentSelectedStore = db.Stores.Find(StoreId);

                List<int> availProductIds = db.ProductStores
                    .Where(ps => ps.StoreId == StoreId)
                    .Select(ps => ps.ProductId).ToList();

                if (CategoryId != null)
                {
                    front.CurrentSelectedCategory = db.ProductCategories.Find(CategoryId);

                    front.Products = db.Products
                       .Where(p => p.ProductCategoryId == CategoryId &&
                                   availProductIds.Contains(p.Id))
                       .ToList();
                }
                else
                {
                    //front.Products = db.Products
                    //    .Where(p => p.FeaturedProduct == true && 
                    //                availProductIds.Contains(p.Id))
                    //    .ToList();

                    front.Products = (from p in db.Products
                                      where p.FeaturedProduct == true && availProductIds.Contains(p.Id)
                                      select p).ToList();
                }
            }
            return front;
        }
    }
}