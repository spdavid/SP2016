using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HockeyWebSite;
using HockeyWebSite.Models;


namespace HockeyWebSite.Controllers
{
    public class GoalsAssistsController : Controller
    {
        private HockeyEntities db = new HockeyEntities();

        // GET: GoalsAssists
        public ActionResult Index()
        {
            var goalsAssists = db.GoalsAssists.Include(g => g.Game).Include(g => g.Player);
            return View(goalsAssists.ToList());
        }

        // GET: GoalsAssists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalsAssist goalsAssist = db.GoalsAssists.Find(id);
            if (goalsAssist == null)
            {
                return HttpNotFound();
            }
            return View(goalsAssist);
        }

        // GET: GoalsAssists/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "Name");
            return View();
        }

        // POST: GoalsAssists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameId,PlayerId,IsGoal")] GoalsAssist goalsAssist)
        {
            if (ModelState.IsValid)
            {
                db.GoalsAssists.Add(goalsAssist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", goalsAssist.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "Name", goalsAssist.PlayerId);
            return View(goalsAssist);
        }

        // GET: GoalsAssists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalsAssist goalsAssist = db.GoalsAssists.Find(id);
            if (goalsAssist == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", goalsAssist.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "Name", goalsAssist.PlayerId);
            return View(goalsAssist);
        }

        // POST: GoalsAssists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GameId,PlayerId,IsGoal")] GoalsAssist goalsAssist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goalsAssist).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", goalsAssist.GameId);
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "Name", goalsAssist.PlayerId);
            return View(goalsAssist);
        }

        // GET: GoalsAssists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoalsAssist goalsAssist = db.GoalsAssists.Find(id);
            if (goalsAssist == null)
            {
                return HttpNotFound();
            }
            return View(goalsAssist);
        }

        // POST: GoalsAssists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoalsAssist goalsAssist = db.GoalsAssists.Find(id);
            db.GoalsAssists.Remove(goalsAssist);
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
