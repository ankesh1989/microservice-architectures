using BCommerce.CommonService.API.Queries.City;
using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Services;
using MediatR;

namespace BCommerce.CommonService.API.QueryHandler.City
{
    public class GetRefreshTokenHandler : IRequestHandler<GetRefreshTokenQuery, KeycloakTokenResponseDto?>
    {
        private readonly IAuthService _authService;

        public GetRefreshTokenHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<KeycloakTokenResponseDto?> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var response = await _authService
                    .GetRefreshTokenResponseAsync(request.RefreshTokenDto)
                    .ConfigureAwait(false);

            return response;
        }
    }
}