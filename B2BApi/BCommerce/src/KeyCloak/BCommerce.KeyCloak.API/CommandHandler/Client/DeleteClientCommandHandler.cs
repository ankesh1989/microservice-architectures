using BCommerce.KeyCloak.API.Command.Create;
using BCommerce.KeyCloak.API.Services;
using MediatR;

namespace BCommerce.KeyCloak.API.CommandHandler.Client
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand,bool>
    {
        private readonly IClientService  _clientService;
        public DeleteClientCommandHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
          return  await _clientService.DeleteClient(request.Id);
        }
    }
}