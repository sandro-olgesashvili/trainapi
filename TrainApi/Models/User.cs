using System;
using System.ComponentModel.DataAnnotations;

namespace TrainApi.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "User"; // "User" or "Admin"

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

