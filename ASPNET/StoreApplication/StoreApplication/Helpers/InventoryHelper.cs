using StoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApplication.Helpers
{
    public class InventoryHelper
    {
        public static ProductStore GetInventoryItem(int storeId, int productId)
        {
            StoreEntities db = new StoreEntities();
            ProductStore productStore = db.ProductStores.Where(ps => ps.ProductId == productId && ps.StoreId == storeId).FirstOrDefault();
            return productStore;
        }
        public static void DeleteInventoryItem(int storeId, int productId)
        {
            StoreEntities db = new StoreEntities();
            ProductStore productStore = db.ProductStores.Where(ps => ps.ProductId == productId && ps.StoreId == storeId).FirstOrDefault();
            db.ProductStores.Remove(productStore);
            db.SaveChanges();
        }

        public static InventoryPage GetInventoryPage(int? storeId)
        {
            InventoryPage invPage = new InventoryPage();

            StoreEntities db = new StoreEntities();

            invPage.Stores = db.Stores.ToList();


            if (storeId != null)
            {
                invPage.CurrentSelectedStore = db.Stores.Find(storeId);

                List<ProductStore> prodStores = db.ProductStores.Where(ps => ps.StoreId == storeId).ToList();
                foreach(Product prod in db.Products)
                {
                    InventoryProduct invProd = new InventoryProduct(prod);

                    ProductStore prodStore = prodStores.Where(ps => ps.ProductId == invProd.Product.Id).FirstOrDefault();

                    if (prodStore == null)
                    {
                        invProd.IsInStore = false;
                        invProd.AmountInStock = 0;
                    }
                    else
                    {
                        invProd.IsInStore = true;
                        invProd.AmountInStock = prodStore.AmountInStock;
                    }

                    invPage.InventoryProducts.Add(invProd);
                }

            }


            return invPage;

        }

        public static void UpdateInventoryProduct(int productId, bool isInStore, int amountInStock, int storeId)
        {
            StoreEntities db = new StoreEntities();

            ProductStore inv = db.ProductStores.Where(ps => ps.StoreId == storeId && ps.ProductId == productId).FirstOrDefault();

            if (isInStore)
            {
                // Add inventory to stock if it does not exist otherwise update it


                if(inv != null)
                {
                    // one already exists so update stock amount
                    inv.AmountInStock = amountInStock;
                    db.SaveChanges();
                }
                else
                {
                    // does not exist need to add new
                    ProductStore newInv = new ProductStore();
                    newInv.ProductId = productId;
                    newInv.StoreId = storeId;
                    newInv.AmountInStock = amountInStock;
                    db.ProductStores.Add(newInv);
                    db.SaveChanges();

                }

            }
            else
            {
                // remove product from store if it exists
                if (inv != null)
                {
                    db.ProductStores.Remove(inv);
                    db.SaveChanges();
                }
            }
        }

    }
}