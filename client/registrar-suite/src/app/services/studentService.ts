import { StudentController } from "src/@core/APIs/StudentController";
import { FamilyMemberBasicDto } from "src/@core/dto/FamilyMemberBasicDto";
import { FamilyMemberBasicResponseDto } from "src/@core/dto/FamilyMemberBasicResponseDto";
import { StudentBasicDto } from "src/@core/dto/StudentBasicDto";
import { StudentNationalityDto } from "src/@core/dto/StudentNationalityDto";

export class StudentService {
  async getAllStudents(): Promise<StudentBasicDto[]> {
    try {
      const response = await fetch(StudentController.GetAllStudents);
      const resjs = await response.json();
      return resjs;
    } catch (error) {
      console.error('Error:', error);
      throw error; // Rethrow the error or handle it appropriately
    }
  }
  

  async addNewStudent(studentBasicDto: StudentBasicDto): Promise<StudentBasicDto | null> {
    console.log('====================================');
    const response = await fetch(StudentController.AddNewStudent, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(studentBasicDto),
    });

    if (response.ok) {
      return response.json();
    } else {
      return null;
    }
  }

  async updateStudent(id: number, studentBasicDto: StudentBasicDto): Promise<StudentBasicDto | null> {
    const response = await fetch(StudentController.UpdateStudent(id), {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(studentBasicDto),
    });

    if (response.ok) {
      return response.json();
    } else {
      return null;
    }
  }

  async getStudentNationality(id: number): Promise<StudentNationalityDto | null> {
    const response = await fetch(StudentController.GetStudentNationality(id));
    return response.json();
  }

  async updateStudentNationality(id: number, nationalityId: number): Promise<StudentNationalityDto | null> {
    const response = await fetch(StudentController.UpdateStudentNationality(id, nationalityId), {
      method: 'PUT',
    });

    if (response.ok) {
      return response.json();
    } else {
      return null;
    }
  }

  async getFamilyMembers(id: number): Promise<FamilyMemberBasicResponseDto[] | null> {
    const response = await fetch(StudentController.GetFamilyMembers(id));
    
    if (response.ok) {
      return response.json();
    } else {
      return null;
    }
  }

  async addFamilyMember(id: number, requestDto: FamilyMemberBasicDto): Promise<FamilyMemberBasicDto | null> {
    const response = await fetch(StudentController.AddFamilyMember(id), {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(requestDto),
    });

    if (response.ok) {
      return response.json();
    } else {
      return null;
    }
  }
}


// Example usage:
// const studentService = new StudentService('http://your-api-base-url');
// const allStudents = await studentService.getAllStudents();
// console.log(allStudents);
