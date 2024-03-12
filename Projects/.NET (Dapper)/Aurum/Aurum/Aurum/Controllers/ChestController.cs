using Aurum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aurum.Controllers
{
    public class ChestController : Controller
    {
        // GET: ChestController
        public ActionResult Index()
        {
            var chest = new Chest();
            chest.GoldWeight = 100;
            chest.SilverWeight = 50;
            chest.Id = 1;
            chest.UserID = 1;
            return View(chest);
        }


        // GET: ChestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
