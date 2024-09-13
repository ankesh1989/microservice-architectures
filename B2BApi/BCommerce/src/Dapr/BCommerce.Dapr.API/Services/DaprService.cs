using BCommerce.Dapr.API.Utilities;
using Microsoft.Extensions.Caching.Distributed;

namespace BCommerce.Dapr.API.Services
{
    public class DaprService<T> : IDaprService<T> where T : class
    {
        protected readonly IDistributedCache _cache;
        protected readonly HttpClient _httpClient;

        public DaprService(IDistributedCache cache, string apiName)
        {
            _cache = cache;
            _httpClient = DaprClient.CreateInvokeHttpClient(apiName);
        }
        //public DaprService(IDistributedCache cache, IDaprHttpClientFactory httpClientFactory, string apiName)
        //{
        //    _cache = cache;
        //    _httpClient = httpClientFactory.CreateHttpClient(apiName); //DaprClient.CreateInvokeHttpClient(apiName);
        //}

        public virtual async Task<List<T>> GetAll(string controllerName)
        {
            var data = await _cache.GetRecordAsync<List<T>>(controllerName);
            if (data is null)
            {
                var queryString = CommonHelper.GetQueryParams(new PagingDTO() { PageSize = int.MaxValue });
                var getData = await _httpClient.GetFromJsonAsync<PagedList<T>>($"/api/{controllerName}/GetAll?{queryString}");
                if (getData is not null)
                {
                    data = getData.Items.ToList();
                    await _cache.SetRecordAsync(controllerName, data);
                }
            }
            return data;
        }

        public virtual async Task<T> GetById(int id, string controllerName)
        {
            //T country = new();
            var allCountries = await _cache.GetRecordAsync<List<T>>(controllerName);
            if (allCountries is not null)
                return allCountries.FirstOrDefault(c => c.GetType().GetProperty("Id")?.GetValue(c)?.Equals(id) ?? false);
            else
                return await _httpClient.GetFromJsonAsync<T>($"/api/{controllerName}/GetById/{id}");
        }

        //public abstract Task<List<T>> GetAll(string controllerName);
        //public abstract Task<T> GetById(int id, string controllerName);

        //public async Task<List<GetSupplierDto>> GetAllSuppliers()
        //{
        //    var allSuppliers = await _cache.GetRecordAsync<List<GetSupplierDto>>(StoreKeys.Supplier.ToString());
        //    if (allSuppliers is null)
        //    {
        //        var queryString = CommonHelper.GetQueryParams(new PagingDTO() { PageSize = int.MaxValue });
        //        var allSuppliersData = await _httpClient.GetFromJsonAsync<PagedList<GetSupplierDto>>($"/api/Supplier/GetAll?{queryString}");
        //        if (allSuppliersData is not null)
        //        {
        //            allSuppliers = allSuppliersData.Items.ToList();
        //            foreach (var supplier in allSuppliers.Where(x => x.CountryId > 0))
        //            {
        //                var country = await _countryService.GetCountryById(supplier.CountryId);
        //                if (country is not null)
        //                {
        //                    supplier.CountryName = country.Name;
        //                }
        //            }
        //            await _cache.SetRecordAsync(StoreKeys.Supplier.ToString(), allSuppliers);
        //        }
        //    }
        //    return allSuppliers;
        //}

        //public async Task<GetSupplierDto> GetSupplierById(int supplierId)
        //{
        //    GetSupplierDto supplierData = new GetSupplierDto();
        //    var allSuppliers = await _cache.GetRecordAsync<List<GetSupplierDto>>(StoreKeys.Supplier.ToString());
        //    if (allSuppliers is not null)
        //        supplierData = allSuppliers.FirstOrDefault(c => c.Id.Equals(supplierId));
        //    else
        //    {
        //        supplierData = await _httpClient.GetFromJsonAsync<GetSupplierDto>($"/api/Supplier/GetById/{supplierId}");
        //        if(supplierData is not null)
        //        {
        //            var country = await _countryService.GetCountryById(supplierData.CountryId);
        //            if (country is not null)
        //            {
        //                supplierData.CountryName = country.Name;
        //            }
        //        }
        //    }
        //    return supplierData;
        //}
    }
}