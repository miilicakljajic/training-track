using training_track_backend.DTOs;

namespace training_track_backend.Services
{
    public interface ITrainingService
    {
        Task<TrainingDTO?> CreateTraining(TrainingDTO training);
        Task<IEnumerable<TrainingDTO>?> GetTrainingsByUserId(int userId);
    }
}
