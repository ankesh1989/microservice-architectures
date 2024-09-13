using AutoMapper;
using BCommerce.MasterService.API.DTOs.AgentConfig;
using BCommerce.MasterService.API.DTOs.AgentDoc;
using BCommerce.MasterService.API.DTOs.AgentFinance;
using BCommerce.MasterService.API.DTOs.AgentFOP;
using BCommerce.MasterService.API.DTOs.AgentPg;
using BCommerce.MasterService.API.DTOs.AgentProfile;
using BCommerce.MasterService.API.DTOs.AgentsPOC;
using BCommerce.MasterService.API.DTOs.AgentSupplier;
using BCommerce.MasterService.API.DTOs.Location;
using BCommerce.MasterService.API.DTOs.Product;
using BCommerce.MasterService.API.DTOs.SupplierConfig;
using BCommerce.MasterService.API.DTOs.SupplierDocument;
using BCommerce.MasterService.API.Protos;
using BCommerce.Shared.Types;

namespace BCommerce.MasterService.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateSupplierDto, BCOMSupplier>().ReverseMap();
            CreateMap<EditSupplierDto, BCOMSupplier>().ReverseMap();
            CreateMap<GetSuppliersDto, BCOMSupplier>().ReverseMap();

            CreateMap<CreateSupplierConfigDto, BCOMSupplierConfig>().ReverseMap();
            CreateMap<EditSupplierConfigDto, BCOMSupplierConfig>().ReverseMap();
            CreateMap<GetSupplierConfigsDto, BCOMSupplierConfig>().ReverseMap();

            CreateMap<CreateSupplierDocumentDto, BCOMSupplierDocument>().ReverseMap();
            CreateMap<EditSupplierDocumentDto, BCOMSupplierDocument>().ReverseMap();
            CreateMap<GetSupplierDocumentsDto, BCOMSupplierDocument>().ReverseMap();

            CreateMap<CreateAgentFOPDto, BCOMAgentFOP>().ReverseMap();
            CreateMap<EditAgentFOPDto, BCOMAgentFOP>().ReverseMap();
            CreateMap<GetAgentFOPsDto, BCOMAgentFOP>().ReverseMap();

            CreateMap<CreateAgentProfileDto, BCOMAgentProfile>().ReverseMap();
            CreateMap<EditAgentProfileDto, BCOMAgentProfile>().ReverseMap();
            CreateMap<GetAgentProfilesDto, BCOMAgentProfile>().ReverseMap();

            CreateMap<CreateAgentPOCDto, BCOMAgentPOC>().ReverseMap();
            CreateMap<EditAgentPOCDto, BCOMAgentPOC>().ReverseMap();
            CreateMap<GetAgentPOCsDto, BCOMAgentPOC>().ReverseMap();

            CreateMap<CreateAgentFinanceDto, BCOMAgentFinance>().ReverseMap();
            CreateMap<EditAgentFinanceDto, BCOMAgentFinance>().ReverseMap();
            CreateMap<GetAgentFinancesDto, BCOMAgentFinance>().ReverseMap();

            CreateMap<CreateAgentDocDto, BCOMAgentDoc>().ReverseMap();
            CreateMap<EditAgentDocDto, BCOMAgentDoc>().ReverseMap();
            CreateMap<GetAgentDocsDto, BCOMAgentDoc>().ReverseMap();

            CreateMap<CreateAgentConfigDto, BCOMAgentConfig>().ReverseMap();
            CreateMap<EditAgentConfigDto, BCOMAgentConfig>().ReverseMap();
            CreateMap<GetAgentConfigsDto, BCOMAgentConfig>().ReverseMap();

            CreateMap<CreateAgentPgDto, BCOMAgentPg>().ReverseMap();
            CreateMap<EditAgentPgDto, BCOMAgentPg>().ReverseMap();
            CreateMap<GetAgentPgsDto, BCOMAgentPg>().ReverseMap();

            CreateMap<CreateAgentSupplierDto, BCOMAgentSupplier>().ReverseMap();
            CreateMap<EditAgentSupplierDto, BCOMAgentSupplier>().ReverseMap();
            CreateMap<GetAgentSuppliersDto, BCOMAgentSupplier>().ReverseMap();

            CreateMap<CreateLocationDto, BCOMLocation>().ReverseMap();
            CreateMap<EditLocationDto, BCOMLocation>().ReverseMap();
            CreateMap<GetlocationsDto, BCOMLocation>().ReverseMap();

            CreateMap<CreateProductDto, BCOMProduct>().ReverseMap();
            CreateMap<EditProductDto, BCOMProduct>().ReverseMap();
            CreateMap<GetProductsDto, BCOMProduct>().ReverseMap();

            CreateMap<SupplierDto, BCOMSupplier>().ReverseMap();
            CreateMap<SupplierDto, GetSuppliersDto>().ReverseMap();
            CreateMap<PagedSupplierDTO, PagedList<GetSuppliersDto>>().ReverseMap();

        }
    }
}