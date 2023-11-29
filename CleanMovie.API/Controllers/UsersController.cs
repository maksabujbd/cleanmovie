using CleanMovie.Application;
using CleanMovie.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    
    
    [HttpGet]
    public IActionResult Get()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpPost]
    [Route("create")]
    public IActionResult CreateUser(Users user)
    {
        var result = _userService.CreateUser(user);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public IActionResult Authenticate(Users user)
    {
        var token = _userService.Authenticate(user);
        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(token);
    }
}