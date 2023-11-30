using CleanMovie.Application.Queries.MovieQueries;
using CleanMovie.Domain;
using MediatR;

namespace CleanMovie.Application.Handlers.MovieHandlers;

public class GetMovieListHandlers:IRequestHandler<GetMovieListQuery, List<Movie>>
{
    private readonly IMovieService _movieService;

    public GetMovieListHandlers(IMovieService movieService)
    {
        _movieService = movieService;
    }
    public async Task<List<Movie>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
    {
        var result =  _movieService.GetAllMovies();
        return result;
    }
}