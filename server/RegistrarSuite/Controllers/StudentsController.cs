using Microsoft.AspNetCore.Mvc;
using RegistrarSuite.DTO.Students;
using RegistrarSuite.Services.Students;
using System.Collections.Generic;

namespace RegistrarSuite.Controllers
{
    [Route("api/Students")]
    public class StudentsController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentsController( IStudentService studentService , IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _studentService = studentService;
        }

        // Get all Students
        // GET /api/Students
        [HttpGet]
        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            List<StudentDto> result = await _studentService.GetAllStudents();
            return result;
        }

        // Add a new Student with Basic Details Only
        // [POST] /api/Students
        [HttpPost]
        public async Task<StudentBasicDto>? AddNewStudent([FromBody] StudentBasicDto studentBasicDto)
        {
            StudentBasicDto? result = await _studentService.AddNewStudent(studentBasicDto);
            return result;
        }

        // Updates a Student’s Basic Details only
        // [PUT] /api/Students/{id}
        [HttpPut("{id}")]
        public async Task<StudentBasicDto>? UpdateStudent(int id, [FromBody] StudentBasicDto studentBasicDto)
        {
            StudentBasicDto? result = await _studentService.UpdateStudent(id,studentBasicDto);
            return result;
        }

        // Gets the Nationality of a particular student
        // [GET] /api/Students/{id}/Nationality
        [HttpGet("{id}/Nationality")]
        public StudentNationalityDto? GetStudentNationalityAsync(int id)
        {
            StudentNationalityDto? result = _studentService.GetStudentNationality(id);
            return result;
        }

        // Updates a Student’s Nationality
        // PUT /api/Students/{id}/Nationality/{id}
        [HttpPut("{id}/Nationality/{nationalityCode}")]
        public async Task<StudentNationalityDto?> UpdateStudentNationality(int id, string nationalityCode)
        {
            StudentNationalityDto? result = await _studentService.UpdateStudentNationality(id, nationalityCode);
            return result;
        }

        // Gets Family Members for a particular Student
        // GET /api/Students/{id}/FamilyMembers/
        [HttpGet("{id}/FamilyMembers")]
        public List<FamilyMemberBasicResponseDto>? GetFamilyMembers(int id) // id parameter refers to a student`s ID
        {
            List<FamilyMemberBasicResponseDto>? result = _studentService.GetFamilyMembers(id);
            return result;
        }

        // Creates a new Family Member for a particular Student (without the nationality)
        // POST /api/Students/{id}/FamilyMembers/
        [HttpPost("{id}/FamilyMembers")]
        public async Task<FamilyMemberBasicResponseDto>? AddFamilyMember(int id, [FromBody] FamilyMemberBasicDto requestDto)
        {
            FamilyMemberBasicResponseDto? result = await _studentService.AddFamilyMember(id, requestDto);
            return result;
        }

    }
}
