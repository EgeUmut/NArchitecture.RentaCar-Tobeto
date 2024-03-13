using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Application.Pipelines.Logging;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>, ILoggableRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LoggerServiceBase _loggerServiceBase;

    public LoggingBehavior(LoggerServiceBase loggerServiceBase, IHttpContextAccessor httpContextAccessor)
    {
        _loggerServiceBase = loggerServiceBase;
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<LogParameter> logParameters = new List<LogParameter>();
        logParameters.Add(new LogParameter { Value = request, Type = request.GetType().Name });

        LogDetail logDetail = new LogDetail()
        {
            MethodName = next.Method.Name,
            LogParameters = logParameters,
            User = _httpContextAccessor.HttpContext == null || _httpContextAccessor.HttpContext.User.Identity.Name == null ? "?" :
                _httpContextAccessor.HttpContext.User.Identity.Name,
            Response = _httpContextAccessor.HttpContext.Response.StatusCode.ToString()
        };
        _loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));
        return next();
    }
}
