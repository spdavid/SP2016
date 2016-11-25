using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreApplication.Models;

namespace StoreApplication.Controllers
{
    public class ProductStoresController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: ProductStores
        public ActionResult Index()
        {
            var productStores = db.ProductStores.Include(p => p.Product).Include(p => p.Store);
            return View(productStores.ToList());
        }

        // GET: ProductStores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStore productStore = db.ProductStores.Find(id);
            if (productStore == null)
            {
                return HttpNotFound();
            }
            return View(productStore);
        }

        // GET: ProductStores/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name");
            return View();
        }

        // POST: ProductStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,StoreId,AmountInStock")] ProductStore productStore)
        {
            if (ModelState.IsValid)
            {
                db.ProductStores.Add(productStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productStore.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", productStore.StoreId);
            return View(productStore);
        }

        // GET: ProductStores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStore productStore = db.ProductStores.Find(id);
            if (productStore == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productStore.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", productStore.StoreId);
            return View(productStore);
        }

        // POST: ProductStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,StoreId,AmountInStock")] ProductStore productStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productStore.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", productStore.StoreId);
            return View(productStore);
        }

        // GET: ProductStores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStore productStore = db.ProductStores.Find(id);
            if (productStore == null)
            {
                return HttpNotFound();
            }
            return View(productStore);
        }

        // POST: ProductStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductStore productStore = db.ProductStores.Find(id);
            db.ProductStores.Remove(productStore);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
