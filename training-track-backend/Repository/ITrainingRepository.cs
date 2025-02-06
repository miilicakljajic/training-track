using training_track_backend.Models;

namespace training_track_backend.Repository
{
    public interface ITrainingRepository
    {
        Task<Training?> CreateTraining(Training training);
        Task<IEnumerable<Training>?> GetTrainingsByUserId(int  userId);
    }
}
