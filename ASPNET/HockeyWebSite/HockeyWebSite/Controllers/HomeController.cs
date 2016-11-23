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
        public ActionResult TradePlayer(int? playerid)
        {
            HockeyEntities db = new HockeyEntities();
            Player player = db.Players.Where(p => p.Id == playerid).FirstOrDefault();
            List<Team> teams = db.Teams.Where(t => t.Id != player.TeamId).ToList();
            ViewBag.availableTeams = teams;

            return View(player);
        }

        [HttpPost]
        public ActionResult TradePlayer(int? newTeamId, int? playerid, int? TeamId)
        {
            Helpers.HockeyHelper.TradePlayer(playerid.Value, newTeamId.Value);
            return RedirectToAction("TeamPlayers", new { TeamId = TeamId, fakeItemInQuey = "lalalal" });
        }
    }
}