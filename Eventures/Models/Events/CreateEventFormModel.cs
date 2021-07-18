using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;

namespace Eventures.Models.Events
{
    public class CreateEventFormModel
    {
        [Display(Name = "Event name:")]
        public string Name { get; init; }

        [Display(Name = "Event place:")]
        public string Place { get; init; }

        [Display(Name = "Stat date:")]
        public DateTime Start { get; init; }

        [Display(Name = "End date:")]
        public DateTime End { get; init; }

        [Display(Name = "Tickets count:")]
        public int TotalTickets { get; init; }

        [Display(Name = "Ticket price:")]
        public decimal PricePerTicket { get; init; }
    }
}
