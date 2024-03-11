using Application.Features.Brands.Dtos;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand :IRequest<DeletedBrandResponse>
{
    public int Id { get; set; }

}
