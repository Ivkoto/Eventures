using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Eventures.Data;
using static Eventures.Data.DataConstants;

namespace Eventures.Models.Events
{
    public class CreateEventFormModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2,
            ErrorMessage = "Minimum length should be {2} and maximum length should be {1}.")]
        [Display(Name = "Event name:")]
        public string Name { get; init; }

        [StringLength(300, MinimumLength = 2,
            ErrorMessage = "Minimum length should be {2} and maximum length should be {1}")]
        [Display(Name = "Event place:")]
        public string Place { get; init; }

        [Range(MinYear, MaxYear , ErrorMessage = "The year must be between {1} and {2}")]
        [Display(Name = "Stat date:")]
        public DateTime Start { get; init; }

        [Range(MinYear, MaxYear, ErrorMessage = "The year must be between {1} and {2}")]
        [Display(Name = "End date:")]
        public DateTime End { get; init; }

        [Range(0, int.MaxValue, ErrorMessage = "Only positive numbers allowed.")]
        [Display(Name = "Tickets count:")]
        public int TotalTickets { get; init; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Only positive price is allowed")]
        [Display(Name = "Ticket price:")]
        public decimal PricePerTicket { get; init; }

        [Display(Name = "City:")]
        public string CityId { get; init; }

        public IEnumerable<EventCityViewModel> Cities { get; set; }
    }
}
