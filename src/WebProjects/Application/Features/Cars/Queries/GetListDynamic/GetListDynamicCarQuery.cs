using Application.Features.Brands.Models;
using Application.Features.Cars.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.Cars.Queries.GetListDynamic;

public class GetListDynamicCarQuery:IRequest<CarListModel>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}
