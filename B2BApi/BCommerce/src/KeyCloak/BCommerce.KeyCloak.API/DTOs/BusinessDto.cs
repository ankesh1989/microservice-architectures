using Newtonsoft.Json;

namespace BCommerce.KeyCloak.API.DTOs
{
    public class BusinessDto
    {
        public string protocol { get; set; }
        public string clientId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool publicClient { get; set; }
        public bool authorizationServicesEnabled { get; set; }
        public bool serviceAccountsEnabled { get; set; }
        public bool implicitFlowEnabled { get; set; }
        public bool directAccessGrantsEnabled { get; set; }
        public bool standardFlowEnabled { get; set; }
        public bool frontchannelLogout { get; set; }
        public BusinesAttributes attributes { get; set; }
        public bool alwaysDisplayInConsole { get; set; }
        public string rootUrl { get; set; }
        public string baseUrl { get; set; }
    }

    public class BusinesAttributes
    {
        public string saml_idp_initiated_sso_url_name { get; set; }

        [JsonProperty("oauth2.device.authorization.grant.enabled")]
        public bool oauth2deviceauthorizationgrantenabled { get; set; }

        [JsonProperty("oidc.ciba.grant.enabled")]
        public bool oidccibagrantenabled { get; set; }
    }
}
