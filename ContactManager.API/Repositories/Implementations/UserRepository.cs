using ContactManager.API.Data;
using ContactManager.API.Models.Entities;
using ContactManager.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateUsersAsync(List<UserEntity> users)
        {
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity> DeleteUserAsync(Guid id)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser is not null)
            {
                _context.Users.Remove(existingUser);
                await _context.SaveChangesAsync();
                return existingUser;
            }
            return null;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

      
    }
}
