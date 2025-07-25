﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SimpleApiProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    /// <summary>
    /// Only users with the "Admin" role can access it.
    /// </summary>
    /// <returns>Admin-specific content</returns>
    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult AdminOnly()
    {
        return Ok("Sadece Admin kullanıcılar buraya erişebilir.");
    }

    /// <summary>
    /// Public endpoint accessible to everyone.
    /// </summary>
    /// <returns>Public message</returns>
    [AllowAnonymous]
    [HttpGet("public")]
    public IActionResult PublicAccess()
    {
        return Ok("Bu endpoint herkese açık.");
    }

    /// <summary>
    /// Endpoint open to all authenticated users.
    /// </summary>
    /// <returns>Username information</returns>
    [Authorize]
    [HttpGet("authenticated")]
    public IActionResult AuthenticatedUser()
    {
        var username = User.Identity.Name; // Get username from token
        return Ok($"Giriş yapmış kullanıcı: {username}");
    }
}

