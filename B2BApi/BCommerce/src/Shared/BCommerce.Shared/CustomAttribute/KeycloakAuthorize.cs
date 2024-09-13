using Microsoft.AspNetCore.Mvc.Filters;

namespace BCommerce.Shared.CustomAttribute
{
    public class KeycloakAuthorize : Attribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User != null && context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(Roles))
                {
                    var requiredRoles = Roles.Split(',').Select(r => r.Trim());
                    var realmAccessClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "realm_access");

                    if (realmAccessClaim != null)
                    {
                        var realmAccess = realmAccessClaim.Value;

                        // Deserialize the realm_access claim to extract roles
                        var userRoles = Newtonsoft.Json.JsonConvert.DeserializeObject<RealmAccess>(realmAccess)?.roles;

                        if (userRoles != null && requiredRoles.Any(r => userRoles.Contains(r)))
                        {
                            // User has at least one of the required roles
                            return; // Authorized
                        }
                    }
                }
                else
                    return; // Authorized
            }
            // Unauthorized logic for users without the required roles
            context.Result = new Microsoft.AspNetCore.Mvc.StatusCodeResult(401);
        }
    }

    public class RealmAccess
    {
        public List<string> roles { get; set; }
    }

}
