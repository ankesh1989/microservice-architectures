using BCommerce.KeyCloak.API.DTOs;
using MediatR;

namespace BCommerce.KeyCloak.API.Command.Create
{
    public class CreateRoleCommand : IRequest<bool>
    {
        public CreateRoleDto CreateRoleDto { get; set; }
        public CreateRoleCommand(CreateRoleDto createRoleDto)
        {
            CreateRoleDto = createRoleDto;
        }
    }
}