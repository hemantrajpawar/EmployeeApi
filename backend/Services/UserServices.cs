namespace Backend.Services;
using Backend.DbContext;
using Backend.DTOs;
using Backend.Model;
using Backend.Interfaces.Services;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{   
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<UserResponseDto> CreateUser(CreateUserDto dto)
    {
        var new_user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = BCrypt.HashPassword(dto.Password),
            IsAdmin = false
        };

        _db.Users.Add(new_user);

        await _db.SaveChangesAsync();

        var response = new UserResponseDto
        {
            Id = new_user.Id,
            Name = new_user.Name,
            Email = new_user.Email
        };

        return response;
    }

    public async Task<UserResponseDto?> GetUser(int id){

        var user = await _db.Users.FindAsync(id);

        if(user==null) return null;

        var response = new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };

        return response;
    }

    public async Task<List<UserResponseDto>> GetUsers(){
        var temp_user= await _db.Users.ToListAsync();
        return temp_user.Select(u=> new UserResponseDto{
            Id=u.Id,
            Name=u.Name,
            Email=u.Email
        }).ToList();
    }
}