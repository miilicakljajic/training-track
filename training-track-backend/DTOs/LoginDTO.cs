namespace training_track_backend.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginDTO()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public LoginDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
