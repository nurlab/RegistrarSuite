using AutoMapper;
using Microsoft.Extensions.Logging;
using RegistrarSuite.Data.DataContext;
using RegistrarSuite.Data.Models.StudentSchema;
using RegistrarSuite.DTO.Students;
using RegistrarSuite.Repositories.Metadata;
using RegistrarSuite.Repositories.UOW;

namespace RegistrarSuite.Services.Students
{
    public class FamilyMemberService : IFamilyMemberService
    {

        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IFamilyMemberRepository _familyMemberRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public FamilyMemberService(IMapper mapper,
            IUnitOfWork<AppDbContext> unitOfWork, IFamilyMemberRepository familyMemberRepository , ICountryRepository countryRepository, ILogger logger
            )
        {
            _mapper = mapper;
            _logger = logger;
            _familyMemberRepository = familyMemberRepository;
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteFamilyMember(int id)
        {
            try
            {
                var faimilyMember = await _familyMemberRepository.GetFirstOrDefaultAsync(x => x.Id == id);

                if(faimilyMember != null)
                {
                    faimilyMember.IsDeleted = true;

                    _familyMemberRepository.Update(faimilyMember);

                    int save = await _unitOfWork.CommitAsync();
                    if (save == 0)
                    {
                        _logger.LogError($"Failed to remove the family member {id}");
                        return false; ;
                    }
                }
                else
                {
                    _logger.LogError($"family member {id} does not exist");
                    return false; ;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in row '{ex}'");
                throw;
            }

        }

        public async Task<FamilyMemberDto?> GetNationalityOfFamilyMember(int familyMemberId, int nationalityId)
        {
            // NOTE : Parameter nationalityId unused because the nationality is already extracted with the familyMemberId;
            try
            {
                var familyMember = await _familyMemberRepository.GetFirstOrDefaultAsync(x => x.Id == familyMemberId);
                if (familyMember != null)
                {
                    var familyMemberDto = _mapper.Map<FamilyMemberDto>(familyMember);
                    return familyMemberDto;
                }
                else
                {
                    _logger.LogError($"family member {familyMemberId} does not exist");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in row '{ex}'");
                throw;
            }
        }

        public async Task<FamilyMemberBasicResponseDto> UpdatesFamilyMember(int id ,FamilyMemberBasicDto familyMemberBasicDto)
        {
            try
            {
                var familyMember = await _familyMemberRepository.GetFirstOrDefaultAsync(x => x.Id == id);

                if (familyMember != null)
                {

                    familyMember.DateOfBirth = familyMemberBasicDto.DateOfBirth;
                    familyMember.FirstName = familyMemberBasicDto.FirstName;
                    familyMember.LastName = familyMemberBasicDto.LastName;
                    familyMember.Relationship = familyMemberBasicDto.Relationship;
                    familyMember.UpdatedOn = DateTime.Now;
                    familyMember.UpdatedBy = 0;

                    _familyMemberRepository.Update(familyMember);

                    int save = await _unitOfWork.CommitAsync();
                    if (save == 0)
                    {
                        _logger.LogError($"Failed to update the family member {id}");
                        return null;
                    }
                }
                else
                {
                    _logger.LogError($"family member {id} does not exist");
                    return null;
                }
                var updatedFamilyMember = _mapper.Map<FamilyMemberBasicResponseDto>(familyMember);

                return updatedFamilyMember;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in row '{ex}'");
                throw;
            }

        }

        public async Task<FamilyMemberDto?> UpdateNationalityOfFamilyMember(int familyMemberId, int nationalityId)
        {
            try
            {
                var familyMember = await _familyMemberRepository.GetFirstOrDefaultAsync(x => x.Id == familyMemberId);

                if (familyMember != null)
                {
                    var country = await _countryRepository.GetFirstOrDefaultAsync(x => x.Id == nationalityId);
                    if(country != null)
                    {
                        familyMember.NationalityId = nationalityId;
                    }
                    else
                    {
                        _logger.LogError($"Failed to find Nationality {nationalityId}");
                        return null;
                    }

                    _familyMemberRepository.Update(familyMember);

                    int save = await _unitOfWork.CommitAsync();
                    if (save == 0)
                    {
                        _logger.LogError($"Failed to update the family member {familyMemberId}");
                        return null;
                    }
                }
                else
                {
                    _logger.LogError($"family member {familyMemberId} does not exist");
                    return null;
                }
                var updatedFamilyMember = _mapper.Map<FamilyMemberDto>(familyMember);

                return updatedFamilyMember;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in row '{ex}'");
                throw;
            }
        }
    }
}
