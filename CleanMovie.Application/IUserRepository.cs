using CleanMovie.Domain;

namespace CleanMovie.Application;

public interface IUserRepository
{
    Tokens Authenticate(Users user);
    Users CreateUser(Users user);
    List<Users> GetAllUsers();
    Users GetUserById(int id);
}