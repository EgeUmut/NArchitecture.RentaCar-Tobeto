using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Performance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelQuery:IRequest<List<GetListModelResponse>>,IIntervalRequest,ICachableRequest
{
    public int Interval => 1;

    public bool BypassCache { get; }
    public string CacheKey => "Model-list";
    public TimeSpan? SlidingExpiration { get; }
}
