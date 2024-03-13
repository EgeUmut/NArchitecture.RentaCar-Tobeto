using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Core.Application.Pipelines.Performance;

public class PerformanceBahvior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IIntervalRequest
{
    private readonly ILogger<PerformanceBahvior<TRequest, TResponse>> _logger;
    private readonly Stopwatch _stopwatch;

    public PerformanceBahvior(ILogger<PerformanceBahvior<TRequest, TResponse>> logger, Stopwatch stopwatch)
    {
        _logger = logger;
        _stopwatch = stopwatch;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string RequestName = request.GetType().Name;
        TResponse response;

        try
        {
            _stopwatch.Start();
            response = await next();
        }
        catch (Exception e)
        {
            if (_stopwatch.Elapsed.TotalSeconds > request.Interval)
            {
                string message = $"Performance =>{RequestName} {_stopwatch.Elapsed.TotalSeconds} s";
                Debug.WriteLine(message);
                _logger.LogInformation(message);
            }
        }
        finally
        {
            _stopwatch.Restart();
        }

        return await next();    //response yapınca çalışmıyor nedense ?
    }
}
