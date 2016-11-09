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
            var players = Helpers.HockeyPlayerHelper.GetFakeHockyPlayerList();

            return View(players);
        }

        // GET: HockeyPlayer/Details/5
        public ActionResult Details(int id)
        {
            var players = Helpers.HockeyPlayerHelper.GetFakeHockyPlayerList();

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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: HockeyPlayer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: HockeyPlayer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
