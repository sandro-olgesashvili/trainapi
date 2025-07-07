using System;
namespace TrainApi.Models.DTOs
{
    public class BookingResponse
    {
        public Guid BookingId { get; set; }
        public string TrainName { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public int SeatNumber { get; set; }
        public DateTime BookingDate { get; set; }
    }
}

