using training_track_backend.DTOs;
using training_track_backend.Models;
using training_track_backend.Repository;

namespace training_track_backend.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<TrainingDTO?> CreateTraining(TrainingDTO dto) 
        {
            Training training = new Training(dto.Id, dto.Type, dto.Duration, dto.BurnedCalories, dto.Difficulty, dto.Fatique, dto.Note, dto.DateTime, dto.UserId, null);
            await _trainingRepository.CreateTraining(training);

            return dto;
        }
        public async Task<IEnumerable<TrainingDTO>?> GetTrainingsByUserId(int userId)
        {
            var trainings = await _trainingRepository.GetTrainingsByUserId(userId);
            List<TrainingDTO> dto = new List<TrainingDTO>();

            foreach(Training t in trainings)
            {
                dto.Add(new TrainingDTO(t.Id, t.Type, t.Duration, t.BurnedCalories, t.Difficulty, t.Fatique, t.Note, t.DateTime, t.UserId));
            }

            return dto;
        }
    }
}
