using Application.Features.Cars.Models;
using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Queries.GetListDynamic;

public class GetListDynamicModelQueryHandler : IRequestHandler<GetListDynamicModelQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListDynamicModelQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        ModelListModel modelListModel = _mapper.Map<ModelListModel>(models);
        return modelListModel;
    }
}
