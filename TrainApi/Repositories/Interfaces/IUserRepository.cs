using System;
using TrainApi.Models;

namespace TrainApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByIdAsync(Guid id);
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
    }
}

