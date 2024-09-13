using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Infrastructure.Entities;

namespace BCommerce.KeyCloak.API.Services
{
    public interface IRoleService
    {
        Task<bool> CreateRole(CreateRoleDto createRoleDto);
        Task<bool> UpdateRole(UpdateRoleDto createRoleDto);
        Task<bool> DeleteRole(string roleId);
        Task<List<Roles>> GetAll();
    }
}