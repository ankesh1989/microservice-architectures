using BCommerce.KeyCloak.API.Infrastructure.Entities;
using MediatR;

namespace BCommerce.KeyCloak.API.Queries
{
    public class GetClientQuery : IRequest<List<Clients>>
    {
        public GetClientQuery()
        {
        }
    }
}

