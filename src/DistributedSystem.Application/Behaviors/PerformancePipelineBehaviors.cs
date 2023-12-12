using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DistributedSystem.Application.Behaviors
{
    public class PerformancePipelineBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<IRequest> _logger;

        public PerformancePipelineBehaviors(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = (ILogger<IRequest>?)logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();

            var elepsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elepsedMilliseconds <= 5000) return response;

            var requestName = typeof(TRequest).Name;
            _logger.LogWarning("Long time running - request details {Name} ({ElapseMilliseconds} milliseconds) {Request}", requestName, elepsedMilliseconds, request);
            return response;

        }
    }
}
