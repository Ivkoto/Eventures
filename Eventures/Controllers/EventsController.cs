using System;
using Eventures.Models.Events;
using Eventures.Services.Events;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Eventures.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
            => this.eventService = eventService;


        public IActionResult Create() 
            => View(new CreateEventFormModel()
        {
            Cities = this.GetEventCities()
        });


        [HttpPost]
        public IActionResult Create(CreateEventFormModel @event)
        {
            if (!eventService.IsCityExist(@event.CityId))
            {
                this.ModelState.AddModelError(nameof(@event.CityId), "City does not exist.");
            }

            @event.Cities = this.GetEventCities();

            if (!ModelState.IsValid)
            {
                var test = ModelState.Root;
                return View(@event);
            }

            this.eventService.CreateEvent(@event);

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<EventCityViewModel> GetEventCities()
            =>  this.eventService.GetCities();
    }
}
