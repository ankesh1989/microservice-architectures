using BCommerce.KeyCloak.API.Command.Create;
using BCommerce.KeyCloak.API.Services;
using MediatR;

namespace BCommerce.KeyCloak.API.CommandHandler.Client
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, bool>
    {
        private readonly IClientService  _clientService;
        public UpdateClientCommandHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
          return  await _clientService.UpdateClient(request.UpdateBusinessDto);
        }
    }
}