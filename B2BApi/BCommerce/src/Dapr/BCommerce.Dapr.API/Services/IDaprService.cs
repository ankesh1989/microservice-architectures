namespace BCommerce.Dapr.API.Services
{
    public interface IDaprService<T> where T : class
    {
        Task<List<T>> GetAll(string controllerName);
        Task<T> GetById(int id, string controllerName);
    }
}