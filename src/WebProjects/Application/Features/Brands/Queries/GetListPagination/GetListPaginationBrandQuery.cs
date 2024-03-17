using Application.Features.Brands.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Brands.Queries.GetListPagination;

public class GetListPaginationBrandQuery:IRequest<BrandListModel>
{
    public PageRequest PageRequest { get; set; }
}
