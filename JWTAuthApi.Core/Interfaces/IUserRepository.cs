using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthApi.Core.Models;

namespace JWTAuthApi.Core.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User updatedUser);
        Task DeleteAsync(int userId);
    }
}