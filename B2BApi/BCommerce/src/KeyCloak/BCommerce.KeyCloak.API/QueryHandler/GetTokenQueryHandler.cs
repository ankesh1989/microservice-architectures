using BCommerce.CommonService.API.Queries.City;
using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Services;
using MediatR;

namespace BCommerce.CommonService.API.QueryHandler.City
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, KeycloakTokenResponseDto?>
    {
        private readonly IAuthService _authService;

        public GetTokenQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<KeycloakTokenResponseDto?> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var response = await _authService
                   .GetTokenResponseAsync(request.KeycloakUserDto)
                   .ConfigureAwait(false);

            return response;
        }
    }
}