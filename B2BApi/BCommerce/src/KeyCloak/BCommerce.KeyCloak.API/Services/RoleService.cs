using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Infrastructure.Entities;
using BCommerce.KeyCloak.API.Repository;
using Newtonsoft.Json;
using System.Text;

namespace BCommerce.KeyCloak.API.Services
{
    public class RoleService : IRoleService
    {
        private readonly string BaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RoleService(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            BaseUrl = _configuration.GetValue<string>("KeyCloak:BaseUrl");
        }

        public async Task<bool> CreateRole(CreateRoleDto createRoleDto)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var realmRole = new
                {
                    name = createRoleDto.RoleName,
                    description = createRoleDto.RoleDescription
                };

                var json = JsonConvert.SerializeObject(realmRole);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient
                    .PostAsync($"{BaseUrl}/admin/realms/Realm-B/roles", content)
                    .ConfigureAwait(false);

                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var roleResponse = await httpClient
                   .GetAsync($"{BaseUrl}/admin/realms/Realm-B/roles")
                   .ConfigureAwait(false);
                    
                    var roleJson = await roleResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var roleList = JsonConvert.DeserializeObject<GetRoleDto[]>(roleJson);

                    if (roleList.Length > 0)
                    {
                        var keyCloakRoleId = roleList.Where(x=>x.name==createRoleDto.RoleName).FirstOrDefault().id;
                        var role = new Roles()
                        {
                            RoleId = keyCloakRoleId,
                            RoleName = createRoleDto.RoleName,
                            RoleDescription = createRoleDto.RoleDescription
                        };
                        _roleRepository.Create(role);
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<bool> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var json = JsonConvert.SerializeObject(updateRoleDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient
                    .PutAsync($"{BaseUrl}/admin/realms/Realm-B/roles-by-id/{updateRoleDto.RoleId}", content)
                    .ConfigureAwait(false);

                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Roles role = _roleRepository.FindByCondition(c => c.RoleId == updateRoleDto.RoleId).FirstOrDefault();
                    role.RoleDescription = updateRoleDto.RoleDescription;
                    role.RoleName = updateRoleDto.RoleName;
                    _roleRepository.Update(role);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteRole(string roleId)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient
                    .DeleteAsync($"{BaseUrl}/admin/realms/Realm-B/roles-by-id/{roleId}")
                    .ConfigureAwait(false);

                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Roles role = _roleRepository.FindByCondition(c => c.RoleId == roleId).FirstOrDefault();
                    _roleRepository.Delete(role);
                    return true;
                }
            }
            return false;
        }

        public async Task<List<Roles>> GetAll()
        {
          return _roleRepository.FindAll().ToList();
        }
    }
}