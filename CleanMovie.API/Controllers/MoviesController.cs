using CleanMovie.Application;
using CleanMovie.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
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
        var movies = _movieService.GetAllMovies();
        return Ok(movies);
    }

    [HttpPost]
    public ActionResult<Movie> CreateMovie(Movie movie)
    {
        var result = _movieService.CreateMovie(movie);
        return Ok(result);
    }
}