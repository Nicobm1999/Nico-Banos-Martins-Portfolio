using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRealState.Models;
using MyRealState.Models.Repository;
using NuGet.Protocol.Core.Types;

namespace MyRealState.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IRepository _repository;

        public PropertyController(IRepository repository)
        {
            _repository = repository;
        }
       

        public IActionResult Catalog(string tipo, string country, string province, string city, int ownerID, string status)
        {
            var filteredProperties = _repository.GetFilteredProperties(tipo, country,province, city, ownerID, status);



            return View(filteredProperties);
        }



        public IActionResult MyProperties(string tipo, string country,string city,string province, int ownerID, string status)
        {
            var filteredProperties = _repository.GetFilteredProperties(tipo, country,province, city, ownerID, status);
           

         
            return View(filteredProperties);
        }


        public IActionResult Details(int id)
        {
            var property = _repository.GetProperty(id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Property property)
        {
          _repository.CreateProperty(property);
            return RedirectToAction("MyProperties");
        }


        public ActionResult Update(int id)
        {
            var property = _repository.GetProperty(id);
            return View(property);
        }

        [HttpPost]
        public ActionResult Update(Property property)
        {
            _repository.UpdateProperty(property);
            return RedirectToAction("MyProperties");
        }

       
        [HttpPost]
        public ActionResult Delete(Property property)
        {
            _repository.DeleteProperty(property);
            return RedirectToAction("MyProperties");
        }







    }
}
