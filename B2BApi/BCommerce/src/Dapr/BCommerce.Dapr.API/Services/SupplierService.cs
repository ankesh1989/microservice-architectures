using BCommerce.Dapr.API.Dtos.Supplier;
using Grpc.Net.Client;
using Microsoft.Extensions.Caching.Distributed;
using BCommerce.MasterService.API.Protos;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace BCommerce.Dapr.API.Services
{
    public class SupplierService : ISupplierService
    {
        private IDistributedCache _cache;
        private readonly HttpClient _httpClient;
        private readonly ICountryService _countryService;
        private readonly GrpcChannel _channel;
        private readonly Supplier.SupplierClient _client;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public SupplierService(IDistributedCache cache, ICountryService countryService, IConfiguration configuration, IMapper mapper)
        {
            _cache = cache;
            _countryService = countryService;
            _configuration = configuration;
       
            _httpClient = DaprClient.CreateInvokeHttpClient("masterapi");
            //_channel =
            //    GrpcChannel.ForAddress("https://localhost:8026");
            _channel =
                GrpcChannel.ForAddress(_configuration.GetValue<string>("MasterBaseAddress"));
            _client = new Supplier.SupplierClient(_channel);
            _mapper = mapper;
        }

        public async Task<PagedList<GetSupplierDto>> GetAllSuppliers(PagingDTO pagingModel)
        {
            /*var allSuppliers = await _cache.GetRecordAsync<List<GetSupplierDto>>(StoreKeys.Supplier.ToString());
            if (allSuppliers is null)
            {
                allSuppliers = await GetAllSuppliersFromDatabase();
            }
            return allSuppliers != null ? CommonHelper.GetFilterData(allSuppliers, pagingModel) : null;*/
            var allSuppliers = await GetAllSuppliersFromDatabase();
            return allSuppliers != null ? CommonHelper.GetFilterData(allSuppliers, pagingModel) : null;
        }

        public async Task<GetSupplierDto> GetSupplierById(int supplierId) 
        {
            GetSupplierDto supplierData = new GetSupplierDto();
            //var allSuppliers = await _cache.GetRecordAsync<List<GetSupplierDto>>(StoreKeys.Supplier.ToString());
            //if (allSuppliers is not null)
            //    supplierData = allSuppliers.FirstOrDefault(c => c.Id.Equals(supplierId));
            //else
            //{
                //supplierData = await _httpClient.GetFromJsonAsync<GetSupplierDto>($"/api/{StoreKeys.Supplier}/GetById/{supplierId}");
                var request = new SupplierRequest{ SupplierId = supplierId };
                var supplier= _client.GetSupplierById(request);
                supplierData = _mapper.Map<GetSupplierDto>(supplier);
                if (supplierData is not null)
                {
                    var country = await _countryService.GetCountryById(supplierData.CountryId);
                    if (country is not null)
                    {
                        supplierData.CountryName = country.Name;
                    }
                    //await _cache.AddObjectToArrayAsync(StoreKeys.Supplier.ToString(), supplierData);
                    //allSuppliers = await GetAllSuppliersFromDatabase();
                }
            //}
            return supplierData;
        }

        private async Task<List<GetSupplierDto>> GetAllSuppliersFromDatabase()
        {
            List<GetSupplierDto> allSuppliers = new();
            /* var queryString = CommonHelper.GetQueryParams(new PagingDTO() { PageSize = int.MaxValue });
             var allSuppliersData = await _httpClient.GetFromJsonAsync<PagedList<GetSupplierDto>>($"/api/{StoreKeys.Supplier}/GetAll?{queryString}");
             if (allSuppliersData is not null)
             {
                 allSuppliers = allSuppliersData.Items.ToList();
                 await _cache.SetRecordAsync(StoreKeys.Supplier.ToString(), allSuppliers);
             }
             return allSuppliers;*/
            var protoReq = new ProtoSupplierPagingDTO { PageSize = int.MaxValue };
            var data = _client.GetAllSuppliers(protoReq);
            var allSuppliersData = _mapper.Map<PagedList<GetSupplierDto>>(data);
            if (allSuppliersData is not null)
            {
                allSuppliers = allSuppliersData.Items.ToList();
            }
            return allSuppliers;
        }

        //public Task<PagedList<GetSupplierDto>> GetAllSuppliers(PagingDTO pagingModel)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<GetSupplierDto> GetSupplierById(int supplierId)
        //{
        //    throw new NotImplementedException();
        //}
    }

        
}