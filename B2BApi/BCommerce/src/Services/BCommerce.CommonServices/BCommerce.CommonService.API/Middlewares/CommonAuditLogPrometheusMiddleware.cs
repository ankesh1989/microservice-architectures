using BCommerce.DataAccess.Shared.Enums;
using BCommerce.DataAccess.Shared.Interfaces;

namespace BCommerce.CommonService.API.Middlewares
{
    public class CommonAuditLogPrometheusMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Counter _createCounter;
        private readonly Counter _updateCounter;
        private readonly Counter _deleteCounter;

        public CommonAuditLogPrometheusMiddleware(RequestDelegate next)
        {
            _next = next;
            _createCounter = Metrics.CreateCounter("total_common_created_entities", "Total count of common data  inserted");
            _updateCounter = Metrics.CreateCounter("total_common_updated_entities", "Total count of common data  updated");
            _deleteCounter = Metrics.CreateCounter("total_common_deleted_entities", "Total count of common data deleted");
        }

        public async Task InvokeAsync(HttpContext context, IAuditQuery _auditLogRepository)
        {
            using (var scope = context.RequestServices.CreateScope())
            {
                var createCount = await _auditLogRepository.RetrieveAssetsCount<AuditLog>(AuditName.Create.ToString());
                var updateCount = await _auditLogRepository.RetrieveAssetsCount<AuditLog>(AuditName.Update.ToString());
                var deleteCount = await _auditLogRepository.RetrieveAssetsCount<AuditLog>(AuditName.Delete.ToString());
                _createCounter.IncTo(createCount);
                _updateCounter.IncTo(updateCount);
                _deleteCounter.IncTo(deleteCount);
            }
            await _next(context);
        }
    }
}

