using System.Security.Claims;

namespace training_track_backend.Services
{
    public interface IJwtService
    {
        string GenerateToken(int id);
        ClaimsPrincipal? VerifyToken(string token);
    }
}
