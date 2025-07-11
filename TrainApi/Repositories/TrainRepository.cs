using System;
using Microsoft.EntityFrameworkCore;
using TrainApi.Data;
using TrainApi.Models;
using TrainApi.Models.DTOs;

namespace TrainApi.Repositories
{
    public class TrainRepository : ITrainRepository
    {
        private readonly AppDbContext _context;

        public TrainRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainResponse>> SearchTrainsAsync(string source, string destination)
        {
            return await _context.Trains
                .Include(t => t.Bookings)
                .Where(t => t.Source.Contains(source) && t.Destination.Contains(destination))
                .Select(t => new TrainResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    Source = t.Source,
                    Destination = t.Destination,
                    TotalSeats = t.TotalSeats,
                    AvailableSeats = t.AvailableSeats,
                    BookedSeats = t.Bookings.Select(b => b.SeatNumber).ToList()
                })
                .ToListAsync();
        }

        public async Task<Train?> GetByIdAsync(Guid id)
        {
            return await _context.Trains.FindAsync(id);
        }

        public async Task AddTrainAsync(Train train)
        {
            train.AvailableSeats = train.TotalSeats;
            await _context.Trains.AddAsync(train);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

