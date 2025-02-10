using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using training_track_backend.DTOs;
using training_track_backend.Models;

namespace training_track_backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthService(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        public async Task<JwtDTO?> Login(LoginDTO loginDTO)
        {
            User? user = await _userService.GetUserByEmail(loginDTO.Email);

            if (user != null)
            {
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: loginDTO.Password,
                salt: BitConverter.GetBytes(user.Id),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

                if(user.Password.Equals(hashed))
                {
                    return new JwtDTO(_jwtService.GenerateToken(user.Id));
                }

                return null;
            }

            return null;
        }

        public async Task<JwtDTO?> Register(RegisterDTO registerDTO)
        {
            User? user = new User(0, registerDTO.Email, registerDTO.Password, new List<Training>());

            int id = _userService.GetMaxId().Result + 1;
            user.Id = id;

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: user.Password,
            salt: BitConverter.GetBytes(id),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            user.Password = hashed;

            user = await _userService.CreateUser(user);

            if (user != null)
            {
                return new JwtDTO(_jwtService.GenerateToken(user.Id));
            }
            else
            {
                return null;
            }
        }
    }
}
