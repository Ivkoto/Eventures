using System.Collections.Generic;
using Eventures.Data.Models;
using Eventures.Models.Events;

namespace Eventures.Services.Events
{
    public interface IEventService
    {
        public IEnumerable<EventCityViewModel> GetCities();

        public bool IsCityExist(string cityId);

        public void CreateEvent(CreateEventFormModel model);
    }
}
