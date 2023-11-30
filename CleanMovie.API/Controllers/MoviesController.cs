using CleanMovie.Application;
using CleanMovie.Application.Queries.MovieQueries;
using CleanMovie.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;
    private readonly IMediator _mediator;

    public MoviesController(IMovieService movieService, IMediator mediator)
    {
        _movieService = movieService;
        _mediator = mediator;
    }

    // Get: Api/<MoviesController>
    // [HttpGet]
    // public IActionResult Get()
    // {
    //     var movies = _movieService.GetAllMovies();
    //     return Ok(movies);
    // }

    [HttpGet]
    public ActionResult<List<Movie>> Get()
    {
        var cmd = new GetMovieListQuery();
        var result = _mediator.Send(cmd);
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Movie> CreateMovie(Movie movie)
    {
        var result = _movieService.CreateMovie(movie);
        return Ok(result);
    }
}