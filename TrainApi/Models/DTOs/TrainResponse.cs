using System;
namespace TrainApi.Models.DTOs
{
    public class TrainResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public List<int> BookedSeats { get; set; } = new();
    }
}

