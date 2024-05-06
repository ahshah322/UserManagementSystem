using UserManagementApp.Domain.Entities;

namespace UserManagementApp.Domain.IRepositries
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> AddUserAsync(User user);
        Task<int> UpdateUserAsync(int userId, User user);
        Task<int> DeleteUserAsync(int userId);
    }
}
