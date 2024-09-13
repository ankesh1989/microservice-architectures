﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace BCommerce.Shared.PipelineBehaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling {RequestType}", typeof(TRequest).Name);

            var response = await next();

            _logger.LogInformation("Handled {RequestType}", typeof(TRequest).Name);

            return response;
        }
    }
}
