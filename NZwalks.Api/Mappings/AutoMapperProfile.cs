using AutoMapper;
using NZwalks.Api.Models.Domain;
using NZwalks.Api.Models.DTO;

namespace NZwalks.Api.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO,Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO,Region>().ReverseMap();
            CreateMap<AddWalkRequestDTO,Walk>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<Difficulty,DifficultyDTO>().ReverseMap();
            CreateMap<UpdateWalkRequsetDTO,Walk>().ReverseMap();
        }
    }
}
