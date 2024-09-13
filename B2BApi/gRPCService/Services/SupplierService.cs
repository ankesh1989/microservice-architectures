using Grpc.Core;

using ProductOfferService = ProductOfferGrpcService.Protos.ProductOfferService;


namespace gRPCService.Services
{
    public class SupplierService: Supplier.SupplierBase
    {
        private readonly ILogger<SupplierService> _logger;
        public SupplierService(ILogger<SupplierService> logger)
        {
            _logger = logger;
        }
    }
}
