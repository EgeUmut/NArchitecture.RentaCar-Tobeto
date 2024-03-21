using Application.Features.CarImages.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.CarImages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CarImage, CreatedCarImagesResponse>().ReverseMap();
        }
    }
}
