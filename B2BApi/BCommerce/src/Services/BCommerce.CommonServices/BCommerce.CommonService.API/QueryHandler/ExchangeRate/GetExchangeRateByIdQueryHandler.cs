using BCommerce.CommonService.API.Application.UnitOfWork;
using BCommerce.CommonService.API.DTOs.ExchangeRate;
using BCommerce.CommonService.API.Queries.ExchangeRate;
using MediatR;

namespace BCommerce.CommonService.API.QueryHandler.ExchangeRate
{
    public class GetExchangeRateByIdQueryHandler : IRequestHandler<GetExchangeRateByIdQuery, GetExchangeRateDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetExchangeRateByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<GetExchangeRateDto> Handle(GetExchangeRateByIdQuery request, CancellationToken cancellationToken)
        {
            GetExchangeRateDto model = _unitOfWork.GetRepository<BCOMExchangeRate>().GetAll().Where(m=>m.Id==request.ExchangeRateId).Select(row => new GetExchangeRateDto
            {
                Id = row.Id,
                SupplierId = row.BCOMSupplier.Id,
                SupplierName = row.BCOMSupplier.Name,
                ProductId = row.ProductId,
                ProductName = row.BCOMProduct.Name,
                BaseCurrencyCode = row.BaseCurrencyCode,
                BufferType = row.BufferType,
                BufferValue = row.BufferValue,
                BuyingRate = row.BuyingRate,
                AppliedRate = row.AppliedRate,
                Remarks = row.Remarks,
                SellingRate = row.SellingRate,
                FromDate = row.FromDate,
                ToCurrencyCode = row.ToCurrencyCode,
                Status = row.Status,
                AgentId = row.AgentId,
                AgentName = row.BCOMAgentProfile.Name, // Using navigation property
                CreatedOn = row.CreatedOn,
                ModifiedOn = row.ModifiedOn,
            }).FirstOrDefault();
            return Task.FromResult(model);
        }
    }
}
