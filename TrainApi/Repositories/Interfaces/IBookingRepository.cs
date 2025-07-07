using System;
using TrainApi.Models;

namespace TrainApi.Repositories
{
    public interface IBookingRepository
    {
        Task AddBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(Guid userId);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task SaveChangesAsync();
    }
}

