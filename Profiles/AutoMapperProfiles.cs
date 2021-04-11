using System;
using AutoMapper;
using ClassRegister.Models;

namespace ClassRegister.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TeacherDTO, PersonalInfo>()
                .ForMember(dest => dest.PersonalInfoId, opt => opt.Ignore());
            CreateMap<TeacherDTO, Account>()
                .ForMember(dest => dest.AccountId, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore());
            CreateMap<TeacherDTO, Teacher>()
                .ForMember(dest => dest.TeacherId, opt => opt.Ignore())
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.PersonalInfo, opt => opt.MapFrom(src => src));                
        }
    }
}