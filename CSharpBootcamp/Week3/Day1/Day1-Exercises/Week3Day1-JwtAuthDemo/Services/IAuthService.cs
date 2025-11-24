using Week3Day1_JwtAuthDemo.Models;

namespace Week3Day1_JwtAuthDemo.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(AuthRequestDto request);
        Task<AuthResponseDto?> LoginAsync(AuthRequestDto request);
    }
}
