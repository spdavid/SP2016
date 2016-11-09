using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContollersAndViews.Controllers
{
    public class PostingFunController : Controller
    {
        // GET: PostingFun
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CatchThePost(string CardType, string Number, string Name, FormCollection collection)
        {
            return View();
        }
        
    }
}