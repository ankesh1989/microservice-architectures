using System.Collections.Specialized;

namespace BCommerce.Dapr.API.Utilities
{
    public static class CommonHelper
    {
        public static NameValueCollection GetQueryParams<TSource>(this TSource source)
        {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            var properties = source?.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source);
                if (value != null)
                {
                    queryString[prop.Name] = value.ToString();
                }
            }
            return queryString;
        }

        public static PagedList<TSource> GetFilterData<TSource>(this List<TSource> source, PagingDTO pagingModel)
        {
            var queryableList = source.AsQueryable();
            var pagedData = queryableList.Filter(pagingModel.ColumnName, pagingModel.OperationName, pagingModel.SearchText).OrderByDynamic(pagingModel.OrderBy, pagingModel.OrderType).ToPagedList(pagingModel.PageNo, pagingModel.PageSize);
            return pagedData;
        }
    }
}
