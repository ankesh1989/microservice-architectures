using Microsoft.AspNetCore.Mvc;

namespace BCommerce.Dapr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("GetAllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers([FromQuery] PagingDTO model)
        {
            return Ok(await _supplierService.GetAllSuppliers(model));
        }

        [HttpGet("GetSupplierById/{supplierId}")]
        public async Task<IActionResult> GetSupplierById(int supplierId)
        {
            try
            {
                var result = await _supplierService.GetSupplierById(supplierId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}