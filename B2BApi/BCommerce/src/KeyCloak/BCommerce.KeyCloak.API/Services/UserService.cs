using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Infrastructure.Entities;
using BCommerce.KeyCloak.API.Repository;
using BCommerce.KeyCloak.Repository;
using Newtonsoft.Json;
using System.Text;

namespace BCommerce.KeyCloak.API.Services
{
    public class UserService : IUserService
    {
        private readonly string BaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository; 
        private readonly IRoleRepository _roleRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IRoleRepository roleRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            BaseUrl = _configuration.GetValue<string>("KeyCloak:BaseUrl");
        }

        public async Task<bool> CreateUser(CreateUserDto createUserDto)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var accessToken = string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString())
                    ? null : _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var user = new
                {
                    requiredActions = new[] { "SEND_INITIAL_EMAIL" },
                    email = createUserDto.Email,
                    emailVerified = createUserDto.EmailVerified,
                    enabled = createUserDto.Enabled,
                    firstName = createUserDto.FirstName,
                    groups = createUserDto.Groups,
                    lastName = createUserDto.LastName,
                    username = createUserDto.UserName,
                };

                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient
                    .PostAsync($"{BaseUrl}/admin/realms/Realm-B/users", content)
                    .ConfigureAwait(false);

                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var userDetail = await httpClient
                                      .GetAsync($"{BaseUrl}/admin/realms/Realm-B/users?username=" + user.username)
                                      .ConfigureAwait(false);

                    if (userDetail.IsSuccessStatusCode)
                    {
                        var userData = await userDetail.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var userInfo = JsonConvert.DeserializeObject<UserDetailDto[]>(
                                          userData);

                        if (userInfo.Count() > 0)
                        {
                            var userPass = new
                            {
                                type = "password",
                                temporary = false,
                                value = createUserDto.Password
                            };

                            var userCredJson = JsonConvert.SerializeObject(userPass);
                            var credContent = new StringContent(userCredJson, Encoding.UTF8, "application/json");

                            var userResponse = await httpClient
                                         .PutAsync($"{BaseUrl}/admin/realms/Realm-B/users/{userInfo.FirstOrDefault().id}/reset-password", credContent)
                                         .ConfigureAwait(false);

                            if (userResponse.IsSuccessStatusCode)
                            {
                                var roleData = _roleRepository.FindByCondition(x => x.RoleId == createUserDto.RoleId).FirstOrDefault();
                                if (roleData != null)
                                {
                                    List<object> userRoleMappingArray = new List<object>();

                                    var userRoleMapping = new
                                    {
                                        id = roleData.RoleId,
                                        name = roleData.RoleName,
                                        description = roleData.RoleDescription,
                                        composite = false,
                                        clientRole = false
                                    };
                                    userRoleMappingArray.Add(userRoleMapping);

                                    var userRoleMappingJson = JsonConvert.SerializeObject(userRoleMappingArray);
                                    var userRoleMappingContent = new StringContent(userRoleMappingJson, Encoding.UTF8, "application/json");

                                    var userRoleResponse = await httpClient
                                            .PostAsync($"{BaseUrl}/admin/realms/Realm-B/users/{userInfo.FirstOrDefault().id}/role-mappings/realm", userRoleMappingContent)
                                            .ConfigureAwait(false);
                                }
                                var userDto = new Users()
                                {
                                    FirstName = createUserDto.FirstName,
                                    LastName = createUserDto.LastName,
                                    Email = createUserDto.Email,
                                    Password = createUserDto.Password,
                                    UserName = createUserDto.FirstName,
                                    RoleId = createUserDto.RoleId,
                                    UserId = userInfo.FirstOrDefault().id
                                };
                                _userRepository.Create(userDto);
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Console.WriteLine($"Error creating user: {errorResponse}");
                    return false;
                }
            }
        }

        public async Task<bool> UpdateUser(UpdateUserDto updateUserDto)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var accessToken = string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString())
                    ? null : _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var json = JsonConvert.SerializeObject(updateUserDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient
                    .PutAsync($"{BaseUrl}/admin/realms/Realm-B/users/{updateUserDto.UserId}", content)
                    .ConfigureAwait(false);

                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Users currentuser = _userRepository.FindByCondition(u => u.UserId == updateUserDto.UserId).FirstOrDefault();
                    if (currentuser != null)
                    {
                        currentuser.FirstName = updateUserDto.FirstName;
                        currentuser.LastName = updateUserDto.LastName;
                        currentuser.Email = updateUserDto.Email;
                        currentuser.Enabled = updateUserDto.Enabled;
                        _userRepository.Update(currentuser);
                    }
                }
                return true;
            }
        }

        public async Task<bool> DeleteUser(string userId)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var accessToken = string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString())
                   ? null : _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient
                    .DeleteAsync($"{BaseUrl}/admin/realms/Realm-B/users/{userId}")
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var user = _userRepository.FindByCondition(u => u.UserId == userId).FirstOrDefault();
                    _userRepository.Delete(user);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> ResetUserPassword(ResetPasswordDto resetPasswordDto)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var accessToken = string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString())
                   ? null : _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var resetPasswordModel = new
                {
                    value = resetPasswordDto.Value,
                    type = resetPasswordDto.Type,
                    temporary = resetPasswordDto.Temporary
                };

                var json = JsonConvert.SerializeObject(resetPasswordModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient
                    .PutAsync($"{BaseUrl}/admin/realms/Realm-B/users/{resetPasswordDto.UserId}/reset-password", content)
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    Users currentuser = _userRepository.FindByCondition(u => u.UserId == resetPasswordDto.UserId).FirstOrDefault();
                    if (currentuser != null)
                    {
                        currentuser.Password = resetPasswordDto.Value;
                        _userRepository.Update(currentuser);
                    }
                    return true;
                }
            }
            return false;
        }

        public async Task<List<Users>> GetAll()
        {
            return _userRepository.FindAll().ToList();
        }
    }
}