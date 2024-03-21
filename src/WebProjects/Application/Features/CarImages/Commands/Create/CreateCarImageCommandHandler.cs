using Application.Features.CarImages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Utilities.Helpers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Commands.Create;

public class CreateCarImageCommandHandler : IRequestHandler<CreateCarImageCommand, CreatedCarImagesResponse>
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly IMapper _mapper;

    public CreateCarImageCommandHandler(ICarImageRepository carImageRepository, IMapper mapper)
    {
        _carImageRepository = carImageRepository;
        _mapper = mapper;
    }

    public async Task<CreatedCarImagesResponse> Handle(CreateCarImageCommand request, CancellationToken cancellationToken)
    {
        CarImage carImage = new();
        carImage.CarId = request.CarId;
        carImage.ImagePath = FileHelper.Add(request.file, "CarImages");
        var item = await _carImageRepository.AddAsync(carImage);
        CreatedCarImagesResponse createdCarImagesResponse = _mapper.Map<CreatedCarImagesResponse>(item);
        return createdCarImagesResponse;
    }
}
