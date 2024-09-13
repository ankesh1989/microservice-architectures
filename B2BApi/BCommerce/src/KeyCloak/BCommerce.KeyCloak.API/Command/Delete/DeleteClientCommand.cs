using MediatR;

namespace BCommerce.KeyCloak.API.Command.Create
{
    public class DeleteClientCommand : IRequest<bool>
    {
        public DeleteClientCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}