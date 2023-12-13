import { StudentController } from "src/@core/APIs/StudentController";
import { FamilyMemberBasicDto } from "src/@core/dto/FamilyMemberBasicDto";
import { FamilyMemberBasicResponseDto } from "src/@core/dto/FamilyMemberBasicResponseDto";
import { StudentBasicDto } from "src/@core/dto/StudentBasicDto";
import { StudentDto } from "src/@core/dto/StudentDto";
import { StudentNationalityDto } from "src/@core/dto/StudentNationalityDto";

export class StudentService {
  async getAllStudents(): Promise<StudentDto[]> {
    try {
      const response = await fetch(StudentController.GetAllStudents);
      
      if (!response.ok) {
        // Handle non-successful response (e.g., logging, throwing a specific error)
        console.error(`Failed to fetch students. Status: ${response.status}`);
        throw new Error('Failed to fetch students');
      }
  
      const students: StudentDto[] = await response.json();
  
      // Ensure that the response is an array of StudentDto
      if (!Array.isArray(students)) {
        throw new Error('Invalid response format. Expected an array of StudentDto.');
      }
  
      return students;
    } catch (error) {
      console.error('An error occurred during the getAllStudents API call:', error);
      throw error; // Rethrow the error or handle it appropriately
    }
  }
  
  
  async addNewStudent(studentBasicDto: StudentBasicDto): Promise<StudentBasicDto | null> {
    try {
      const response = await fetch(StudentController.AddNewStudent, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(studentBasicDto),
      });
  
      if (response.ok) {
        const result: StudentBasicDto = await response.json();
  
        // Ensure that the response is of the expected type
        if (result && typeof result === 'object') {
          return result;
        } else {
          throw new Error('Invalid response format. Expected an object of StudentBasicDto.');
        }
      } else {
        return null;
      }
    } catch (error) {
      console.error('An error occurred during the addNewStudent API call:', error);
      throw error; // Rethrow the error or handle it appropriately
    }
  }
  async updateStudent(id: number, studentBasicDto: StudentBasicDto): Promise<StudentBasicDto | null> {
    try {
      const response = await fetch(StudentController.UpdateStudent(id), {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(studentBasicDto),
      });
  
      if (response.ok) {
        const result: StudentBasicDto = await response.json();
  
        // Ensure that the response is of the expected type
        if (result && typeof result === 'object') {
          return result;
        } else {
          throw new Error('Invalid response format. Expected an object of StudentBasicDto.');
        }
      } else {
        return null;
      }
    } catch (error) {
      console.error('An error occurred during the updateStudent API call:', error);
      throw error; // Rethrow the error or handle it appropriately
    }
  }
  
  async getStudentNationality(id: number): Promise<StudentNationalityDto | null> {
    try {
      const response = await fetch(StudentController.GetStudentNationality(id));
  
      if (response.ok) {
        const result: StudentNationalityDto = await response.json();
  
        // Ensure that the response is of the expected type
        if (result && typeof result === 'object') {
          return result;
        } else {
          throw new Error('Invalid response format. Expected an object of StudentNationalityDto.');
        }
      } else {
        return null;
      }
    } catch (error) {
      console.error('An error occurred during the getStudentNationality API call:', error);
      throw error; // Rethrow the error or handle it appropriately
    }
  }
  
  async updateStudentNationality(id: number, code: string): Promise<StudentNationalityDto | null> {
    try {
      const response = await fetch(StudentController.UpdateStudentNationality(id, code), {
        method: 'PUT',
      });
  
      if (response.ok) {
        const result: StudentNationalityDto = await response.json();
  
        // Ensure that the response is of the expected type
        if (result && typeof result === 'object') {
          return result;
        } else {
          throw new Error('Invalid response format. Expected an object of StudentNationalityDto.');
        }
      } else {
        return null;
      }
    } catch (error) {
      console.error('An error occurred during the updateStudentNationality API call:', error);
      throw error; // Rethrow the error or handle it appropriately
    }
  }
  
  async getFamilyMembers(id: number): Promise<FamilyMemberBasicResponseDto[] | null> {
    try {
      const response = await fetch(StudentController.GetFamilyMembers(id), {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        }
      });
  
      if (response.ok) {
        const result: FamilyMemberBasicResponseDto[] = await response.json();
  
        // Ensure that the response is of the expected type
        if (Array.isArray(result)) {
          return result;
        } else {
          throw new Error('Invalid response format. Expected an array of FamilyMemberBasicResponseDto.');
        }
      } else {
        return null;
      }
    } catch (error) {
      console.error('An error occurred during the getFamilyMembers API call:', error);
      throw error; // Rethrow the error or handle it appropriately
    }
  }
  
  async addFamilyMember(id: number, requestDto: FamilyMemberBasicDto): Promise<FamilyMemberBasicResponseDto | null> {
    try {
      const response = await fetch(StudentController.AddFamilyMember(id), {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestDto),
      });
  
      if (response.ok) {
        const result: FamilyMemberBasicResponseDto = await response.json();
  
        // Ensure that the response is of the expected type
        if (result && typeof result === 'object') {
          return result;
        } else {
          throw new Error('Invalid response format. Expected an object of FamilyMemberBasicResponseDto.');
        }
      } else {
        return null;
      }
    } catch (error) {
      console.error('An error occurred during the addFamilyMember API call:', error);
      throw error; // Rethrow the error or handle it appropriately
    }
  }  
}

 