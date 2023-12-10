using AutoMapper;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Mapper
{
    public class Addmap :Profile
    {
        public Addmap()
        {
            CreateMap<ApplicationUserDTO, ApplicationUser>();
        }
    }
}
