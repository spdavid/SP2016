using ContollersAndViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContollersAndViews.Controllers
{
    public class HockeyPlayerController : Controller
    {
        // GET: HockeyPlayer
        public ActionResult Index()
        {
            var players = Helpers.HockeyPlayerHelper.players;

            return View(players);
        }

        // GET: HockeyPlayer/Details/5
        public ActionResult Details(int id)
        {
            var players = Helpers.HockeyPlayerHelper.players;

            HockeyPlayer player = players
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return View(player);
        }

        // GET: HockeyPlayer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HockeyPlayer/Create
        [HttpPost]
        public ActionResult Create(HockeyPlayer player)
        {
            try
            {
                Helpers.HockeyPlayerHelper.AddHockeyPlayer(player);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HockeyPlayer/Edit/5
        public ActionResult Edit(int id)
        {
            var players = Helpers.HockeyPlayerHelper.players;

            HockeyPlayer player = players
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return View(player);
        }

        // POST: HockeyPlayer/Edit/5
        [HttpPost]
        public ActionResult Edit(HockeyPlayer player)
        {
            try
            {
                Helpers.HockeyPlayerHelper.EditHockeyPlayer(player);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HockeyPlayer/Delete/5
        public ActionResult Delete(int id)
        {

            var players = Helpers.HockeyPlayerHelper.players;

            HockeyPlayer player = players
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return View(player);
        }

        // POST: HockeyPlayer/Delete/5
        [HttpPost]
        public ActionResult Delete(HockeyPlayer player)
        {
            try
            {
                Helpers.HockeyPlayerHelper.DeleteHockeyPlayer(player.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
