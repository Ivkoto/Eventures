using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Data.Models
{
    public class City
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        public IEnumerable<Event> Events { get; init; } = new List<Event>();
    }
}
