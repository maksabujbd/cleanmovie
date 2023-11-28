using CleanMovie.Application;
using CleanMovie.Domain;

namespace CleanMovie.Infrastructure;

public class MovieRepository : IMovieRepository
{
    // private static readonly List<Movie> Movies =
    // [
    //     new Movie { Id = 1, Name = "King Kong", Cost = 2 },
    //     new Movie { Id = 2, Name = "The Message", Cost = 5 }
    // ];

    private readonly MovieDbContext _movieDbContext;

    public MovieRepository(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }

    public List<Movie> GetAllMovies()
    {
        var movies = _movieDbContext.Movies.ToList();
        return movies;
    }

    public Movie createMovie(Movie movie)
    {
        _movieDbContext.Movies.Add(movie);
        _movieDbContext.SaveChanges();
        return movie;
    }
}