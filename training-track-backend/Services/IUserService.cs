using training_track_backend.Models;

namespace training_track_backend.Services
{
    public interface IUserService
    {
        Task<User?> CreateUser(User user);
        Task<User?> GetUserById(int id);
        Task<IEnumerable<User>?> GetAllUsers();

    }
}
