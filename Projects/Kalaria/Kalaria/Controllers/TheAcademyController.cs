using Kalaria.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kalaria.Controllers
{
    public class TheAcademyController : Controller
    {
        private readonly IRepository _repository;

        public TheAcademyController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: FacilityImageController
        public IActionResult Index()
        {
            var images = _repository.GetAllFacilityImages();
            return View(images);
        }

        // GET: FacilityImageController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: FacilityImageController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacilityImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
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

        // GET: FacilityImageController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacilityImageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
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

        // GET: FacilityImageController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacilityImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
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
