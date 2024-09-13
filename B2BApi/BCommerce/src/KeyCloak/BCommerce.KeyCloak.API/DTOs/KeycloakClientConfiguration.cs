﻿namespace BCommerce.KeyCloak.API.DTOs
{
    public class KeycloakClientConfiguration
    {
        public string BaseUrl { get; set; }
        public string Realm { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
