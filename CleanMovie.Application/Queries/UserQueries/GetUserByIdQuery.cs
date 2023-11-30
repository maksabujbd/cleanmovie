using CleanMovie.Domain;
using MediatR;

namespace CleanMovie.Application.Queries.UserQueries;

public class GetUserByIdQuery:IRequest<Users>
{
    public int Id { get; set; }
}