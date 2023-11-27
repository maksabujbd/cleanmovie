using CleanMovie.Domain;

namespace CleanMovie.Application;

// This is a use case
public interface IMovieService
{
    List<Movie> GetAllMovies();
}