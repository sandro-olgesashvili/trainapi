using System;
using TrainApi.Models;
using TrainApi.Models.DTOs;
using TrainApi.Repositories;

namespace TrainApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly ITrainRepository _trainRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(ITrainRepository trainRepository, IBookingRepository bookingRepository)
        {
            _trainRepository = trainRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingResponse> BookSeatAsync(Guid userId, BookingRequest request)
        {
            var train = await _trainRepository.GetByIdAsync(request.TrainId);
            if (train == null || train.AvailableSeats <= 0)
                throw new Exception("Train not found or no seats available");


            var bookings = await _bookingRepository.GetAllBookingsAsync();

            if (request.SeatNumber > 0)
            {
                if (bookings.Any(b => b.TrainId == request.TrainId && b.SeatNumber == request.SeatNumber))
                    throw new Exception($"Seat number {request.SeatNumber} is already booked for this train");
            }


            int seatNumber;
            if (request.SeatNumber > 0)
            {
                seatNumber = request.SeatNumber;
            }
            else
            {
                var bookedSeatNumbers = bookings.Where(b => b.TrainId == request.TrainId)
                                               .Select(b => b.SeatNumber)
                                               .ToList();
                var availableSeatNumbers = Enumerable.Range(1, train.TotalSeats)
                                                    .Except(bookedSeatNumbers)
                                                    .ToList();

                if (!availableSeatNumbers.Any())
                    throw new Exception("No available seats found");

                seatNumber = availableSeatNumbers[new Random().Next(0, availableSeatNumbers.Count)];
            }

            train.AvailableSeats -= 1;

            var booking = new Booking
            {
                UserId = userId,
                TrainId = train.Id,
                SeatNumber = seatNumber
            };

            await _bookingRepository.AddBookingAsync(booking);
            await _trainRepository.SaveChangesAsync();
            await _bookingRepository.SaveChangesAsync();

            return new BookingResponse
            {
                BookingId = booking.Id,
                TrainName = train.Name,
                Source = train.Source,
                Destination = train.Destination,
                SeatNumber = seatNumber,
                BookingDate = booking.BookingDate
            };
        }

        public async Task<IEnumerable<BookingResponse>> GetUserBookingsAsync(Guid userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUserIdAsync(userId);
            return bookings.Select(b => new BookingResponse
            {
                BookingId = b.Id,
                TrainName = b.Train.Name,
                Source = b.Train.Source,
                Destination = b.Train.Destination,
                SeatNumber = b.SeatNumber,
                BookingDate = b.BookingDate
            });
        }

        public async Task<IEnumerable<BookingResponse>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            return bookings.Select(b => new BookingResponse
            {
                BookingId = b.Id,
                TrainName = b.Train.Name,
                Source = b.Train.Source,
                Destination = b.Train.Destination,
                SeatNumber = b.SeatNumber,
                BookingDate = b.BookingDate
            });
        }
    }
}

