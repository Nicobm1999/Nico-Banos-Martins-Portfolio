using Kalaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kalaria.Controllers
{
    public class RequestsController : Controller
    {
        [HttpGet]
        public IActionResult RequestHomeAcademy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RequestHomeAcademy(RequestHomeAcademy requestHA)
        {

            return View();
        }

        [HttpGet]
        public IActionResult RequestOnSiteAcademy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RequestOnSiteAcademy(RequestOnSiteAcademy requestOA)
        {

            return View();
        }

        [HttpGet]
        public IActionResult RequestJobTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RequestJobTeacher(RequestJobTeacher requestJB)
        {

            return View();
        }

        [HttpGet]
        public IActionResult RequestJobEntertainer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RequestJobEntertainer(RequestJobEntertainer requestOA)
        {

            return View();
        }
    }
}
