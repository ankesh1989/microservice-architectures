using Microsoft.EntityFrameworkCore;

namespace BCommerce.DataAccess.Shared.Interfaces
{
    public interface IAuditLogService
    {
        void SetCreatedAndModified(DbContext dbContext);
        void AuditChanges<TEntity>(DbContext dbContext, Type auditEntryType, Type auditLogType, DbSet<TEntity> auditLogs, string userId = "") where TEntity : class;
        void LogAudit<TEntity, TEntity2>(DbContext dbContext, TEntity oldEntity, TEntity newEntity, Type auditEntryType, Type auditLogType, DbSet<TEntity2> auditLogs, string userId = "") where TEntity : class where TEntity2 : class;
    }
}