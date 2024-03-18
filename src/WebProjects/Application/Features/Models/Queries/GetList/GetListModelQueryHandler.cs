using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetList;


public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, List<GetListModelResponse>>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelsBusinessRules _businessRules;

    public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper, ModelsBusinessRules businessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<List<GetListModelResponse>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
    {
        List<Model> models = await _modelRepository.GetAllAsync(include: x => x.Include(a => a.Brand));
        List<GetListModelResponse> responses = _mapper.Map<List<GetListModelResponse>>(models);
        return responses;
    }
}

