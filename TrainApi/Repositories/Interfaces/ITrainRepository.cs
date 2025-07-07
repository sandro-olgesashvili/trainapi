using System;
using TrainApi.Models;
using TrainApi.Models.DTOs;

namespace TrainApi.Repositories
{
    public interface ITrainRepository
    {
        Task<IEnumerable<TrainResponse>> SearchTrainsAsync(string source, string destination);
        Task<Train?> GetByIdAsync(Guid id);
        Task AddTrainAsync(Train train);
        Task SaveChangesAsync();
    }
}

