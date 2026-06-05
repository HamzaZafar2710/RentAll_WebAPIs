using RentAll_WebAPIs.DTOs;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(
        LoginDto dto);
}