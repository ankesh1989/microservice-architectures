using BCommerce.KeyCloak.API.Infrastructure.Entities;
using BCommerce.KeyCloak.API.Queries;
using BCommerce.KeyCloak.API.Services;
using MediatR;

namespace BCommerce.KeyCloak.API.QueryHandler
{
    public class GetRoleHandler :IRequestHandler<GetRoleQuery, List<Roles>> 
    {
        private readonly IRoleService _roleService;
        public GetRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<List<Roles>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var response = await _roleService
                    .GetAll()
                    .ConfigureAwait(false);

            return response;
        }
    }
}
