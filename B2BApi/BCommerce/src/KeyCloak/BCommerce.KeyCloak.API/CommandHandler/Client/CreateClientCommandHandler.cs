using BCommerce.KeyCloak.API.Command.Create;
using BCommerce.KeyCloak.API.Services;
using MediatR;

namespace BCommerce.KeyCloak.API.CommandHandler.Client
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand,bool>
    {
        //private readonly KeycloakClient _keycloakClient;
        private readonly IClientService _clientService;
        public CreateClientCommandHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        //public async Task<bool> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        //{
        //    return true;
        //   // return await _keycloakClient.createro()
        //}

        public async Task<bool> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            return await _clientService.CreateClient(request.Business);
        }
    }
}