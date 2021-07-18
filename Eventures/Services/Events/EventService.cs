using Eventures.Data;
using Eventures.Models.Events;
using System.Collections.Generic;
using System.Linq;
using Eventures.Data.Models;

namespace Eventures.Services.Events
{
    public class EventService : IEventService
    {
        private readonly EventuresDbContext data;

        public EventService(EventuresDbContext data)
            => this.data = data;

        public IEnumerable<EventCityViewModel> GetCities()
            => this.data.Cities.Select(c => new EventCityViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        
        public void CreateEvent(CreateEventFormModel model)
        {
            var eventData = new Event
            {
                Name = model.Name,
                Place = model.Place,
                CityId = model.CityId,
                Start = model.Start,
                End = model.End,
                TotalTickets = model.TotalTickets,
                PricePerTicket = model.PricePerTicket
            };

            this.data.Events.Add(eventData);
            this.data.SaveChanges();
        }

        public bool IsCityExist(string cityId)
            => this.data.Cities.Any(c => c.Id == cityId);
    }
}
