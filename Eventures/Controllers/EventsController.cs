using Eventures.Models.Events;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class EventsController : Controller 
    {
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateEventFormModel even)
        {
            return View();
        }
    }
}
