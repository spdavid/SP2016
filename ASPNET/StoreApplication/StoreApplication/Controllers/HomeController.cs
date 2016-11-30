using StoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? StoreId, int? CategoryId)
        {
          StoreFront front = Helpers.StoreFrontHelper.GetStoreFront(StoreId, CategoryId);

            return View(front);
        }
        public ActionResult AllProducts()
        {
              StoreEntities db = new StoreEntities();

            return View(db.Products.ToList());
        }

        }
}