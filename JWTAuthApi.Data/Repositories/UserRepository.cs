using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthApi.Core.Interfaces;
using JWTAuthApi.Core.Models;
using JWTAuthApi.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task UpdateAsync(User updatedUser)
        {
            _dbContext.Entry(updatedUser).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int userId)
        {
            var userToDelete = await _dbContext.Users.FindAsync(userId);
            _dbContext.Users.Remove(userToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}