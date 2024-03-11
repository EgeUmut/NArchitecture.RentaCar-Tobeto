using Core.Application.Responses;

namespace Application.Features.Models.Dtos;

public class UpdatedModelResponse : IResponse
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Name { get; set; }
}
