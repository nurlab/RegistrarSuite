﻿using AutoMapper;
using RegistrarSuite.Data.DataContext;
using RegistrarSuite.DTO.Students;
using RegistrarSuite.Repositories.Metadata;
using RegistrarSuite.Repositories.UOW;
using RegistrarSuite.Data.Models.StudentSchema;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using RegistrarSuite.Data.Models.MetadataSchema;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace RegistrarSuite.Services.Students
{
    public class StudentService : IStudentService
    {

        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IStudentRepository _studentRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IFamilyMemberRepository _familyMemberRepository;
        private readonly IMapper _mapper;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public StudentService(IMapper mapper,
            IUnitOfWork<AppDbContext> unitOfWork, IStudentRepository studentRepository, ICountryRepository countryRepository, IFamilyMemberRepository familyMemberRepository
            )
        {
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
            _countryRepository = countryRepository;
            _familyMemberRepository = familyMemberRepository;   
            _mapper = mapper;

        }
        public async Task<List<StudentDto>> GetAllStudents()
        {
            try
            {
                var students = await _studentRepository.GetAllAsync(x => !x.IsDeleted);

                if (students != null)
                {
                    List<StudentDto> studentDtos = _mapper.Map<List<StudentDto>>(students);

                    return studentDtos;                
                }
                else
                {
                    _logger.Error($"No students found");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
                throw;
            }
        }

        public async Task<StudentBasicDto?> AddNewStudent(StudentBasicDto studentBasicDto)
        {
            try
            {
                var newStudent = _mapper.Map<Student>(studentBasicDto);

                newStudent.CreatedBy = 1; // will be replaced by Logged in User Id when Identity feature is built
                newStudent.UpdatedBy = null;  // will be replaced by Logged in User Id when Identity feature is built
                newStudent.CreatedOn = DateTime.Now;
                newStudent.UpdatedOn = null;
                newStudent.IsActive = true;
                newStudent.IsDeleted = false;

                await _studentRepository.AddAsync(newStudent);

                int save = await _unitOfWork.CommitAsync();
                if (save == 0)
                {
                    _logger.Error("Failed to save the Student");
                    return null; ;
                }

                studentBasicDto = _mapper.Map<StudentBasicDto>(newStudent);

                return studentBasicDto;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
                throw;
            }
        }
        public async Task<StudentWithFamilyMembersDto> AddStudentWithFamilyMembers(StudentWithFamilyMembersDto studentWithFamilyMembersDto)
        {
            try
            {
                
                var newStudent = _mapper.Map<Student>(studentWithFamilyMembersDto);
                var newFamilyMembers = _mapper.Map<List<FamilyMember>>(studentWithFamilyMembersDto.FamilyMembers);

                newStudent.SetCreateProperties(newStudent);
                newFamilyMembers.ForEach(familyMember => newStudent.SetCreateProperties(familyMember));

                newStudent.FamilyMembers = newFamilyMembers;

                await _studentRepository.AddAsync(newStudent);

                int save = await _unitOfWork.CommitAsync();
                if (save == 0)
                {
                    _logger.Error("Failed to save the Student");
                    return null; ;
                }

                var createdStudentWithFamilyMembersDto  = _mapper.Map<StudentWithFamilyMembersDto>(newStudent);
                createdStudentWithFamilyMembersDto.FamilyMembers = _mapper.Map<List<FamilyMemberDto>>(newFamilyMembers);

                return createdStudentWithFamilyMembersDto;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
                throw;
            }
        }


        public async Task<StudentBasicDto?> UpdateStudent(int id , StudentBasicDto studentBasicDto)
        {
            try
            {
                var newStudent = _mapper.Map<Student>(studentBasicDto);

                var studentExist = await _studentRepository.GetFirstAsync(x => x.Id == id);
                if (studentExist != null)
                {
                    newStudent.Id = id;  // will be replaced by Logged in User Id when Identity feature is built
                    newStudent.UpdatedBy = 1;  // will be replaced by Logged in User Id when Identity feature is built
                    newStudent.UpdatedOn = DateTime.Now;
                    newStudent.CreatedBy = studentExist.CreatedBy;
                    newStudent.CreatedOn = studentExist.CreatedOn;
                    newStudent.NationalityCode = studentExist.NationalityCode;

                    var updatedStudent = _studentRepository.Update(newStudent);

                    int save = await _unitOfWork.CommitAsync();
                    if (save == 0)
                    {
                        _logger.Error("Failed to update the Student");
                        return null; ;
                    }

                    studentBasicDto = _mapper.Map<StudentBasicDto>(updatedStudent);

                    return studentBasicDto;
                }
                else
                {
                    _logger.Error($"student {id} does not exist");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
                throw;
            }
        }

        public StudentNationalityDto? GetStudentNationality(int id)
        {
            try
            {
                var studentExist = _studentRepository.GetFirstOrDefault(x => x.Id == id && !x.IsDeleted);
                if (studentExist != null)
                {
                    StudentNationalityDto studentNationalityDto = _mapper.Map<StudentNationalityDto>(studentExist); ;
                    return studentNationalityDto;
                }
                else
                {
                    _logger.Error($"student {id} does not exist");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
                throw;
            }
        }

        public async Task<StudentNationalityDto?> UpdateStudentNationality(int id, string nationalityCode)
        {
            try
            {

                var studentExist = _studentRepository.GetFirstOrDefault(x => x.Id == id);
                if (studentExist != null)
                {
                    StudentNationalityDto studentDto = _mapper.Map<StudentNationalityDto>(studentExist); ;

                    Country country = _countryRepository.GetFirstOrDefault(x => x.Code == nationalityCode);

                    if (country != null)
                    {
                        studentExist.UpdatedBy = 1;  // will be replaced by Logged in User Id when Identity feature is built
                        studentExist.UpdatedOn = DateTime.Now;
                        studentExist.NationalityCode = country.Code;
                    }
                    else
                    {
                        _logger.Error($"nationality {nationalityCode} does not exist");
                        return null;
                    }

                    var updatedStudent = _studentRepository.Update(studentExist);


                    int save = await _unitOfWork.CommitAsync();
                    if (save == 0)
                    {
                        _logger.Error("Failed to update the Nationality");
                        return null; ;
                    }
                    return studentDto;
                }
                else
                {
                    _logger.Error($"student {id} does not exist");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
                throw;
            }
        }

        public List<FamilyMemberBasicResponseDto>? GetFamilyMembers(int id)
        {
            try
            {
                var student = _studentRepository
                    .GetAll(x => x.Id == id && x.FamilyMembers != null)
                    .Include(x => x.FamilyMembers)
                    .FirstOrDefault();
                if (student != null)
                {
                    if (student?.FamilyMembers?.Any() == true)
                    {
                        List<FamilyMemberBasicResponseDto> familyMemberListDto = _mapper.Map<List<FamilyMemberBasicResponseDto>>(student.FamilyMembers.Where(x => !x.IsDeleted).OrderBy(x=>x.UpdatedOn).OrderBy(x => x.CreatedOn));
                        return familyMemberListDto;
                    }

                    _logger.Error($" student {id} does not have any family registered");
                    return null;
                }
                else
                {
                    _logger.Error($"student {id} does not exist");
                    return null;
                }


            }
            catch (Exception ex)
            {
                _logger.Error($"Error in GetFamilyMembers: {ex}");
                throw;
            }
        }

        public async Task<FamilyMemberBasicResponseDto>? AddFamilyMember(int id, [FromBody] FamilyMemberBasicDto requestDto)
        {
            try
            {
                var newFamilyMember = _mapper.Map<FamilyMember>(requestDto);

                newFamilyMember.CreatedBy = 1; // will be replaced by Logged in User Id when Identity feature is built
                newFamilyMember.UpdatedBy = null;  // will be replaced by Logged in User Id when Identity feature is built
                newFamilyMember.CreatedOn = DateTime.Now;
                newFamilyMember.UpdatedOn = null;
                newFamilyMember.IsActive = true;
                newFamilyMember.IsDeleted = false;
                newFamilyMember.StudentId = id;

                await _familyMemberRepository.AddAsync(newFamilyMember);

                int save = await _unitOfWork.CommitAsync();
                if (save == 0)
                {
                    _logger.Error("Failed to save the Family Member");
                    return null;
                }

                var studentBasicDto = _mapper.Map<FamilyMemberBasicResponseDto>(newFamilyMember);

                return studentBasicDto;

            }
            catch (Exception ex)
            {
                _logger.Error($"Error in GetFamilyMembers: {ex}");
                throw;
            }
        }

    }
}
