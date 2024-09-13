using BCommerce.KeyCloak.API.DTOs;
using MediatR;

namespace BCommerce.CommonService.API.Queries.City
{
    public class GetTokenQuery : IRequest<KeycloakTokenResponseDto?>
    {
        public KeycloakUserDto KeycloakUserDto { get; set; }
        public GetTokenQuery(KeycloakUserDto keycloakUserDto)
        {
            KeycloakUserDto = keycloakUserDto;
        }
    }
}