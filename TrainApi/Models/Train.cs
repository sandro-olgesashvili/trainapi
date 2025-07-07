using System;
using System.ComponentModel.DataAnnotations;

namespace TrainApi.Models
{
    public class Train
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

