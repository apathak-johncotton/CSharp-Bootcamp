using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Week3Day1_JwtAuthDemo.Models;

namespace Week3Day1_JwtAuthDemo.Services
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpiresInMinutes { get; set; }
    }

    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;

        // simple in-memory user store for today
        private static readonly List<User> _users = new();

        public AuthService(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
        }

        public Task<bool> RegisterAsync(AuthRequestDto request)
        {
            if (_users.Any(u => u.Email == request.Email))
                return Task.FromResult(false);

            var user = new User
            {
                Email = request.Email,
                // for demo only: normally you'd use a proper password hasher like BCrypt/PBKDF2
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "User"
            };

            _users.Add(user);
            return Task.FromResult(true);
        }

        public Task<AuthResponseDto?> LoginAsync(AuthRequestDto request)
        {
            var user = _users.SingleOrDefault(u => u.Email == request.Email);
            if (user is null) return Task.FromResult<AuthResponseDto?>(null);

            var isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isValid) return Task.FromResult<AuthResponseDto?>(null);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(ClaimTypes.Role, user.Role)
            };

            var creds = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );

            var expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenString = tokenHandler.WriteToken(token);

            var response = new AuthResponseDto
            {
                Token = tokenString,
                ExpiresAt = expires
            };

            return Task.FromResult<AuthResponseDto?>(response);
        }
    }
}
