using System;
using TrainApi.Models.DTOs;

namespace TrainApi.Services
{
    public interface IBookingService
    {
        Task<BookingResponse> BookSeatAsync(Guid userId, BookingRequest request);
        Task<IEnumerable<BookingResponse>> GetUserBookingsAsync(Guid userId);
        Task<IEnumerable<BookingResponse>> GetAllBookingsAsync();
    }
}

