using ContollersAndViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContollersAndViews.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Page2()
        {
            ViewBag.foo = "bar";

            ViewBag.Players = Helpers.HockeyPlayerHelper.GetFakeHockyPlayerList();

            return View();
        }

        public ActionResult Page3()
        {
           List<HockeyPlayer> players = Helpers.HockeyPlayerHelper.GetFakeHockyPlayerList();

            
            return View(players);
        }
    }
}