using Microsoft.AspNetCore.Mvc;
using SimpleApiProject.Models;
using SimpleApiProject.Services;
using System.Collections.Generic;

namespace SimpleApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(JwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        //// You must authenticate the user here. (Database or other system)

        // Example: if user email and password are correct
        if (!string.IsNullOrEmpty(loginRequest.Email) && !string.IsNullOrEmpty(loginRequest.Password))
        {
            if (loginRequest.Email.Trim().Equals("test@test.com") && loginRequest.Password.Trim().Equals("123"))
            {
                // Get the user's id and role (example)
                string userId = "1";
                var roles = new List<string> { "Admin", "User" };

                // Generate tokens
                var token = _jwtTokenService.GenerateToken(userId, loginRequest.Email, roles);

                // Return the token
                return Ok(new { Token = token });
            }
            return Unauthorized("Email veya parola yanlış.");
        }
        else
        {
            return Unauthorized("Kullanıcı Adı veya Şifre boş olamaz");
        }
    }
}
