using BCommerce.KeyCloak.API.DTOs;
using MediatR;

namespace BCommerce.KeyCloak.API.Command.Create
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public UpdateUserDto UpdateUserDto { get; set; }
        public UpdateUserCommand(UpdateUserDto updateUserDto)
        {
            UpdateUserDto = updateUserDto;
        }
    }
}