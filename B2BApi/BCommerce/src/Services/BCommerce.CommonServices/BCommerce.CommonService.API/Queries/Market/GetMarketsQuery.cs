using BCommerce.CommonService.API.DTOs.Market;
using BCommerce.Shared.Types;
using BCommerce.Shared.ValueObjects;
using MediatR;

namespace BCommerce.CommonService.API.Queries.Market
{
    public class GetMarketsQuery : IRequest<PagedList<GetMarketsDto>>
    {
        public GetMarketsQuery(PagingDTO pagingModel)
        {
            _pagingDTO = pagingModel;
        }

        public PagingDTO _pagingDTO { get; set; }

    }
}
