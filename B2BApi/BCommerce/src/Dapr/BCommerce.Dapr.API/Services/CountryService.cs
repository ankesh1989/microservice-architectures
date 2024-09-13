using AutoMapper;
using BCommerce.CommonService.API.Protos;
using BCommerce.Dapr.API.Dtos.Airline;
using BCommerce.Dapr.API.Dtos.Country;

using Grpc.Net.Client;
using Microsoft.Extensions.Caching.Distributed;

namespace BCommerce.Dapr.API.Services
{
    public class CountryService : ICountryService
    {
        private IDistributedCache _cache;
        private readonly HttpClient _httpClient;
        private readonly GrpcChannel _channel;
        private readonly Country.CountryClient _client;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public CountryService(IDistributedCache cache, IConfiguration configuration, IMapper mapper) 
        {
            _cache = cache;
            _httpClient = DaprClient.CreateInvokeHttpClient("commonapi");
            _configuration = configuration;
            _channel =
                GrpcChannel.ForAddress(_configuration.GetValue<string>("CountryBaseAddress"));
            _client = new Country.CountryClient(_channel);
            _mapper = mapper;   
        }

        public async Task<PagedList<GetCountriesDto>> GetAllCountries(PagingDTO pagingModel)
        {
            //var allCountries = await _cache.GetRecordAsync<List<GetCountriesDto>>(StoreKeys.Country.ToString());
            //if (allCountries is null)
            //{
            //    var queryString = CommonHelper.GetQueryParams(new PagingDTO() { PageSize = int.MaxValue });
            //    var allCountriesData = await _httpClient.GetFromJsonAsync<PagedList<GetCountriesDto>>($"/api/{StoreKeys.Country}/GetAll?{queryString}");
            //    if (allCountriesData is not null)
            //    {
            //        allCountries = allCountriesData.Items.ToList();
            //        await _cache.SetRecordAsync(StoreKeys.Country.ToString(), allCountries);
            //    }
            //}
             var pagMdel=new ProtoCountryPagingDTO { PageSize = int.MaxValue };
            
            var data = _client.GetAllCountries(pagMdel);
           var allCountries = _mapper.Map<PagedList<GetCountriesDto>>(data);
            return allCountries != null ? CommonHelper.GetFilterData(allCountries.Items.ToList(), pagingModel) : null;
        }

        public async Task<GetCountriesDto> GetCountryById(int countryId)
        {
            GetCountriesDto country = new GetCountriesDto();
            /*var allCountries = await _cache.GetRecordAsync<List<GetCountriesDto>>(StoreKeys.Country.ToString());
            if (allCountries is not null)
                country = allCountries.FirstOrDefault(c => c.Id.Equals(countryId));
            else
            {*/
            // country = await _httpClient.GetFromJsonAsync<GetCountriesDto>($"/api/{StoreKeys.Country}/GetById/{countryId}");
            var countryReq = new CountryRequest { CountryId = countryId };
            var data = _client.GetCountryById(countryReq);
            country = _mapper.Map<GetCountriesDto>(data);
            //if (country is not null)
            //        await _cache.AddObjectToArrayAsync(StoreKeys.Country.ToString(), country);
            //}
            return country;
        }

        public async Task<string> InsertCountry(CreateCountryDto createCountryDto)
        {
            var mapData = _mapper.Map<ProtoCreateCountryDto>(createCountryDto);
            var data = _client.InsertCountry(mapData);
            if(data?.Data > 0)
                return Constants.SavedCountry;
            return "";
                      //return data?.Data.ToString();
            // HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/Country/Create", createCountryDto);
            /*if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                return Constants.SavedCountry;
            }*/
            // return response.ReasonPhrase;
        }

        public async Task<string> UpdateCountry(EditCountyDto editCountyDto)
        {
            var mapp = _mapper.Map<ProtoEditCountyDto>(editCountyDto);
            var data = _client.UpdateCountry(mapp);
            if (data?.Data > 0)
                return Constants.UpdatedCountry;
            return "";
            /*HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/api/Country/Edit", editCountyDto);
            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                return Constants.UpdatedCountry;
            }
            return response.ReasonPhrase;*/
        }

        public async Task<string> RemoveCountry(int id)
        {
            var req = new RemoveCountryId { Id = id };
            var data = _client.RemoveCountry(req);
            if (data.Data)
                return Constants.RemovedCountry;
            return "";
            /*HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/Country/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                return Constants.RemovedCountry;
            }
            return response.ReasonPhrase;*/
        }
    }
}
