using Microsoft.AspNetCore.Mvc;
using RegistrarSuite.DTO.Students;

namespace RegistrarSuite.Services.Students
{
    public interface IStudentService
    {
        /// <summary>
        /// Retrieves a list of all students.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{List{StudentDto}}"/> representing the asynchronous operation.
        /// The task result is a list of <see cref="StudentDto"/> containing basic details of all students.
        /// If there are no students, the list will be empty.
        /// </returns>
        Task<List<StudentDto>> GetAllStudents();

        /// <summary>
        /// Adds a new Student with Basic Details Only.
        /// </summary>
        /// <param name="studentBasicDto">The data transfer object (DTO) containing the basic details for the new student.</param>
        /// <returns>
        /// A <see cref="Task{StudentBasicDto}"/> representing the asynchronous operation.
        /// The task result is a <see cref="StudentBasicDto"/> containing information about the newly added student.
        /// If the addition fails, returns <c>null</c>.
        /// </returns>
        Task<StudentBasicDto?> AddNewStudent(StudentBasicDto studentBasicDto);

        /// <summary>
        /// Updates a Student's Basic Details.
        /// </summary>
        /// <param name="Id">The identifier of the student whose basic details are being updated.</param>
        /// <param name="studentBasicDto">The data transfer object (DTO) containing the new basic details for the student.</param>
        /// <returns>
        /// A <see cref="Task{StudentBasicDto}"/> representing the asynchronous operation.
        /// The task result is a <see cref="StudentBasicDto"/> containing information about the updated basic details.
        /// If the student is not found, returns <c>null</c>.
        /// </returns>
        Task<StudentBasicDto?> UpdateStudent(int Id, StudentBasicDto studentBasicDto);

        /// <summary>
        /// Retrieves the Nationality information of a particular student.
        /// </summary>
        /// <param name="id">The identifier of the student for whom the nationality information is being retrieved.</param>
        /// <returns>
        /// A <see cref="StudentNationalityDto"/> representing the Nationality of the specified student.
        /// If the student or nationality information is not found, returns <c>null</c>.
        /// </returns>
        StudentNationalityDto? GetStudentNationality(int id);

        /// <summary>
        /// Updates a Student's Nationality.
        /// </summary>
        /// <param name="id">The identifier of the student whose nationality is being updated.</param>
        /// <param name="nationalityId">The identifier of the new nationality for the student.</param>
        /// <returns>
        /// A <see cref="Task{StudentNationalityDto}"/> representing the asynchronous operation.
        /// The task result is a <see cref="StudentNationalityDto"/> containing information about the updated nationality.
        /// If the student or nationality is not found, returns <c>null</c>.
        /// </returns>
        Task<StudentNationalityDto?> UpdateStudentNationality(int id, int nationalityId);

        /// <summary>
        /// Retrieves a list of Family Members for a particular Student.
        /// </summary>
        /// <param name="id">The identifier of the student for whom the family members are being retrieved.</param>
        /// <returns>
        /// A <see cref="List{FamilyMemberDto}"/> representing the Family Members of the specified student.
        /// If there are no family members or the student is not found, returns <c>null</c>.
        /// </returns>
        List<FamilyMemberBasicResponseDto>? GetFamilyMembers(int id);

        /// <summary>
        /// Creates a new Family Member for a particular Student (without the nationality).
        /// </summary>
        /// <param name="id">The identifier of the student for whom the family member is being added.</param>
        /// <param name="requestDto">The data transfer object (DTO) containing information for the new family member.</param>
        /// <returns>A <see cref="Task{FamilyMemberBasicDto}"/> representing the asynchronous operation. The task result is the added <see cref="FamilyMemberBasicDto"/>.</returns>
        Task<FamilyMemberBasicDto> AddFamilyMember(int id, [FromBody] FamilyMemberBasicDto requestDto);

    }
}
