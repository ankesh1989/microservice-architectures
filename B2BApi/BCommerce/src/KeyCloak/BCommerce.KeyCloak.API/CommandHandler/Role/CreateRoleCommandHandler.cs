using BCommerce.KeyCloak.API.Command.Create;
using BCommerce.KeyCloak.API.Services;
using MediatR;

namespace BCommerce.KeyCloak.API.CommandHandler.Client
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, bool>
    {
        private readonly IRoleService _roleService;
        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
          return  await _roleService.CreateRole(request.CreateRoleDto);
        }
    }
}