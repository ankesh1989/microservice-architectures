using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace BCommerce.Shared.Middlewares
{
    public class KeycloakAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public KeycloakAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authResult = await context.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);

            if (authResult.Succeeded && authResult.Principal != null)
            {
                context.User = authResult.Principal;
            }

            if (!authResult.Succeeded || !context.User.Identity.IsAuthenticated)
            {
                // Handle unauthorized request
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            // Check Keycloak roles or claims for authorization
            // Extract claims or roles from authResult.Principal and perform authorization checks

            // Example: Check for the "admin" role
            if (!context.User.IsInRole("admin"))
            {
                // Handle forbidden request (user doesn't have required role)
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }

            // Authorized - pass the request to the next middleware or controller
            await _next(context);
        }
    }

}
