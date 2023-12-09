using AutoMapper;
using ServiceCatalog.Domain.DTO.Playstation;
using ServiceCatalog.Domain.Entity.Playstation;

namespace ServiceCatalog.Application.Profiles;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<PlaystationCreateDTO, PlaystationArea>();
        //CreateMap<PlaystationUp, PlaystationArea>().
    }
}
