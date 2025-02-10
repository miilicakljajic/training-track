namespace training_track_backend.DTOs
{
    public class JwtDTO
    {
        public string Token { get; set; }

        public JwtDTO() 
        {
            Token = string.Empty;
        }

        public JwtDTO(string token)
        {
            Token = token;
        }
    }
}
