using System.ComponentModel.DataAnnotations;

namespace training_track_backend.Models
{
    public enum ExerciseType
    {
        CARDIO,
        STRENGTH_TRAINING,
        FLEXIBILITY
    }

    public class Training
    {
        [Key]
        public int Id { get; set; }
        [EnumDataType(typeof(ExerciseType))]
        public ExerciseType Type { get; set; }
        public string Duration { get; set; }
        public double BurnedCalories { get; set; }
        public uint Difficulty {  get; set; }
        public uint Fatique {  get; set; }
        public string Note { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public Training()
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
            User = new User();
        }

        public Training(int id, ExerciseType type, string duration, double burnedCalories, uint difficulty, uint fatique, string note, DateTime dateTime, int userId, User user)
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
            User = user;
        }
    }
}
