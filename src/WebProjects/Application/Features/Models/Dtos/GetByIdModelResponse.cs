using Core.Application.Responses;

namespace Application.Features.Models.Dtos;

public class GetByIdModelResponse : IResponse
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string BrandName { get; set; }
    public string Name { get; set; }
}
