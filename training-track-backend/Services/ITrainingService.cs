using training_track_backend.DTOs;

namespace training_track_backend.Services
{
    public interface ITrainingService
    {
        Task<TrainingDTO?> CreateTraining(TrainingDTO training);
        Task<IEnumerable<TrainingDTO>?> GetTrainingsByUserId(int userId);
        IEnumerable<TrainingDTO>? GetTrainingsByUserIdAndMonth(int userId, int month);
        Task<IEnumerable<WeekDTO>?> GetTrainingsPerWeek(int userId, int month);
        IEnumerable<WeekDTO> GenerateWeeks(int year, int month);
    }
}
