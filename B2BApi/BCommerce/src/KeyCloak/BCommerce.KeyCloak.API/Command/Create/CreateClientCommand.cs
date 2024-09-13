using BCommerce.KeyCloak.API.DTOs;
using MediatR;

namespace BCommerce.KeyCloak.API.Command.Create
{
    public class CreateClientCommand : IRequest<bool>
    {
        public BusinessDto Business { get; set; }
        public CreateClientCommand(BusinessDto businessDto)
        {
            Business = businessDto;
        }
    }
}