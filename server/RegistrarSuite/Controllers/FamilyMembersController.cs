using Microsoft.AspNetCore.Mvc;
using RegistrarSuite.DTO.Students;
using RegistrarSuite.Services.Students;

namespace RegistrarSuite.Controllers
{
    [Route("api/FamilyMembers")]
    public class FamilyMembersController : BaseController
    {
        private readonly IFamilyMemberService _familyMemberService;

        public FamilyMembersController(IFamilyMemberService familyMemberService , IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _familyMemberService = familyMemberService;
        }

        //Deletes a family member for a particular Student
        //[PUT]/api/FamilyMembers/{id}
        [HttpPut("{id}")]
        public async Task<FamilyMemberBasicResponseDto> UpdatesFamilyMember(int id,[FromBody] FamilyMemberBasicDto familyMemberBasicDto)
        {
            FamilyMemberBasicResponseDto result = await _familyMemberService.UpdatesFamilyMember(id,familyMemberBasicDto);
            return result;
        }

        //Deletes a family member for a particular Student
        //[DELETE]/api/FamilyMembers/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFamilyMember(int id)
        {
            bool success = await _familyMemberService.DeleteFamilyMember(id);

            if(success) return Ok(); else return BadRequest();
        }

        //Gets a nationality associated with a family member
        //[GET] /api/FamilyMembers/{id}/Nationality/{id}
        [HttpGet("{familyMemberId}/Nationality/{nationalityId}")]
        public async Task<FamilyMemberDto> GetNationalityOfFamilyMember(int familyMemberId, int nationalityId)
        {
            FamilyMemberDto? result = await _familyMemberService.GetNationalityOfFamilyMember(familyMemberId,nationalityId);
            return result;
        }

        //Updates a particular Family Member’s Nationality
        //[PUT] /api/FamilyMembers/{id}/Nationality/{id}
        [HttpPut("{familyMemberId}/Nationality/{nationalityId}")]
        public async Task<FamilyMemberDto> UpdateNationalityOfFamilyMember(int familyMemberId, int nationalityId)
        {
            FamilyMemberDto? result = await _familyMemberService.UpdateNationalityOfFamilyMember(familyMemberId, nationalityId);
            return result;
        }

    }
}
