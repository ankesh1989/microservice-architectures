using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Infrastructure.Entities;

namespace BCommerce.KeyCloak.API.Services
{ 
    public interface IClientService
    {
        Task<bool> CreateClient(BusinessDto business);
        Task<bool> UpdateClient(UpdateBusinessDto business);
        Task<bool> DeleteClient(string clientId);
        Task<List<Clients>> GetAll();
    }
}
