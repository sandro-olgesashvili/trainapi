using System;
namespace TrainApi.Models.DTOs
{
    public class TrainSearchRequest
    {
        public string Source { get; set; } = null!;
        public string Destination { get; set; } = null!;
    }
}

