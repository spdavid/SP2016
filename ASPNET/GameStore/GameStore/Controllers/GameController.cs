using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Helpers;
using GameStore.Models;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View(GameHelper.Games);
        }

        // GET: Game/Details/5
        public ActionResult Details(int id)
        {
            return View(GameHelper.GetGameById(id));
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult Create(Game newGame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GameHelper.AddGame(newGame);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GameHelper.GetGameById(id));
        }

        // POST: Game/Edit/5
        [HttpPost]
        public ActionResult Edit(Game updatedGame)
        {
            try
            {
                GameHelper.EditGame(updatedGame);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int id, string foo)
        {
            return View();
        }

        // POST: Game/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                GameHelper.DeleteGame(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
