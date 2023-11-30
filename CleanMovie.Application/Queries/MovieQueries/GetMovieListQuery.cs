using CleanMovie.Domain;
using MediatR;

namespace CleanMovie.Application.Queries.MovieQueries;

public class GetMovieListQuery:IRequest<List<Movie>>
{
    
}