using Microsoft.AspNetCore.Mvc;
using RentAll_WebAPIs.DTOs;

namespace RentAll_WebAPIs.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(
        IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginDto dto)
    {
        var user =
            await _service.LoginAsync(dto);

        if (user == null)
        {
            return Unauthorized(
                new
                {
                    message =
                    "Invalid credentials"
                });
        }

        return Ok( new { id = user.Id, userName = user.Username });
    }
}