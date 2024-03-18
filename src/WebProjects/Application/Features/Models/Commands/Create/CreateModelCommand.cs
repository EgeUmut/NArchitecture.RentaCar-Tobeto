using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Performance;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommand:IRequest<CreatedModelResponse>,IIntervalRequest,ICacheRemoverRequest
{
    public string Name { get; set; }
    public int BrandId { get; set; }
    public int Interval => 1;

    public bool BypassCache { get; }
    public string CacheKey => "Model-list";
}
