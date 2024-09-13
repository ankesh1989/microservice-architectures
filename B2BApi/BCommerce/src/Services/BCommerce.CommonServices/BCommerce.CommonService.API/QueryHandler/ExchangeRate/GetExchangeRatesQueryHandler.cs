using BCommerce.CommonService.API.Application.UnitOfWork;
using BCommerce.CommonService.API.DTOs.ExchangeRate;
using BCommerce.CommonService.API.Queries.ExchangeRate;
using BCommerce.Shared.Extensions;
using BCommerce.Shared.Types;

using MediatR;

namespace BCommerce.CommonService.API.QueryHandler.ExchangeRate
{
    public class GetExchangeRatesQueryHandler : IRequestHandler<GetExchangeRatesQuery, PagedList<GetExchangeRateDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetExchangeRatesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PagedList<GetExchangeRateDto>> Handle(GetExchangeRatesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<GetExchangeRateDto> model = _unitOfWork.GetRepository<BCOMExchangeRate>().GetAll().Select(row => new GetExchangeRateDto
            {
                Id = row.Id,
                SupplierId = row.BCOMSupplier.Id,
                SupplierName=row.BCOMSupplier.Name,
                ProductId=row.ProductId,
                ProductName=row.BCOMProduct.Name,
                BaseCurrencyCode = row.BaseCurrencyCode,
                BufferType=row.BufferType,
                BufferValue=row.BufferValue,
                BuyingRate=row.BuyingRate,
                AppliedRate=row.AppliedRate,
                Remarks=row.Remarks,
                SellingRate=row.SellingRate,
                FromDate=row.FromDate,
                ToCurrencyCode=row.ToCurrencyCode,
                Status=row.Status,
                AgentId = row.AgentId,
                AgentName = row.BCOMAgentProfile.Name, // Using navigation property
                CreatedOn = row.CreatedOn,
                ModifiedOn = row.ModifiedOn,
            });

            var queryableList = model.AsQueryable();

            return queryableList.OrderByDynamic(request.PagingDTO.OrderBy, request.PagingDTO.OrderType).ToPagedList(request.PagingDTO.PageNo, request.PagingDTO.PageSize);
        }
    }
}
