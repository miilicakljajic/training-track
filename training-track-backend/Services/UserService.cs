using training_track_backend.Models;
using training_track_backend.Repository;

namespace training_track_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> CreateUser(User user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<IEnumerable<User>?> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User?> GetUserByEmail(string  email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<int> GetMaxId()
        {
            return await _userRepository.GetMaxId();
        }
    }
}
