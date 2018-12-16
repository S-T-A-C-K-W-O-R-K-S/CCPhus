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
            CreateMap<User, UserForListDTO>()
                .ForMember(dest => dest.AvatarURL, opt => {
                    opt.MapFrom(src => src.Avatars.FirstOrDefault(avatar => avatar.IsMain).URL);
                });
            CreateMap<User, UserForDetailedDTO>()
                .ForMember(dest => dest.AvatarURL, opt => {
                    opt.MapFrom(src => src.Avatars.FirstOrDefault(avatar => avatar.IsMain).URL);
                })
                .ForMember(dest => dest.TimeAsUser, opt => {
                    opt.MapFrom(src => src.Created.CalculateTimeAsUser());
                });
            CreateMap<Avatar, AvatarsForDetailedDTO>();
            CreateMap<Script, ScriptsForDetailedDTO>();
            CreateMap<User, Script>()
                .ForMember(dest => dest.Owner, opt => {
                    opt.MapFrom(src => src.Username);
                })
                .ForMember(dest => dest.OwnerId, opt => {
                    opt.MapFrom(src => src.Id);
                });
        }
    }
}
