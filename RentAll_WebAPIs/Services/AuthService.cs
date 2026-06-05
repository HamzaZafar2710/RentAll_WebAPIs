using RentAll_WebAPIs.DTOs;
using RentAll_WebAPIs.Helpers;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;

    public AuthService(
        IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<LoginResponseDto?>
        LoginAsync(LoginDto dto)
    {
        var user =
            await _repository
                .GetByEmailAsync(dto.Email);

        if (user == null)
            return null;

        bool valid =
            PasswordHelper.VerifyPassword(
                dto.Password,
                user.PasswordHash);

        if (!valid)
            return null;

        return new LoginResponseDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role
        };
    }
}