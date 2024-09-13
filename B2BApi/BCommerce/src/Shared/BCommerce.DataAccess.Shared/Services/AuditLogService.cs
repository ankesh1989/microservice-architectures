using BCommerce.DataAccess.Shared.Enums;
using BCommerce.DataAccess.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BCommerce.DataAccess.Shared.Services
{
    public class AuditLogService : IAuditLogService
    {
        public void SetCreatedAndModified(DbContext dbContext)
        {
            var entities = dbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (dynamic entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedOn = DateTime.UtcNow;
                }

                entity.Entity.ModifiedOn = DateTime.UtcNow;
            }
        }

        public void AuditChanges<TEntity>(DbContext dbContext, Type auditEntryType, Type auditLogType, DbSet<TEntity> auditLogs, string userId = "")
            where TEntity : class
        {
            var changeTracker = dbContext.ChangeTracker;
            changeTracker.DetectChanges();
            var auditEntries = new List<object>();

            foreach (var entry in changeTracker.Entries())
            {
                if (entry.Entity.GetType() == auditLogType || entry.State == EntityState.Added || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                dynamic auditEntry = Activator.CreateInstance(auditEntryType, entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserId = userId;
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue ?? string.Empty;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue ?? string.Empty;
                            break;
                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue ?? string.Empty;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue ?? string.Empty;
                                auditEntry.NewValues[propertyName] = property.CurrentValue ?? string.Empty;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries)
            {
                dynamic dynamicEntry = Convert.ChangeType(auditEntry, auditEntryType);
                auditLogs.Add(dynamicEntry.ToAudit());
            }
        }

        public void LogAudit<TEntity, TEntity2>(DbContext dbContext, TEntity oldEntity, TEntity newEntity, Type auditEntryType, Type auditLogType, DbSet<TEntity2> auditLogs, string userId = "")
           where TEntity : class where TEntity2 : class
        {
            var changedColumns = new List<string>();
            var differences = new
            {
                OldValues = GetPropertyValues(oldEntity),
                NewValues = GetPropertyValues(newEntity)
            };
            foreach (var prop in differences.OldValues.Keys)
            {
                var oldValue = differences.OldValues[prop];
                var newValue = differences.NewValues[prop];
                if (!Equals(oldValue, newValue))
                {
                    changedColumns.Add(prop);
                }
            }

            var entry = dbContext.Entry(newEntity);
            dynamic auditEntry = Activator.CreateInstance(auditEntryType, entry);
            auditEntry.TableName = entry.Entity.GetType().Name;
            auditEntry.UserId = userId;
            auditEntry.AuditType = AuditType.Update;
            PropertyInfo propertyInfo = typeof(TEntity).GetProperty("Id");
            if (propertyInfo != null)
            {
                object entityId = propertyInfo.GetValue(newEntity);
                auditEntry.KeyValues.Add("Id", entityId);
            }
            auditEntry.OldValues = new Dictionary<string, object>(differences.OldValues);
            auditEntry.NewValues = new Dictionary<string, object>(differences.NewValues);
            auditEntry.ChangedColumns = changedColumns;

            dynamic dynamicEntry = Convert.ChangeType(auditEntry, auditEntryType);
            auditLogs.Add(dynamicEntry.ToAudit());
        }

        private static Dictionary<string, object> GetPropertyValues<TEntity>(TEntity entity) where TEntity : class
        {
            var properties = typeof(TEntity).GetProperties()
                 .Where(prop =>
                    prop.GetGetMethod()?.IsVirtual == false // Exclude virtual properties
                    && prop.Name != PropertyType.CreatedOn.ToString() // Exclude CreatedOn property
                    && prop.Name != PropertyType.CreatedBy.ToString() // Exclude CreatedBy property
                    && prop.Name != PropertyType.ModifiedOn.ToString() // Exclude ModifiedOn property
                    && prop.Name != PropertyType.ModifiedBy.ToString() // Exclude ModifiedBy property
                    && prop.GetIndexParameters().Length == 0 // Exclude indexed properties, if any
                );
            var values = new Dictionary<string, object>();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(entity);
                values[prop.Name] = value;
            }

            return values;
        }
    }
}