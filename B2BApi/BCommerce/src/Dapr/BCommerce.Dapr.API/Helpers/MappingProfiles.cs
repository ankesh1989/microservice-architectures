using AutoMapper;
using BCommerce.AirlineService.API.Protos;
using BCommerce.CommonService.API.Protos;
using BCommerce.Dapr.API.Dtos.Airline;
using BCommerce.Dapr.API.Dtos.Country;
using BCommerce.Dapr.API.Dtos.Supplier;
using BCommerce.MasterService.API.Protos;

namespace BCommerce.Dapr.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
           
            CreateMap<SupplierDto, GetSupplierDto>().ReverseMap();
            CreateMap<AirlineDto, GetAirlineDto>().ReverseMap();
            CreateMap<CountryDto, GetCountriesDto>().ReverseMap();
            CreateMap<PagedAirlineDTO, PagedList<GetAirlineDto>>().ReverseMap();
            CreateMap<ProtoAirlinePagingDTO, PagingDTO>().ReverseMap();         
            CreateMap<PagedCountryDTO, List<GetCountriesDto>>().ReverseMap();
            CreateMap<PagedCountryDTO, PagedList<GetCountriesDto>>().ReverseMap();
            CreateMap<ProtoCreateCountryDto, CreateCountryDto>().ReverseMap();   
            CreateMap<ProtoEditCountyDto, EditCountyDto>().ReverseMap();
            CreateMap<PagedSupplierDTO, PagedList<GetSupplierDto>>().ReverseMap();
            CreateMap<ProtoSupplierPagingDTO, PagingDTO>().ReverseMap();
        }
    }
}