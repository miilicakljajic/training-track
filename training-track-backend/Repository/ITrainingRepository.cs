using training_track_backend.DTOs;
using training_track_backend.Models;

namespace training_track_backend.Repository
{
    public interface ITrainingRepository
    {
        Task<Training?> CreateTraining(Training training);
        Task<IEnumerable<Training>?> GetTrainingsByUserId(int  userId);
        IEnumerable<Training>? GetTrainingsByUserIdAndMonth(int userId, int month);
    }
}
