using CleanMovie.Domain;
using MediatR;

namespace CleanMovie.Application.Queries.UserQueries;

public class GetUserListQuery:IRequest<List<Users>>
{
    
}