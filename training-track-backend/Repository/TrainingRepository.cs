using Microsoft.EntityFrameworkCore;
using training_track_backend.Models;

namespace training_track_backend.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly AppDbContext _appDbContext;

        public TrainingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Training?> CreateTraining(Training training)
        {
            await _appDbContext.AddAsync(training);
            await _appDbContext.SaveChangesAsync();

            return training;
        }

        public async Task<IEnumerable<Training>?> GetTrainingsByUserId(int userId)
        {
            return await _appDbContext.Trainings.Where(t => t.User.Id == userId).ToListAsync();
        }
        
        public IEnumerable<Training>? GetTrainingsByUserIdAndMonth(int userId, int month)
        {
            return _appDbContext.Trainings.Where(t => t.User.Id == userId && t.DateTime.Month == month).ToList();
        }
    }
}
