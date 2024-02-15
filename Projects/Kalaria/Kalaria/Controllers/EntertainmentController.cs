using Kalaria.Models;
using Kalaria.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kalaria.Controllers
{
    public class EntertainmentController : Controller
    {
        private readonly IRepository _repository;

        public EntertainmentController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var events = _repository.GetAllEvents();
      
            return View(events);
        }


        // GET: Event/Details/5
        public IActionResult Details(int id)
        {
            var @event = _repository.GetEventById(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EventName,EventDescription,EventUrlImagen,EventLocation,EventType,MaxAttendees,RegistrationStartDate,RegistrationEndDate,EventStartDate,EventEndDate")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertEvent(@event);
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Event/Edit/5
        public IActionResult Edit(int id)
        {
            var @event = _repository.GetEventById(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EventID,EventName,EventDescription,EventUrlImagen,EventLocation,EventType,MaxAttendees,RegistrationStartDate,RegistrationEndDate,EventStartDate,EventEndDate")] Event @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.UpdateEvent(@event);
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Event/Delete/5
        public IActionResult Delete(int id)
        {
            var @event = _repository.GetEventById(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteEvent(id);
            return RedirectToAction("Index");
        }



    }
}
