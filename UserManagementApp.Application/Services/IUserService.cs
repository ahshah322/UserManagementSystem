using System.Reflection.Metadata;
using UserManagementApp.Domain.Entities;

namespace UserManagementApp.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> AddUserAsync(User user);
        Task<int> UpdateUserAsync(int userId, User user);
        Task<int> DeleteUserAsync(int userId);
    }
}
