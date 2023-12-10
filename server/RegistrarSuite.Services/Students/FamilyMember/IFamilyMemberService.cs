using RegistrarSuite.DTO.Students;

namespace RegistrarSuite.Services.Students
{
    public interface IFamilyMemberService
    {
        Task<bool> DeleteFamilyMember(int id);
        Task<FamilyMemberDto?> GetNationalityOfFamilyMember(int familyMemberId, int nationalityId);
        Task<FamilyMemberBasicResponseDto> UpdatesFamilyMember(int id,FamilyMemberBasicDto familyMemberBasicDto);
        Task<FamilyMemberDto?> UpdateNationalityOfFamilyMember(int familyMemberId, int nationalityId);
    }
}
