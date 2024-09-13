using AutoMapper;
using BCommerce.CommonService.API.Protos;
using BCommerce.CommonService.API.Queries.Country;
using BCommerce.CommonService.API.QueryHandler.Country;
using BCommerce.Shared.ValueObjects;
using Grpc.Core;
using MassTransit.Mediator;
using MediatR;

namespace BCommerce.CommonService.API.ProtoServices
{
    public class CountryServices: Country.CountryBase
    {
        private readonly IRequestHandler<GetCountryByIdQuery, GetCountriesDto> _requestHandler;
        private readonly IMapper _mapper;
        private readonly MediatR.IMediator _mediator;
        public CountryServices(IMapper mapper, MediatR.IMediator mediator, IRequestHandler<GetCountryByIdQuery, GetCountriesDto> requestHandler)
        {
            _requestHandler = requestHandler;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async override Task<CountryDto> GetCountryById(CountryRequest obj, ServerCallContext context)
        {
            var country = await _mediator.Send(new GetCountryByIdQuery(obj.CountryId));

            var countryDetail = _mapper.Map<CountryDto>(country);

            return countryDetail;
        }
        public async override Task<PagedCountryDTO> GetAllCountries(ProtoCountryPagingDTO model, ServerCallContext context)
        {
            var pageProtoModel = new PagingDTO { PageSize = model.PageSize };
            var data = await _mediator.Send(new GetCountriesQuery(pageProtoModel));
            var mappedData = _mapper.Map<PagedCountryDTO>(data);
            return mappedData;
        }

        public async override Task<StringData> InsertCountry(ProtoCreateCountryDto obj, ServerCallContext context)
        {
            var mapp = _mapper.Map<CreateCountryDto>(obj); 
            int countryId = await _mediator.Send(new CreateCountryCommand(mapp));
            var mappedData = new StringData { Data = countryId };
          //  var mappedData = _mapper.Map<StringData>(countryId);
            return mappedData;
        }
     
        public async override Task<StringData> UpdateCountry(ProtoEditCountyDto obj, ServerCallContext context)
        {
            var mapp = _mapper.Map<EditCountyDto>(obj);
            int countryId = await _mediator.Send(new EditCountryCommand(mapp));
            var mappedData = new StringData { Data = countryId };
            return mappedData;
        }

        public async override Task<BoolData> RemoveCountry(RemoveCountryId id, ServerCallContext context)
        {
            bool isDeleted = await _mediator.Send(new DeleteCountryCommand(id.Id));
            var mappedData = new BoolData { Data = isDeleted };
            // var mappedData = _mapper.Map<StringData>(isDeleted);
            return mappedData;
        }


    }
}
