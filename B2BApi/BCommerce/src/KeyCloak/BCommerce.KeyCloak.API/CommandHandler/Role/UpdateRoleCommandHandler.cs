using BCommerce.KeyCloak.API.Command.Create;
using BCommerce.KeyCloak.API.Services;
using MediatR;

namespace BCommerce.KeyCloak.API.CommandHandler.Client
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IRoleService _roleService;
        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
          return  await _roleService.UpdateRole(request.UpdateRoleDto);
        }
    }
}