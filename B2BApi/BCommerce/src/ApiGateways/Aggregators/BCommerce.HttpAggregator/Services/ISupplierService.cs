using BCommerce.HttpAggregator.Models;

namespace BCommerce.HttpAggregator.Services
{
    public interface ISupplierService
    {
        Task GetUserById(int userId);
        Task CreateSupplier(CreateSupplierDto supplier);

    }
}
