using BCommerce.Dapr.API.Dtos.Supplier;

namespace BCommerce.Dapr.API.Services
{
    public interface ISupplierService
    {
        Task<PagedList<GetSupplierDto>> GetAllSuppliers(PagingDTO pagingModel);
        Task<GetSupplierDto> GetSupplierById(int supplierId);
    }
}