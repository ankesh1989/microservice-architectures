using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Infrastructure.Entities;

namespace BCommerce.KeyCloak.API.Services
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserDto createUserDto);
        Task<bool> UpdateUser(UpdateUserDto updateUserDto);
        Task<bool> DeleteUser(string userId);
        Task<bool> ResetUserPassword(ResetPasswordDto resetPasswordDto);
        Task<List<Users>> GetAll();
    }
}