using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries;

public class GetListBrandQuery : IRequest<List<GetListBrandResponse>>
{

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
