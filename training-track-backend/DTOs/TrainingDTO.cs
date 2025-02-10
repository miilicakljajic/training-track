using System.ComponentModel.DataAnnotations;
using training_track_backend.Models;

namespace training_track_backend.DTOs
{
    public class TrainingDTO
    {
        public int Id { get; set; }
        public ExerciseType Type { get; set; }
        public string Duration { get; set; }
        public double BurnedCalories { get; set; }
        public uint Difficulty { get; set; }
        public uint Fatique { get; set; }
        public string Note { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set;}

        public TrainingDTO()
        {
            Id = 0;
            Type = ExerciseType.CARDIO;
            Duration = String.Empty;
            BurnedCalories = 0;
            Difficulty = 1;
            Fatique = 2;
            Note = String.Empty;
            DateTime = DateTime.MinValue;
            UserId = 0;
        }

        public TrainingDTO(int id, ExerciseType type, string duration, double burnedCalories, uint difficulty, uint fatique, string note, DateTime dateTime, int userId)
        {
            Id = id;
            Type = type;
            Duration = duration;
            BurnedCalories = burnedCalories;
            Difficulty = difficulty;
            Fatique = fatique;
            Note = note;
            DateTime = dateTime;
            UserId = userId;
        }
    }
}
