using Application.Features.CarImages.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarImages.Commands.Create
{
    public class CreateCarImageCommand:IRequest<CreatedCarImagesResponse>
    {
        public IFormFile file { get; set; }
        public int CarId { get; set; }
    }
}
