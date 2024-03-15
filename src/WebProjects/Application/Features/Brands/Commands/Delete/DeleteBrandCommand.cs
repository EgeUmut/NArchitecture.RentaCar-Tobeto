using Application.Features.Brands.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand :IRequest<DeletedBrandResponse>, IIntervalRequest, ILoggableRequest, ICacheRemoverRequest
{
    public int Id { get; set; }
    public int Interval => 1;

    public bool BypassCache { get; }
    public string CacheKey => "brand-list";

}
