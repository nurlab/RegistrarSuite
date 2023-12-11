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
            CreateMap<Student, StudentNationalityDto>()
                .ForMember(dest => dest.NationalityId, opt => opt.MapFrom(src => src.Nationality == null ? 0 : src.Nationality.Id)).ReverseMap();
            CreateMap<FamilyMember, FamilyMemberDto>().ReverseMap();
            CreateMap<FamilyMember, FamilyMemberBasicDto>().ReverseMap();
            CreateMap<FamilyMember, FamilyMemberBasicResponseDto>().ReverseMap();

            CreateMap<Country, CountryDto>().ReverseMap();

        }


    }


}
