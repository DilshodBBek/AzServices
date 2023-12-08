using AutoMapper;
using ServiceCatalog.Domain.DTO.Playstation;
using ServiceCatalog.Domain.Entity.Playstation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<PlaystationCreateDTO, PlaystationArea>();
            //CreateMap<PlaystationUp, PlaystationArea>().
        }
    }
}
