using BCommerce.CommonService.API.DTOs.Market;
using MediatR;

namespace BCommerce.CommonService.API.Queries.Market
{
    public class GetMarketByIdQuery : IRequest<GetMarketsDto>
    {
        public GetMarketByIdQuery(int marketId)
        {
            _MarketId = marketId;
        }

        public int _MarketId { get; set; }

    }
}
