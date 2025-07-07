using System;
namespace TrainApi.Models.DTOs
{
    public class BookingRequest
    {
        public Guid TrainId { get; set; }
        public int SeatNumber { get; set; }
    }
}

