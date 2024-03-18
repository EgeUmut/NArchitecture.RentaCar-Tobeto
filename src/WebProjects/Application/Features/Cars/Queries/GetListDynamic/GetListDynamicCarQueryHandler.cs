using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetListDynamic;

public class GetListDynamicCarQueryHandler : IRequestHandler<GetListDynamicCarQuery, CarListModel>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetListDynamicCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarListModel> Handle(GetListDynamicCarQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Car> cars = await _carRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        CarListModel CarListModel = _mapper.Map<CarListModel>(cars);
        return CarListModel;
    }
}
