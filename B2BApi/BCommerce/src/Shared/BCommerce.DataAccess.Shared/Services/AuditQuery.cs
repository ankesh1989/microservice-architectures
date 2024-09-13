using BCommerce.DataAccess.Shared.Enums;
using BCommerce.DataAccess.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BCommerce.DataAccess.Shared.Services
{
    public class AuditQuery : IAuditQuery
    {
        private readonly DbContext _dbContext;
        public AuditQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> RetrieveAssetsCount<T>(string propertyValue) where T : class
        {
            try
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, PropertyType.AuditType.ToString());
                var equal = Expression.Equal(property, Expression.Constant(propertyValue));
                var lambda = Expression.Lambda<Func<T, bool>>(equal, parameter);
                var count = await _dbContext.Set<T>().AsNoTracking().Where(lambda).CountAsync();
                return count;
            }
            catch(Exception ex) 
            {
                throw new Exception(AuditName.Error.ToString());
            }
        }
    }
}