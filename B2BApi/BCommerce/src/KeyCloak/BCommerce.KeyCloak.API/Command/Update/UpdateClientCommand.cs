using BCommerce.KeyCloak.API.DTOs;
using MediatR;

namespace BCommerce.KeyCloak.API.Command.Create
{
    public class UpdateClientCommand : IRequest<bool>
    {
        public UpdateBusinessDto UpdateBusinessDto { get; set; }
        public UpdateClientCommand(UpdateBusinessDto updateBusinessDto)
        {
            UpdateBusinessDto = updateBusinessDto;
        }
    }
}