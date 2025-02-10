namespace training_track_backend.DTOs
{
    public class WeekDTO
    {
        public uint WeekNumber {  get; set; }
        public DateTime StartOfWeek { get; set; }
        public DateTime EndOfWeek { get; set; }
        public List<TrainingDTO> Trainings { get; set; }
        public int NumOfTrainings { get; set; }
        public String TotalDuration { get; set; }
        public double AverageDifficulty { get; set; }
        public double AverageFatique {  get; set; }

        public WeekDTO()
        {
            WeekNumber = 1;
            StartOfWeek = DateTime.MinValue;
            EndOfWeek = DateTime.MinValue;
            Trainings = new List<TrainingDTO>();
            NumOfTrainings = 0;
            TotalDuration = "00:00";
            AverageDifficulty = 0;
            AverageFatique = 0;
        }

        public WeekDTO(uint weekNumber, DateTime startOfWeek, DateTime endOfWeek, List<TrainingDTO> trainings, int numOfTrainings, string totalDuration, double averageDifficulty, double averageFatique)
        {
            this.WeekNumber = weekNumber;
            this.StartOfWeek = startOfWeek;
            this.EndOfWeek = endOfWeek;
            this.Trainings = trainings;
            this.NumOfTrainings = numOfTrainings;
            this.TotalDuration = totalDuration;
            this.AverageDifficulty = averageDifficulty;
            this.AverageFatique = averageFatique;
        }
    }
}
