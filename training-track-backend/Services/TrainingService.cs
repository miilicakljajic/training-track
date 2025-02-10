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

        public IEnumerable<TrainingDTO>? GetTrainingsByUserIdAndMonth(int userId, int month)
        {
            var trainings = _trainingRepository.GetTrainingsByUserIdAndMonth(userId, month);
            List<TrainingDTO> dto = new List<TrainingDTO>();

            foreach (Training t in trainings)
            {
                dto.Add(new TrainingDTO(t.Id, t.Type, t.Duration, t.BurnedCalories, t.Difficulty, t.Fatique, t.Note, t.DateTime, t.UserId));
            }

            return dto;
        }

        public IEnumerable<WeekDTO> GenerateWeeks(int year, int month)
        {
            var weeks = new List<WeekDTO>();
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            DateTime currentWeekStart = firstDayOfMonth;
            uint i = 1;

            while (currentWeekStart <= lastDayOfMonth)
            {
                DateTime currentWeekEnd = currentWeekStart.AddDays(6 - (int)currentWeekStart.DayOfWeek + 1);

                if (currentWeekEnd > lastDayOfMonth)
                {
                    currentWeekEnd = lastDayOfMonth;
                }

                weeks.Add(new WeekDTO(i, currentWeekStart, currentWeekEnd, new List<TrainingDTO>(), 0, "00:00", 0, 0));
                i++;

                currentWeekStart = currentWeekEnd.AddDays(1);
            }

            return weeks;
        }

        public async Task<IEnumerable<WeekDTO>?> GetTrainingsPerWeek(int userId, int month)
        {
            List<WeekDTO> weeks = GenerateWeeks(2025, month).ToList();
            List<TrainingDTO> trainings = GetTrainingsByUserIdAndMonth(userId, month).ToList();

            foreach (WeekDTO w in weeks) 
            {
                double difficulty = 0;
                double fatique = 0;

                foreach (TrainingDTO t in trainings)
                {
                    if (t.DateTime.Date >= w.StartOfWeek.Date && t.DateTime.Date <= w.EndOfWeek.Date)
                    {
                        int hourWeek = Convert.ToInt32(w.TotalDuration.Split(":")[0]);
                        int minuteWeek = Convert.ToInt32(w.TotalDuration.Split(':')[1]);

                        int hourTraining = Convert.ToInt32(t.Duration.Split(":")[0]);
                        int minuteTraining = Convert.ToInt32(t.Duration.Split(':')[1]);

                        hourWeek += hourTraining;
                        minuteWeek += minuteTraining;

                        if(minuteWeek >= 60)
                        {
                            minuteWeek -= 60;
                            hourWeek += 1;
                        }

                        w.NumOfTrainings++;
                        w.TotalDuration = Convert.ToString(hourWeek) + ":" + Convert.ToString(minuteWeek);
                        difficulty += t.Difficulty;
                        fatique += t.Fatique;

                        w.Trainings.Add(t);
                    }
                }
                if(w.NumOfTrainings > 0)
                {
                    w.AverageDifficulty = difficulty / w.NumOfTrainings;
                    w.AverageFatique = fatique / w.NumOfTrainings;
                }   
            }

            return weeks;
        }
    }
}
