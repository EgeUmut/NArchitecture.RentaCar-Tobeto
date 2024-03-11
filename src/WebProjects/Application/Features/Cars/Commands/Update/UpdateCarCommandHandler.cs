using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdatedCarResponse>
{
    private ICarRepository _carRepository { get; }
    private IMapper _mapper { get; }
    private readonly CarBusinessRules _businessRules;

    public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules businessRules)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UpdatedCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        Car? car = await _carRepository.GetAsync(p => p.Id == request.Id);
        _businessRules.CarIdShouldExistWhenSelected(car);
        _businessRules.CarNameCanNotBeDuplicatedWhenUpdated(car);

        _mapper.Map(request, car);
        Car updatedCar = await _carRepository.UpdateAsync(car);
        UpdatedCarResponse updatedCarDto = _mapper.Map<UpdatedCarResponse>(updatedCar);
        return updatedCarDto;
    }
}
