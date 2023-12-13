using AutoMapper;
using Microsoft.Extensions.Logging;
using NLog;
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
        private readonly IMapper _mapper;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public FamilyMemberService(IMapper mapper,
            IUnitOfWork<AppDbContext> unitOfWork, IFamilyMemberRepository familyMemberRepository , ICountryRepository countryRepository)
        {
            _mapper = mapper;
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
                        _logger.Error($"Failed to remove the family member {id}");
                        return false; ;
                    }
                }
                else
                {
                    _logger.Error($"family member {id} does not exist");
                    return false; ;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
                throw;
            }

        }

        public async Task<FamilyMemberDto?> GetNationalityOfFamilyMember(int familyMemberId, string nationalityCode)
        {
            // NOTE : Parameter nationalityCode unused because the nationality is already extracted with the familyMemberId;
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
                    _logger.Error($"family member {familyMemberId} does not exist");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
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
                        _logger.Error($"Failed to update the family member {id}");
                        return null;
                    }
                }
                else
                {
                    _logger.Error($"family member {id} does not exist");
                    return null;
                }
                var updatedFamilyMember = _mapper.Map<FamilyMemberBasicResponseDto>(familyMember);

                return updatedFamilyMember;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
                throw;
            }

        }

        public async Task<FamilyMemberDto?> UpdateNationalityOfFamilyMember(int familyMemberId, string nationalityCode)
        {
            try
            {
                var familyMember = await _familyMemberRepository.GetFirstOrDefaultAsync(x => x.Id == familyMemberId);

                if (familyMember != null)
                {
                    var country = await _countryRepository.GetFirstOrDefaultAsync(x => x.Code == nationalityCode);
                    if(country != null)
                    {
                        familyMember.NationalityCode = nationalityCode;
                    }
                    else
                    {
                        _logger.Error($"Failed to find Nationality {nationalityCode}");
                        return null;
                    }

                    _familyMemberRepository.Update(familyMember);

                    int save = await _unitOfWork.CommitAsync();
                    if (save == 0)
                    {
                        _logger.Error($"Failed to update the family member {familyMemberId}");
                        return null;
                    }
                }
                else
                {
                    _logger.Error($"family member {familyMemberId} does not exist");
                    return null;
                }
                var updatedFamilyMember = _mapper.Map<FamilyMemberDto>(familyMember);

                return updatedFamilyMember;

            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
                throw;
            }
        }
    }
}
