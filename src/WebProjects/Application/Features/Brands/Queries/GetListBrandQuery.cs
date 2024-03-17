using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Performance;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries;

public class GetListBrandQuery : IRequest<List<GetListBrandResponse>>,ICachableRequest,IIntervalRequest
{
    public int Interval => 1;

    public bool BypassCache {get;}
    public string CacheKey => "brand-list";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, List<GetListBrandResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListBrandResponse>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            List<Brand> brands = await _brandRepository.GetAllAsync();
            var mappedBrandListModel = _mapper.Map<List<GetListBrandResponse>>(brands);
            return mappedBrandListModel;
        }
    }
}
