using BCommerce.KeyCloak.API.DTOs;
using MediatR;

namespace BCommerce.CommonService.API.Queries.City
{
    public class GetRefreshTokenQuery : IRequest<KeycloakTokenResponseDto?>
    {
        public RefreshTokenDto RefreshTokenDto { get; set; }
        public GetRefreshTokenQuery(RefreshTokenDto refreshTokenDto)
        {
            RefreshTokenDto = refreshTokenDto;
        }
    }
}