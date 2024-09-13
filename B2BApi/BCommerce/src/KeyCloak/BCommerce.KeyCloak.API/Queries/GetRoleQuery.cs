using BCommerce.KeyCloak.API.Infrastructure.Entities;
using MediatR;

namespace BCommerce.KeyCloak.API.Queries
{
    public class GetRoleQuery : IRequest<List<Roles>>
    {
        public GetRoleQuery()
        {
        }
    }
}
