using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(string Name, string Email, string Message)
        {
            ViewBag.Name = Name;
            ViewBag.Email = Email;
            ViewBag.Message = Message;
            return View();
        }
    }
}