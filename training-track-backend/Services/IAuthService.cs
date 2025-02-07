using training_track_backend.DTOs;

namespace training_track_backend.Services
{
    public interface IAuthService
    {
        Task<JwtDTO?> Login(LoginDTO loginDTO);
        Task<JwtDTO?> Register(RegisterDTO registrationDTO);
    }
}
