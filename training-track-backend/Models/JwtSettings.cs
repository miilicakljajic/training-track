namespace training_track_backend.Models
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationTimeMinutes { get; set; }

        public JwtSettings() 
        {
            SecurityKey = string.Empty;
            Issuer = string.Empty;
            Audience = string.Empty;
            ExpirationTimeMinutes = 0;
        }

        public JwtSettings(string securityKey, string issuer, string audience, int expirationTimeMinutes)
        {
            SecurityKey = securityKey;
            Issuer = issuer;
            Audience = audience;
            ExpirationTimeMinutes = expirationTimeMinutes;
        }
    }
}
