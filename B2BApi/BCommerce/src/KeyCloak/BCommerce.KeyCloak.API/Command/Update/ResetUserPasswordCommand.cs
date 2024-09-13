using BCommerce.KeyCloak.API.DTOs;
using MediatR;

namespace BCommerce.KeyCloak.API.Command.Create
{
    public class ResetUserPasswordCommand : IRequest<bool>
    {
        public ResetPasswordDto ResetPasswordDto { get; set; }
        public ResetUserPasswordCommand(ResetPasswordDto resetPasswordDto)
        {
            ResetPasswordDto = resetPasswordDto;
        }
    }
}