using Application.Features.Cars.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Cars.Queries.GetListPagination;

public class GetListPaginationCarQuery:IRequest<CarListModel>
{
    public PageRequest PageRequest { get; set; }
}
