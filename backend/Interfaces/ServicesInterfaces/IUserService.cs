namespace Backend.Interfaces.Services;
using Backend.DTOs;

public interface IUserService
{
    Task<UserResponseDto> CreateUser(CreateUserDto dto);

    Task<UserResponseDto?> GetUser(int id);

    Task<List<UserResponseDto>> GetUsers();
}