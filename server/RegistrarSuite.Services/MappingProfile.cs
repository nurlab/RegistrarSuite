using AutoMapper;
using RegistrarSuite.Data.Models.MetadataSchema;
using RegistrarSuite.Data.Models.StudentSchema;
using RegistrarSuite.DTO.Metadata;
using RegistrarSuite.DTO.Students;

namespace RegistrarSuite.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentBasicDto>().ReverseMap();
            CreateMap<Student, StudentNationalityDto>().ReverseMap();
            CreateMap<Student, StudentWithFamilyMembersDto>()
                       .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                       .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                       .ForMember(dest => dest.NationalityCode, opt => opt.MapFrom(src => src.NationalityCode))
                       .ReverseMap();
            CreateMap<FamilyMember, FamilyMemberDto>().ReverseMap();
            CreateMap<FamilyMember, FamilyMemberBasicDto>().ReverseMap();
            CreateMap<FamilyMember, FamilyMemberBasicResponseDto>().ReverseMap();

            CreateMap<Country, CountryDto>().ReverseMap();

        }


    }


}
