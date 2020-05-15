using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthApi.Core.Interfaces;
using JWTAuthApi.Core.Models;

namespace JWTAuthApi.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddAsync(User user)
        {
            var userId = await _userRepository.AddAsync(user);
            return userId;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task UpdateAsync(User updatedUser)
        {
            await _userRepository.UpdateAsync(updatedUser);
        }

        public async Task DeleteAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }
    }
}