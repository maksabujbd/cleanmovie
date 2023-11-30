using CleanMovie.Application;
using CleanMovie.Application.Queries.MovieQueries;
using CleanMovie.Application.Queries.UserQueries;
using CleanMovie.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMediator _mediator;

    public UsersController(IUserService userService, IMediator mediator)
    {
        _userService = userService;
        _mediator = mediator;
    }
    
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get()
    {
        var cmd = new GetUserListQuery();
        var result = _mediator.Send(cmd);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var cmd = new GetUserByIdQuery { Id = id };
        var result = _mediator.Send(cmd);
        return Ok(result);
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