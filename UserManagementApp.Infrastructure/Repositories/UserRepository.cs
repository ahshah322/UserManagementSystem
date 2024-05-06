using Microsoft.EntityFrameworkCore;
using UserManagementApp.Domain.Entities;
using UserManagementApp.Domain.IRepositries;
using UserManagementApp.Infrastructure.Data;

namespace UserManagementApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.AsNoTracking()
               .FirstOrDefaultAsync(b => b.Id == userId);
        }

        public async Task<int> DeleteUserAsync(int userId)
        {
            return await _context.Users
                  .Where(model => model.Id == userId)
                  .ExecuteDeleteAsync();
        }

        public async Task<int> UpdateUserAsync(int userId, User user)
        {
            return await _context.Users
                  .Where(model => model.Id == userId)
                  .ExecuteUpdateAsync(setters => setters
                    //.SetProperty(m => m.Id, user.Id)
                    .SetProperty(m => m.Name, user.Name)
                    .SetProperty(m => m.CNIC, user.CNIC)
                    .SetProperty(m => m.PhoneNumber, user.PhoneNumber)
                  );
        }
    }
}
