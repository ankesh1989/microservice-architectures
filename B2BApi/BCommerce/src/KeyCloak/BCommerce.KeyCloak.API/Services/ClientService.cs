using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Infrastructure.Entities;
using BCommerce.KeyCloak.Repository;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace BCommerce.KeyCloak.API.Services
{
    public class ClientService : IClientService
    {
        private readonly string BaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IClientRepository  _clientRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClientService(IHttpClientFactory httpClientFactory, 
            IHttpContextAccessor httpContextAccessor,IClientRepository clientRepository, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _clientRepository = clientRepository;
            _configuration = configuration;
            BaseUrl = _configuration.GetValue<string>("KeyCloak:BaseUrl");
        }

        public async Task<bool> CreateClient(BusinessDto business)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                
                var json = JsonConvert.SerializeObject(business);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient
                    .PostAsync($"{BaseUrl}/admin/realms/Realm-B/clients", content)
                    .ConfigureAwait(false);

                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if(response.IsSuccessStatusCode)
                {
                    var clientInfo = await httpClient
                                      .GetAsync($"{BaseUrl}/admin/realms/Realm-B/clients?clientId=" + business.clientId)
                                      .ConfigureAwait(false);

                    if (clientInfo.IsSuccessStatusCode)
                    {
                        var clientJson = await clientInfo.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var clientRes  = JsonConvert.DeserializeObject<GetClientDto[]>(
                                          clientJson);

                        if(clientRes.Length>0)
                        {
                            var clientResponse  = clientRes.FirstOrDefault();
                            var client = new Clients()
                            {
                                ClientGuid = clientResponse?.id,
                                ClientId = clientResponse?.clientId,
                                ClientSecret = clientResponse.secret.IsNullOrEmpty()?"": clientResponse.secret,
                                Name = clientResponse?.name,
                                Description = clientResponse?.description,
                                RootUrl = clientResponse?.rootUrl,
                                AdminUrl = clientResponse?.adminUrl,
                                BaseUrl = clientResponse?.baseUrl
                            };
                            _clientRepository.Create(client);
                        }
                    }
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> UpdateClient(UpdateBusinessDto business)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var json = JsonConvert.SerializeObject(business);
                var updatedContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient
                    .PutAsync($"{BaseUrl}/admin/realms/Realm-B/clients/{business.id}", updatedContent)
                    .ConfigureAwait(false);

                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var clientInfo = await httpClient
                                      .GetAsync($"{BaseUrl}/admin/realms/Realm-B/clients?clientId=" + business.clientId)
                                      .ConfigureAwait(false);

                    if (clientInfo.IsSuccessStatusCode)
                    {
                        var clientJson = await clientInfo.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var clientRes = JsonConvert.DeserializeObject<GetClientDto[]>(
                                          clientJson);

                        if (clientRes.Length > 0)
                        {
                            var clientResponse = clientRes.FirstOrDefault();
                            var client = _clientRepository.FindByCondition(c => c.ClientGuid.Equals(clientResponse.id)).FirstOrDefault();
                            client.Name = clientResponse?.name;
                            client.Description = clientResponse?.description;
                            client.RootUrl = clientResponse?.rootUrl;
                            client.AdminUrl = clientResponse?.adminUrl;
                            client.BaseUrl = clientResponse?.baseUrl;
                            client.ClientId = clientResponse?.clientId;
                            _clientRepository.Update(client);
                        }
                    }
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> DeleteClient(string clientId)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient
                    .DeleteAsync($"{BaseUrl}/admin/realms/Realm-B/clients/{clientId}")
                    .ConfigureAwait(false);

                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Clients client = _clientRepository.FindByCondition(c => c.ClientGuid.Equals(clientId)).FirstOrDefault();
                    _clientRepository.Delete(client);
                    return true;
                }
            }
            return false;
        }

        public async Task<List<Clients>> GetAll()
        {
            return _clientRepository.FindAll().ToList();
        }
    }
}
