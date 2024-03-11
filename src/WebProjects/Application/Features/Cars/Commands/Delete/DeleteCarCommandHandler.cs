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

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    private readonly CarBusinessRules _businessRules;

    public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules businessRules)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<DeletedCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        Car? car = await _carRepository.GetAsync(p=>p.Id == request.Id);
        _businessRules.CarIdShouldExistWhenSelected(car);

        Car deletedCar = await _carRepository.DeleteAsync(car);
        DeletedCarResponse deletedCarDto = _mapper.Map<DeletedCarResponse>(deletedCar);
        return deletedCarDto;
    }
}
