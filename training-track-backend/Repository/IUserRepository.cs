using training_track_backend.Models;

namespace training_track_backend.Repository
{
    public interface IUserRepository
    {
        Task<User?> CreateUser(User user);
        Task<User?> GetUserById(int id);
        Task<IEnumerable<User>?> GetAllUsers();
        Task<User?> GetUserByEmail(string email);
        Task<int> GetMaxId();
    }
}