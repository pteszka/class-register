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

            CreateMap<ClassDTO, Class>()
                .ForMember(dest => dest.ClassId, opt => opt.Ignore())
                .ForMember(dest => dest.Students, opt => opt.Ignore()); 

            CreateMap<StudentDTO, PersonalInfo>()
                .ForMember(dest => dest.PersonalInfoId, opt => opt.Ignore());
            CreateMap<StudentDTO, Account>()
                .ForMember(dest => dest.AccountId, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore());
            // add map for class 
            CreateMap<StudentDTO, Student>()
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.PersonalInfo, opt => opt.MapFrom(src => src)); 

            
        }
    }
}