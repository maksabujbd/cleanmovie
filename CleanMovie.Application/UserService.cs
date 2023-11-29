using CleanMovie.Domain;

namespace CleanMovie.Application;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Tokens Authenticate(Users user)
    {
        var token = _userRepository.Authenticate(user);
        return token;
    }

    public Users CreateUser(Users user)
    {
        var newUser = _userRepository.CreateUser(user);
        return newUser;
    }

    public List<Users> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        return users;
    }
}