using CleanMovie.Application.Queries.UserQueries;
using CleanMovie.Domain;
using MediatR;

namespace CleanMovie.Application.Handlers.UserHandlers;

public class GetUserListHandlers:IRequestHandler<GetUserListQuery, List<Users>>
{
    private readonly IUserService _userService;

    public GetUserListHandlers(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<List<Users>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var result = _userService.GetAllUsers();
        return result;
    }
}