using CleanMovie.Application;
using CleanMovie.Domain;

namespace CleanMovie.Infrastructure;

public class MovieRepository : IMovieRepository
{
    private static readonly List<Movie> Movies =
    [
        new Movie { Id = 1, Name = "King Kong", Cost = 2 },
        new Movie { Id = 2, Name = "The Message", Cost = 5 }
    ];

    public List<Movie> GetAllMovies()
    {
        var movies = Movies;
        return movies;
    }
}