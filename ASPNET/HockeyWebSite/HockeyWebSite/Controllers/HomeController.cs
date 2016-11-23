using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HockeyWebSite.Models;

namespace HockeyWebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            HockeyEntities db = new HockeyEntities();

            return View(db.Teams.ToList());


        }

        public ActionResult TeamPlayers(int? TeamId)
        {
            if (TeamId == null)
            {
                return HttpNotFound();
            }
          //int TeamId =  int.Parse(Request.QueryString["TeamId"])
            HockeyEntities db = new HockeyEntities();
            Team team = db.Teams.Where(t => t.Id == TeamId.Value).FirstOrDefault();

            return View(team);


        }
    }
}