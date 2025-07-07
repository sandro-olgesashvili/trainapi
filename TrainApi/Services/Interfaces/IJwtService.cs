using System;
using TrainApi.Models;

namespace TrainApi.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}

