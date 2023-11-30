using CleanMovie.Application.Queries.UserQueries;
using CleanMovie.Domain;
using MediatR;

namespace CleanMovie.Application.Handlers.UserHandlers;

public class GetUserByIdHandlers:IRequestHandler<GetUserByIdQuery,Users>
{
    private readonly IUserService _userService;
    private readonly IMediator _mediator;

    public GetUserByIdHandlers(IUserService userService, IMediator mediator)
    {
        _userService = userService;
        _mediator = mediator;
    }
    public async Task<Users> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var users = _mediator.Send(new GetUserListQuery(), cancellationToken);
        // var result = _userService.GetUserById(request.Id);
        var result = users.Result.FirstOrDefault(x => x.UserId == request.Id)!;
        return result;
    }
}