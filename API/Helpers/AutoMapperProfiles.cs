using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser,MemberDTO>()
            //mapping PhotoURL from MemberDTO to AppUser Url of Photo Entity.
                .ForMember(dest => dest.PhotoUrl, opt=> opt.MapFrom(src => 
                    src.Photos.FirstOrDefault(x=>x.IsMain).Url))
                
                //mapping Age from MemberDTO to AppUser DateOfBirth with calculation of age.
                .ForMember(dest => dest.Age,opt=>opt.MapFrom(src => 
                    src.DateOfBirth.CalculateAge()));
            CreateMap<Photo,PhotoDTO>();
        }
    }
}