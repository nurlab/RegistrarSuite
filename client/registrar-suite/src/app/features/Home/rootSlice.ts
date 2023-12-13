import { createSlice } from "@reduxjs/toolkit";
import { CountryDto } from "src/@core/dto/CountryDto";
import { FamilyMemberBasicDto } from "src/@core/dto/FamilyMemberBasicDto";
import { FamilyMemberBasicResponseDto } from "src/@core/dto/FamilyMemberBasicResponseDto";
import { StudentBasicDto } from "src/@core/dto/StudentBasicDto";
import { StudentDto } from "src/@core/dto/StudentDto";
import { FamilyMemberService } from "src/app/services/FamilyMemberService";
import { NationalityService } from "src/app/services/nationalityService";
import { StudentService } from "src/app/services/studentService";

export const fetchStudentList = async () => {
    const studentService = new StudentService();
    const studentList = await studentService.getAllStudents();
    return studentList;
};
export const addStudent = async (newStudent: StudentBasicDto) => {
    const studentService = new StudentService();
    const student = await studentService.addNewStudent(newStudent);
    return student;
};
export const fetchFamilyMemberList = async (id: number) => {
  const studentService = new StudentService();
  const familyMemberList = await studentService.getFamilyMembers(id);
  return familyMemberList;
};
export const addNewFamilyMember = async (id: number , _familyMemberBasicDto : FamilyMemberBasicDto) => {
  const studentService = new StudentService();
  const familyMember = await studentService.addFamilyMember(id,_familyMemberBasicDto);
  return familyMember;
};
export const updateFamilyMember = async (id: number , _familyMemberBasicResponseDto : FamilyMemberBasicDto) => {
  const familyMemberService = new FamilyMemberService();
  const familyMember = await familyMemberService.updateFamilyMember(id,_familyMemberBasicResponseDto);
  return familyMember;
};
export const removeFamilyMember = async (id: number) => {
  const familyMemberService = new FamilyMemberService();
  const result = await familyMemberService.deleteFamilyMember(id);
  return result;
};
export const getStudentNationality = async (id: number) => {
  const studentService = new StudentService();
  const result = await studentService.getStudentNationality(id);
  return result;
};
export const getAllNationalities = async () => {
  const nationalityService = new NationalityService();
  const result = await nationalityService.getNationalities();
  return result;
};
export const updateStduentNationality = async (id: number, code:string) => {
  const studentService = new StudentService();
  const result = await studentService.updateStudentNationality(id,code);
  return result;
};
 // updateStduentNationality
  const initialState = {
    studentList: [] as StudentDto[] | null,
    familyMemberList: [] as FamilyMemberBasicResponseDto[] | null,
    familyMemberBasicResponseDto: {},
    familyMemberBasicDto : {},
    studentNationalityDto : {},
    nationalityList: [] as CountryDto[] | null,

    role:'Admin' as string,
    loading: false,
    error: null as string | null,
  };
  
  export const rootSlice = createSlice({
    name: 'root',
    initialState,
    reducers: {
      //#region role
      setRole : (state,action) => {
        state.role = action.payload;
      },
      //#endregion
      //#region get All Students
      getAllStudentsStart: (state) => {
        state.loading = true;
        state.error = null;
      },
      getAllStudentsSuccess: (state, action) => {
        state.loading = false;
        state.studentList = action.payload;
      },
      getAllStudentsFailure: (state, action) => {
        state.loading = false;
        state.error = action.payload;
      },
      //#endregion

      //#region get All Students
      addStudentStart: (state) => {
        state.loading = true;
        state.error = null;
      },
      addStudentSuccess: (state) => {
        state.loading = false;
      },
      addStudentFailure: (state, action) => {
        state.loading = false;
        state.error = action.payload;
      },
      //#endregion

      //#region Get All family Members
      getAllfamilyMembersStart: (state) => {
        state.loading = true;
        state.error = null;
      },
      getfamilyMembersSuccess: (state, action) => {
        state.loading = false;
        state.familyMemberList = action.payload;
      },
      getAllfamilyMembersFailure: (state, action) => {
        state.loading = false;
        state.error = action.payload;
      },
      clearfamilyMembers: (state) => {
        state.loading = false;
        state.familyMemberList = null;
      },
      //#endregion

      //#region addNewFamilyMember
      addNewFamilyMemberStart: (state) => {
        state.loading = true;
        state.error = null;

      },
      addNewFamilyMemberSuccess: (state, action) => {
        state.loading = true;
        state.familyMemberBasicDto = action.payload;

      },
      addNewFamilyMemberFailure: (state, action) => {
        state.loading = false;
        state.error = action.payload;
      },
      //#endregion

      //#region Update Family Member
      updateFamilyMemberStart: (state) => {
        state.loading = true;
        state.error = null;

      },
      updateFamilyMemberSuccess: (state, action) => {
        state.loading = true;
        state.familyMemberBasicResponseDto = action.payload;

      },
      updateFamilyMemberFailure: (state, action) => {
        state.loading = false;
        state.error = action.payload;
      },
      //#endregion

      //#region Update Family Member
      removeFamilyMemberStart: (state) => {
        state.loading = true;
        state.error = null;

      },
      removeFamilyMemberSuccess: (state, action) => {
        state.loading = true;
        state.familyMemberBasicDto = action.payload;

      },
      removeFamilyMemberFailure: (state, action) => {
        state.loading = false;
        state.error = action.payload;
      },
      //#endregion

      //#region Update Family Member
      getStudentNationality: (state,action) => {
        state.loading = true;
        state.studentNationalityDto = action.payload;

      },
      getStudentNationalitySuccess: (state, action) => {
        state.loading = true;
        state.studentNationalityDto = action.payload;

      },
      getAllNationalities: (state, action) => {
        state.loading = true;
        state.nationalityList = action.payload;

      },
      getAllNationalitiesSuccess: (state, action) => {
        state.loading = true;
        state.nationalityList = action.payload;

      },
      updateStduentNationality: (state) => {
        state.loading = false;
      },
      //#endregion
      
    },
  });