using BCommerce.KeyCloak.API.DTOs;
using MediatR;

namespace BCommerce.KeyCloak.API.Command.Create
{
    public class UpdateRoleCommand : IRequest<bool>
    {
        public UpdateRoleDto UpdateRoleDto { get; set; }
        public UpdateRoleCommand(UpdateRoleDto updateRoleDto)
        {
            UpdateRoleDto = updateRoleDto;
        }
    }
}