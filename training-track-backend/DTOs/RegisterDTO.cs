namespace training_track_backend.DTOs
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterDTO() 
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public RegisterDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
