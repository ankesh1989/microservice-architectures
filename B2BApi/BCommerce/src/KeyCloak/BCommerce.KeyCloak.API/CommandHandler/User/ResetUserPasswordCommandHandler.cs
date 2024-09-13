using BCommerce.KeyCloak.API.Command.Create;
using BCommerce.KeyCloak.API.Services;
using MediatR;

namespace BCommerce.KeyCloak.API.CommandHandler.User
{
    public class ResetUserPasswordCommandHandler : IRequestHandler<ResetUserPasswordCommand, bool>
    {
        private readonly IUserService _userService;
        public ResetUserPasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
        {
          return  await _userService.ResetUserPassword(request.ResetPasswordDto);
        }
    }
}