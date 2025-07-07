using System;
using System.ComponentModel.DataAnnotations;

namespace TrainApi.Models
{
    public class Booking
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid TrainId { get; set; }
        public Train Train { get; set; } = null!;

        public int SeatNumber { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    }
}

