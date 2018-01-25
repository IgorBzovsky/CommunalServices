using AutoMapper;
using CommunalServices.Controllers.Resources;
using CommunalServices.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationResource>();
        }
    }
}
