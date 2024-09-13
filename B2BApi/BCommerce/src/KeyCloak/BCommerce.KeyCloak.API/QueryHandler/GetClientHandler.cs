using BCommerce.KeyCloak.API.Infrastructure.Entities;
using BCommerce.KeyCloak.API.Queries;
using BCommerce.KeyCloak.API.Services;
using MediatR;

namespace BCommerce.KeyCloak.API.QueryHandler
{
    public class GetClientHandler : IRequestHandler<GetClientQuery, List<Clients>>
    {
        private readonly IClientService _clientService;
        public GetClientHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<List<Clients>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var response = await _clientService
                    .GetAll()
                    .ConfigureAwait(false);

            return response;
        }
    }
}
