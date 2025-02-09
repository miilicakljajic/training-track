namespace training_track_backend.DTOs
{
    public class WeekDTO
    {
        public uint weekNumber {  get; set; }
        public DateTime startOfWeek { get; set; }
        public DateTime endOfWeek { get; set; }
        public List<TrainingDTO> trainings { get; set; }

        public WeekDTO()
        {
            weekNumber = 1;
            startOfWeek = DateTime.MinValue;
            endOfWeek = DateTime.MinValue;
            trainings = new List<TrainingDTO>();
        }

        public WeekDTO(uint weekNumber, DateTime startOfWeek, DateTime endOfWeek, List<TrainingDTO> trainings)
        {
            this.weekNumber = weekNumber;
            this.startOfWeek = startOfWeek;
            this.endOfWeek = endOfWeek;
            this.trainings = trainings;
        }
    }
}
