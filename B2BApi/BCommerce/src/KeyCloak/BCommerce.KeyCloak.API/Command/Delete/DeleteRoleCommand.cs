using MediatR;

namespace BCommerce.KeyCloak.API.Command.Create
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public DeleteRoleCommand(string roleId)
        {
            RoleId = roleId;
        }
        public string RoleId { get; set; }
    }
}