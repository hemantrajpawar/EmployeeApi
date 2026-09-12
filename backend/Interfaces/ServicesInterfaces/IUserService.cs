namespace Backend.Interfaces.Services;
using Backend.DTOs;

public interface IUserService
{
    UserResponseDto CreateUser(CreateUserDto dto);
    // UserResponseDto? GetUser(int id);
    // List<UserResponseDto> GetUsers();
}
