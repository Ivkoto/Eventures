using System;
using System.ComponentModel.DataAnnotations;
using static Eventures.Data.DataConstants;

namespace Eventures.Data.Models
{
    
    public class Event
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(EventNameMaxLength)]
        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TotalTickets { get; set; }

        public decimal PricePerTicket { get; set; }

        public string CityId { get; set; }

        public City City { get; set; }

    }
}
