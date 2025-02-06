using System.ComponentModel.DataAnnotations;

namespace training_track_backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Training> Trainings { get; set; }

        public User()
        {
            Id = 0;
            Email = string.Empty;
            Password = string.Empty;
            Trainings = new List<Training>();
        }

        public User(int id, string email, string password, List<Training> trainings)
        {
            Id = id;
            Email = email;
            Password = password;
            Trainings = trainings;
        }
    }
}
