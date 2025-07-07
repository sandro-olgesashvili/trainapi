using System;
using TrainApi.Models;
using TrainApi.Models.DTOs;
using TrainApi.Repositories;

namespace TrainApi.Services
{
    public class TrainService : ITrainService
    {
        private readonly ITrainRepository _trainRepository;

        public TrainService(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<IEnumerable<TrainResponse>> SearchTrainsAsync(TrainSearchRequest request)
        {
            return await _trainRepository.SearchTrainsAsync(request.Source, request.Destination);
        }

        public async Task AddTrainAsync(Train train)
        {
            await _trainRepository.AddTrainAsync(train);
            await _trainRepository.SaveChangesAsync();
        }
    }
}

