namespace Backend.Services;
using Backend.DbContext;
using Backend.DTOs;
using Backend.Model;
using Backend.Interfaces.Services;

public class UserService : IUserService
{   
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public UserResponseDto CreateUser(CreateUserDto dto)
    {
        var new_user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            IsAdmin = false
        };

        var response = new UserResponseDto
        {
            Id = new_user.Id,
            Name = new_user.Name,
            Email = new_user.Email
        };

        return response;
    }

    // public UserResponseDto? GetUser(int id){

    //     if(user==null) return null;

    //     var response = new UserResponseDto
    //     {
    //         Id = user.Id,
    //         Name = user.Name,
    //         Email = user.Email
    //     };

    //     return response;
    // }

    // public List<UserResponseDto> GetUsers(){
    //     return _user.Select(u=> new UserResponseDto{
    //         Id = u.Id,
    //         Name = u.Name,
    //         Email = u.Email
    //     }).ToList();
    // }
}