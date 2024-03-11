using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdatedModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelsBusinessRules _modelsBusinessRules;

    public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelsBusinessRules businessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _modelsBusinessRules = businessRules;
    }

    public async Task<UpdatedModelResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        Model? model = await _modelRepository.GetAsync(x => x.Id == request.Id);
        _modelsBusinessRules.ModelIdShouldExistWhenSelected(model);  //Check Model if exist

        _mapper.Map(request, model);

        Model updatedModel = await _modelRepository.UpdateAsync(model);
        UpdatedModelResponse? response = _mapper.Map<UpdatedModelResponse>(updatedModel);
        return response;
    }
}
