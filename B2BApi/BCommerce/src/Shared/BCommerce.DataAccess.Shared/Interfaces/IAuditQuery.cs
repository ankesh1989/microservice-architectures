namespace BCommerce.DataAccess.Shared.Interfaces
{
    public interface IAuditQuery
    {
        Task<int> RetrieveAssetsCount<T>(string propertyValue) where T : class;
    }
}