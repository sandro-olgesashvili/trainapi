using System;
using TrainApi.Models;
using TrainApi.Models.DTOs;

namespace TrainApi.Services
{
    public interface ITrainService
    {
        Task<IEnumerable<TrainResponse>> SearchTrainsAsync(TrainSearchRequest request);
        Task AddTrainAsync(Train train);
    }
}

