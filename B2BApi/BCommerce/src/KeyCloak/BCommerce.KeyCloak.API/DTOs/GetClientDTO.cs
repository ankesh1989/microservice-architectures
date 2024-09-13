using Newtonsoft.Json;

namespace BCommerce.KeyCloak.API.DTOs
{
    public class GetClientDto
    {
        public string id { get; set; }
        public string clientId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string rootUrl { get; set; }
        public string adminUrl { get; set; }
        public string baseUrl { get; set; }
        public bool surrogateAuthRequired { get; set; }
        public bool enabled { get; set; }
        public bool alwaysDisplayInConsole { get; set; }
        public string clientAuthenticatorType { get; set; }
        public string secret { get; set; }
        public List<string> redirectUris { get; set; }
        public List<string> webOrigins { get; set; }
        public int notBefore { get; set; }
        public bool bearerOnly { get; set; }
        public bool consentRequired { get; set; }
        public bool standardFlowEnabled { get; set; }
        public bool implicitFlowEnabled { get; set; }
        public bool directAccessGrantsEnabled { get; set; }
        public bool serviceAccountsEnabled { get; set; }
        public bool publicClient { get; set; }
        public bool frontchannelLogout { get; set; }
        public string protocol { get; set; }
        public Attributes attributes { get; set; }
        public AuthenticationFlowBindingOverrides authenticationFlowBindingOverrides { get; set; }
        public bool fullScopeAllowed { get; set; }
        public int nodeReRegistrationTimeout { get; set; }
        public List<string> defaultClientScopes { get; set; }
        public List<string> optionalClientScopes { get; set; }
        public Access access { get; set; }
    }
    public class AuthenticationFlowBindingOverrides
    {
    }
    public class Attributes
    {
        [JsonProperty("oidc.ciba.grant.enabled")]
        public string oidccibagrantenabled { get; set; }

        [JsonProperty("oauth2.device.authorization.grant.enabled")]
        public string oauth2deviceauthorizationgrantenabled { get; set; }

        [JsonProperty("client.secret.creation.time")]
        public string clientsecretcreationtime { get; set; }

        [JsonProperty("backchannel.logout.session.required")]
        public string backchannellogoutsessionrequired { get; set; }

        [JsonProperty("backchannel.logout.revoke.offline.tokens")]
        public string backchannellogoutrevokeofflinetokens { get; set; }
    }
    public class Access
    {
        public bool view { get; set; }
        public bool configure { get; set; }
        public bool manage { get; set; }
    }
}