using UserManagementApp.Domain.Entities;
using UserManagementApp.Domain.IRepositries;

namespace UserManagementApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await _userRepository.AddUserAsync(user);
        }

        public async Task<int> UpdateUserAsync(int userId, User user)
        {
            return await _userRepository.UpdateUserAsync(userId, user);
        }

        public async Task<int> DeleteUserAsync(int userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }
    }
}
