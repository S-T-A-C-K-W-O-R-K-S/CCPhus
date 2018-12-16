using AutoMapper;
using CCPhus.API.DTOs;
using CCPhus.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPhus.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDTO>();
            CreateMap<User, UserForDetailedDTO>();
            CreateMap<Avatar, AvatarsForDetailedDTO>();
            CreateMap<Script, ScriptsForDetailedDTO>();
        }
    }
}
