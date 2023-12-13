
import { BaseURL } from '../config';

export const StudentController = {
  GetAllStudents: BaseURL + '/api/Students',
  AddNewStudent: BaseURL + '/api/Students',
  UpdateStudent: (id: number) => `${BaseURL}/api/Students/${id}`,
  GetStudentNationality: (id: number) => `${BaseURL}/api/Students/${id}/Nationality`,
  UpdateStudentNationality: (id: number, code: string) => `${BaseURL}/api/Students/${id}/Nationality/${code}`,
  GetFamilyMembers: (id: number) => `${BaseURL}/api/Students/${id}/FamilyMembers`,
  AddFamilyMember: (id: number) => `${BaseURL}/api/Students/${id}/FamilyMembers`,
};