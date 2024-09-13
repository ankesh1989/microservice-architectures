using MediatR;

namespace BCommerce.KeyCloak.API.Command.Create
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public DeleteUserCommand(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; set; }
    }
}