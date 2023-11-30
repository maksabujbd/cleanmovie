using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanMovie.Application;
using CleanMovie.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CleanMovie.Infrastructure;

public class UserRepository(MovieDbContext movieDbContext, IConfiguration configuration)
    : IUserRepository
{
    public Tokens Authenticate(Users user)
    {
        var existingUser = movieDbContext.Users.Any(x => x.Name == user.Name && x.Password == user.Password);
        if (!existingUser)
        {
            return null!;
        }

        // Generate JSON Web Token
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Name)
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Tokens { Token = tokenHandler.WriteToken(token) };
    }

    public Users CreateUser(Users user)
    {
        movieDbContext.Users.Add(user);
        movieDbContext.SaveChanges();
        return user;
    }

    public List<Users> GetAllUsers()
    {
        var users = movieDbContext.Users.ToList();
        return users;
    }

    public Users GetUserById(int id)
    {
        var user = movieDbContext.Users.Find(id);
        return user!;
    }
}