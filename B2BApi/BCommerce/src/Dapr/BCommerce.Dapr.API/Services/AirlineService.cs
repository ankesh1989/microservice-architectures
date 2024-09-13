using BCommerce.Dapr.API.Dtos.Airline;
using Microsoft.Extensions.Caching.Distributed;
using Grpc.Net.Client;
using BCommerce.MasterService.API.Protos;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using BCommerce.AirlineService.API.Protos;

namespace BCommerce.Dapr.API.Services
{
    public class AirlineService : IAirlineService
    {
        private IDistributedCache _cache;
        private readonly HttpClient _httpClient;
        private readonly ISupplierService _supplierService;
        private readonly GrpcChannel _channel;
        private readonly Airline.AirlineClient _client;
        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;
        public AirlineService(IDistributedCache cache, ICountryService countryService, IMapper mapper, IConfiguration configuration, ISupplierService supplierService)
        {
            _cache = cache;
            _supplierService = supplierService;
            _httpClient = DaprClient.CreateInvokeHttpClient("airlineapi");

            _configuration = configuration;
            _channel =
                GrpcChannel.ForAddress(_configuration.GetValue<string>("AirlineBaseAddress"));
            _client = new Airline.AirlineClient(_channel);
            _mapper = mapper;

        }

        public async Task<PagedList<GetAirlineDto>> GetAllAirlines(PagingDTO pagingModel)
        {
            /*var allAirlines = await _cache.GetRecordAsync<List<GetAirlineDto>>(StoreKeys.Airline.ToString());
            if (allAirlines is null)
            {
                allAirlines = await GetAllAirlinesFromDatabase();
            }
            return allAirlines != null ? CommonHelper.GetFilterData(allAirlines, pagingModel) : null;*/

            var allAirlines = await GetAllAirlinesFromDatabase();
            return allAirlines != null ? CommonHelper.GetFilterData(allAirlines, pagingModel) : null;
 
        }

        public async Task<GetAirlineDto> GetAirlineById(int airlineId)
        {
    
            GetAirlineDto airlineData = new GetAirlineDto();
            //var allAirlines = await _cache.GetRecordAsync<List<GetAirlineDto>>(StoreKeys.Airline.ToString());
            //if (allAirlines is not null)
            //    airlineData = allAirlines.FirstOrDefault(c => c.Id.Equals(airlineId));
            //else
            //{
            // airlineData = await _httpClient.GetFromJsonAsync<GetAirlineDto>($"/api/{StoreKeys.Airline}/GetById/{airlineId}");
            var airlineReq= new AirlineRequest { AirlineId = airlineId };
            var data =  _client.GetAirlineById(airlineReq);
            airlineData = _mapper.Map<GetAirlineDto>(data);
            if (airlineData is not null)
            {
                if (airlineData.SupplierId > 0)
                {
                    var supplier = await _supplierService.GetSupplierById(airlineData.SupplierId);
                    if (supplier is not null)
                    {
                        airlineData.SupplierName = supplier.Name;
                        airlineData.SupplierCountryId = supplier.CountryId;
                        airlineData.SupplierCountryName = supplier.CountryName;
                    }
                }
               // allAirlines = await GetAllAirlinesFromDatabase();
            }
            return airlineData;
        }

        private async Task<List<GetAirlineDto>> GetAllAirlinesFromDatabase()
        {
            List<GetAirlineDto> allAirlines = new();
          //  var queryString = CommonHelper.GetQueryParams(new PagingDTO() { PageSize = int.MaxValue });
            var protoReq = new ProtoAirlinePagingDTO { PageSize = int.MaxValue };
     
            // var allAirlinesData = await _httpClient.GetFromJsonAsync<PagedList<GetAirlineDto>>($"/api/{StoreKeys.Airline}/GetAll?{queryString}");
            var data = _client.GetAllAirlines(protoReq);
            var allAirlinesData = _mapper.Map<PagedList<GetAirlineDto>>(data);
            if (allAirlinesData is not null)
            {
                allAirlines = allAirlinesData.Items.ToList();
                //foreach (var airline in allAirlines.Where(x => x.SupplierId > 0))
                //{
                //    var supplier = await _supplierService.GetSupplierById(airline.SupplierId);
                //    if (supplier is not null)
                //    {
                //        airline.SupplierName = supplier.Name;
                //        airline.SupplierCountryId = supplier.CountryId;
                //        airline.SupplierCountryName = supplier.CountryName;
                //    }
                //}
               // await _cache.SetRecordAsync(StoreKeys.Airline.ToString(), allAirlines);
            }
            return allAirlines;
        }
    }
}
