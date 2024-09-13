using BCommerce.Dapr.API.Dtos.Country;

namespace BCommerce.Dapr.API
{
    public static class ProgramExtensions
    {
        public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
        {
            //builder.Services.AddSingleton<IDaprHttpClientFactory, DaprHttpClientFactory>();
            //builder.Services.AddScoped(typeof(DaprService<>));
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<ISupplierService, SupplierService>();
            builder.Services.AddScoped<IAirlineService,BCommerce.Dapr.API.Services.AirlineService>();
        }
    }
}