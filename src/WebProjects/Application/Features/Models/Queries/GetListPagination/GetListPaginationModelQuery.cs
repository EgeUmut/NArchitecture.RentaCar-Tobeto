using Application.Features.Models.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Models.Queries.GetListPagination;

public class GetListPaginationModelQuery:IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }
}
